using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientApplication.ViewModels
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }

        //This property will hold a physician selected by user
        [Required]
        [Display(Name = "Physician")]
        public string Physician { get; set; }

        //this property will hold all available physicians for selection
        public IEnumerable<SelectListItem> Physicians { get; set; }

       /* public string Title
        {
            get
            {
                return Id != 0 ? "Edit Patient" : "New Patient";
            }

        }*/
    }
}