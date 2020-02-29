using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feature.Hackathon.Globals.Controllers
{
    public class BannerController : Controller
    {
        // GET: Banner
        public ActionResult Index()
        {
            return View("/Views/Globals/Banner.cshtml");
        }
    }
}