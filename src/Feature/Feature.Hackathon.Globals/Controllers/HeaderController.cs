using System.Web.Mvc;

namespace Feature.Hackathon.Globals.Controllers
{
    public class HeaderController : Controller
    {
        public ActionResult Index()
        {
            return View("/Views/Globals/Header.cshtml");
        }
    }
}