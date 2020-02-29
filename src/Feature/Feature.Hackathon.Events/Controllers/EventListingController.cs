using System.Web.Mvc;

namespace Feature.Hackathon.Events.Controllers
{
    public class EventListingController : Controller
    {
        public ActionResult Index()
        {
            return View("/Views/Events/EventListing.cshtml");
        }
    }
}