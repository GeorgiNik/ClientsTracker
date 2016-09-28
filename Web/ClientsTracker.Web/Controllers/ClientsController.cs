namespace ClientsTracker.Web.Controllers
{
    using System.Web.Mvc;
    using ClientsTracker.Services.Data;
    using ClientsTracker.Web.Infrastructure.Clients;
    using Glimpse.Core.Extensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class ClientsController : Controller
    {
        private readonly IClientService clientsService;

        public ClientsController(IClientService clientsService)
        {
            this.clientsService = clientsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clients_Read([DataSourceRequest]DataSourceRequest request)
        {
            var vm = this.clientsService.GetAll().ToDataSourceResult(request);

            return this.Json(vm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Clients_Destroy([DataSourceRequest]DataSourceRequest request, ClientVM customer)
        {
            if (this.ModelState.IsValid)
            {
                this.clientsService.Delete(customer.Id);
            }

            return this.Json(new[] { customer }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Clients_Update([DataSourceRequest]DataSourceRequest request, ClientVM customer)
        {
            if (this.ModelState.IsValid)
            {
                this.clientsService.Update(customer);
            }

            return this.Json(new[] { customer }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Clients_Create([DataSourceRequest]DataSourceRequest request, ClientVM customer)
        {
            if (this.ModelState.IsValid)
            {
                customer.Id = this.clientsService.Create(customer).Id;
            }

            return this.Json(new[] { customer }.ToDataSourceResult(request, this.ModelState));
        }
    }
}