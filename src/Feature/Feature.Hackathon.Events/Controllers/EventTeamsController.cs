using System.Linq;
using System.Web.Mvc;
using Feature.Hackathon.Events.Models;
using Sitecore.Mvc.Presentation;

namespace Feature.Hackathon.Events.Controllers
{
    public class EventTeamsController : Controller
    {
        public ActionResult Index()
        {
            var model = new EventTeamsViewModel();

            model.Teams = RenderingContext.Current.ContextItem.Children;
            if (model.Teams != null)
            {
                //model.Teams = model.Teams.OrderBy(x => x.Fields["Created Date"]);
            }
            
            return View("/Views/Events/EventTeams.cshtml", model);
        }
    }
}