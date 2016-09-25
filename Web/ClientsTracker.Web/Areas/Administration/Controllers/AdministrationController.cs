namespace ClientsTracker.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using ClientsTracker.Common;
    using ClientsTracker.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
