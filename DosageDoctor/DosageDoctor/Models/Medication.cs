using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DosageDoctor.Models
{
    public class Medication
    {
        
        public Guid UserId { get; set; }
        public Guid MedicationId { get; set; }
        public string Name { get; set; }
        public int WeightPerDose { get; set; }
        public int DosesPerDay { get; set; }
        public DateTime DoseTimeOfDay { get; set; }
        public int CurrentQuantity { get; set; }
        public DateTime ExpriationDate { get; set; }
        public DateTime IssueDate { get; set; }
        public int Refills { get; set; }

        public Medication()
        {
            UserId = new Guid();
            MedicationId = new Guid();
            Name = "";
            WeightPerDose = 0;
            DosesPerDay = 0;
            DoseTimeOfDay = DateTime.Now;
            CurrentQuantity = 0;
            ExpriationDate = DateTime.Now;
            IssueDate = DateTime.Now;
            Refills = 0;


        }
    }
}