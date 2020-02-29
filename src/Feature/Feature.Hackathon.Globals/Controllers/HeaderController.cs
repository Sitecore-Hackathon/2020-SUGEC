using System.Web.Mvc;
using Feature.Hackathon.Globals.Models;

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