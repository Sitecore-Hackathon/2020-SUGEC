using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feature.Hackathon.Accounts.Models;
using Feature.Hackathon.Accounts.Repositories;

namespace Feature.Hackathon.Accounts.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly string _redirectionUrl = "/registration/success";
        protected RegistrationRepository Repository { get; set; }

        public RegistrationController()
        {
            Repository = new RegistrationRepository();
        }

        // GET: Registration
        public ActionResult Index()
        {
            return View("/Views/Accounts/Registration.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegistrationForm formData)
        {
            Repository.CreateTeamItem(formData);
            return Redirect(_redirectionUrl);
        }
    }
}