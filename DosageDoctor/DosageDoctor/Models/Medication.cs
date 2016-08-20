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
        
    }
}