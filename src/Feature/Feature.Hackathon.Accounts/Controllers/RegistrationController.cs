using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feature.Hackathon.Accounts.Models;

namespace Feature.Hackathon.Accounts.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View("/Views/Accounts/Registration.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegistrationForm formData)
        {

            return Redirect("/");
        }
    }
}