using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web;
using System.Security.Principal;
using System.Threading.Tasks;
using DosageDoctor.Models;
using Microsoft.AspNet.Identity;

namespace DosageDoctor.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Index", "Admin");
            if (User.IsInRole("Patient"))
                return RedirectToAction("Index", "PatientHome");
            if (User.IsInRole("Doctor"))
                return RedirectToAction("Index", "DrHome");

            return RedirectToAction("ChooseRole");
        }

        public ActionResult ChooseRole()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> ChooseRole(RoleModificationModel model)
                
        //{
            
        //}

        public ActionResult OtherAction()
        {
            return View("Index", GetData("OtherAction"));
        }
        private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> dict
            = new Dictionary<string, object>();
            dict.Add("Action", actionName);
            dict.Add("User", HttpContext.User.Identity.Name);
            dict.Add("Authenticated", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Auth Type", HttpContext.User.Identity.AuthenticationType);
            dict.Add("In Users Role", HttpContext.User.IsInRole("Users"));
            return dict;
        }
    }

}