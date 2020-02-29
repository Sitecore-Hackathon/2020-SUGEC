using System.Web.Mvc;

namespace Feature.Hackathon.Globals.Controllers
{
    public class FooterController : Controller
    {

        public ActionResult Index()
        {
            return View("/Views/Globals/Footer.cshtml");
        }

    }
}