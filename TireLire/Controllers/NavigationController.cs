
using System.Web.Mvc;
using System.Web.Security;

namespace TireLire.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public PartialViewResult Menu()
        {

            string[] roles = Roles.GetRolesForUser(User.Identity.Name);
            ViewBag.Roles = roles;
            return PartialView("_menu");
        }
    }
}