namespace ClientsTracker.Web.Areas.Administration.Controllers
{
    using System;
    using System.Web.Mvc;

    using AutoMapper;

    using ClientsTracker.Data.Models;
    using ClientsTracker.Services.Data;
    using ClientsTracker.Web.Infrastructure.Mapping;
    using ClientsTracker.Web.Infrastructure.Users;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Details()
        {
            return this.View();
        }

        public ActionResult ApplicationUsers_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.userService.All().To<UsersVM>().ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Update([DataSourceRequest] DataSourceRequest request, UsersVM model)
        {
            if (this.ModelState.IsValid)
            {
                if (model.IsAdmin)
                {
                    this.userService.MakeAdmin(model.Id);
                }
                else
                {
                    this.userService.RemoveAdmin(model.Id);
                }

                var user = Mapper.Map<ApplicationUser>(model);
                this.userService.Update(user);
            }
            return this.Json(
                new[]
                    {
                        model
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationUsers_Destroy(
            [DataSourceRequest] DataSourceRequest request,
            UsersVM applicationUser)
        {
            var entity = Mapper.Map<ApplicationUser>(applicationUser);
            this.userService.Remove(entity);

            return this.Json(
                new[]
                    {
                        applicationUser
                    }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

    }
}