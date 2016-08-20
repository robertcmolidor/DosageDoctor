using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DosageDoctor.Models;

namespace DosageDoctor.ViewModles
{
    public class AddMedicationViewModel
    {
        public List<Medication> Medications { get; set; }
        public Medication MedicationUpdate { get; set; }
        public Guid UserId { get; set; }

        public AddMedicationViewModel()
        {
            Medications = new List<Medication>();
            MedicationUpdate = new Medication();
            UserId = new Guid();
        }
    }
}