using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DosageDoctor.Infrastructure;
using DosageDoctor.ViewModles;
using Microsoft.AspNet.Identity;

namespace DosageDoctor.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientHomeController : Controller
    {
        
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var viewModel = new PatientIndexViewModel();
            using (var db = new AppDbContext())
            {

                viewModel.Patient = await db.Patients.Where(x => x.PatientId.ToString() == User.Identity.GetUserId()).FirstOrDefaultAsync();
                viewModel.Doctors = await db.Doctors.ToListAsync();
                viewModel.Medications = await db.Medications.ToListAsync();
            }


                return View(GetData("Index"));
        }

        [Authorize(Roles = "Users")]
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