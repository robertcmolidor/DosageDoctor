using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
namespace DosageDoctor.Models
{
    public class AppUser : IdentityUser
    {

    }
    public class Doctor 
    {
        public Guid DoctorId { get; set; }
        public string ZipCode { get; set; }
        public string OfficeName { get; set; }
    }

    public class Patient 
    {
        public Guid PatientId { get; set; }
        public string ZipCode { get; set; }
    }

    public class PhoneNumber
    {
        [Key]
        public Guid UserId { get; set; }
        public string Number { get; set; }
    }

    public class DoctorPatientRelationship
    {
        [Key]
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
    }

}