using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }

       

       /* public string Title
        {
            get
            {
                return Id != 0 ? "Edit Patient" : "New Patient";
            }

        }*/
    }
}