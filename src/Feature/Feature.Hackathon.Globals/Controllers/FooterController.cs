using System;
using System.Web.Mvc;
using Feature.Hackathon.Globals.Models;
using Foundation.Hackathon.Helpers.Helpers;

namespace Feature.Hackathon.Globals.Controllers
{
    public class FooterController : Controller
    {

        public ActionResult Index()
        {
            var model = new FooterViewModel();

            model.CopyrightText = string.Format(ItemHelper.GetRootItem()["Copyright"], DateTime.Now.Year);

            return View("/Views/Globals/Footer.cshtml", model);
        }

    }
}