using PatientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    //This class acting as a wrapper to contain a list of the SelectPharmacyEditorViewModel
    //to pass to or form a View
    //Include a method to access a list of pharmacyId in which pharmacies are selected
    public class PharmacySelectionViewModel
    {

        public Patient thePatient { get; set; }

        public List<SelectPharmacyEditorViewModel> PharmacyList { get; set; }

        //call constructor to pass a list of the ViewModels
        public PharmacySelectionViewModel()
        {

            this.PharmacyList = new List<SelectPharmacyEditorViewModel>();
            this.thePatient = new Patient();

        }

        //Method to access the list
        public IEnumerable<int> getSelectedPharmacyIds()
        {

            //return an Enumerable containing ids of the selected pharmacies
            return (from phar in this.PharmacyList where phar.Selected select phar.pharmacyId).ToList();
        }
    }
}