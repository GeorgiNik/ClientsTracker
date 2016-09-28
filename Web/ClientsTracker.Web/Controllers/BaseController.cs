namespace ClientsTracker.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using ClientsTracker.Services.Web;
    using ClientsTracker.Web.Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}
