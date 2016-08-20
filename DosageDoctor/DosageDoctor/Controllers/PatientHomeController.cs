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
using DosageDoctor.Models;

namespace DosageDoctor.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientHomeController : Controller
    {
        
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new PatientIndexViewModel();
            using (var db = new AppDbContext())
            {

                viewModel.Patient = await db.Patients.Where(x => x.PatientId.ToString() == userId).FirstOrDefaultAsync();
                viewModel.Doctors = await db.Doctors.ToListAsync();
                viewModel.Medications = await db.Medications.ToListAsync();
            }


                return View(viewModel);
        }

        public async Task<ActionResult> AddMedication()
        {
            var viewModel = new AddMedicationViewModel();
            using (var db = new AppDbContext())
            {

                viewModel.Medications = await db.Medications.ToListAsync();
            }



            return View(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> AddMedication(AddMedicationViewModel input)
        {
            
            using (var db = new AppDbContext())
            {
                var medicine = new Medication()
                {
                    DosesPerDay = input.MedicationUpdate.DosesPerDay,
                    ExpriationDate = input.MedicationUpdate.ExpriationDate,
                    CurrentQuantity = input.MedicationUpdate.CurrentQuantity,
                    DoseTimeOfDay = input.MedicationUpdate.DoseTimeOfDay,
                    IssueDate = input.MedicationUpdate.IssueDate,
                    MedicationId = Guid.NewGuid(),
                    Name = input.MedicationUpdate.Name,
                    Refills = input.MedicationUpdate.Refills,
                    UserId = new Guid(User.Identity.GetUserId()),
                    WeightPerDose = input.MedicationUpdate.WeightPerDose
                };
                db.Medications.Add(medicine);
                await db.SaveChangesAsync();

            }



            return RedirectToAction("Index");
        }

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