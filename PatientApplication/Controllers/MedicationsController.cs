using PatientApplication.Models;
using PatientApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientApplication.Controllers
{
    public class MedicationsController : Controller
    {
        private ApplicationDbContext _context;

        public MedicationsController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose the db context object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }


        // GET: Medications
        public ActionResult Index()
        {
            var medications = _context.Medications.ToList();

            return View(medications);
        }

        //GET Medications/Details/{id}
        public ActionResult Details(int id)
        {
            var medication = _context.Medications.SingleOrDefault(m => m.Id == id);

            if (medication == null)
                return HttpNotFound();

            return View(medication);

        }

        public ActionResult Edit(int id)
        {
            var medication = _context.Medications.SingleOrDefault(m => m.Id == id);

            //check if medicaion exists
            if (medication == null)
                return HttpNotFound();

            var viewModel = new MedicationFormViewModel
            {
                Medication = medication
            };

            return View("MedicationForm", viewModel);
        }

        public ActionResult NewMedication()
        {
            var viewModel = new MedicationFormViewModel { };

            return View("MedicationForm", viewModel);

        }

        //Read and save data from new medication form
        [HttpPost]
        public ActionResult Save(Medication medication)
        {
            //check if new medication
            if (medication.Id == 0)
            {
                //add new medication
                _context.Medications.Add(medication);

            }
            //otherwise update the medication
            else
            {
                var medicationInDb = _context.Medications.Single(m => m.Id == medication.Id);

                //Mapper.Map(medication, medicationInDb);
                medicationInDb.MedicationName = medication.MedicationName;
                medicationInDb.MedicationStrength = medication.MedicationStrength;
                medicationInDb.MedicationDosage = medication.MedicationDosage;

            }

            //persist the change to database
            _context.SaveChanges();

            //redirect to index in the PatientsController
            return RedirectToAction("Index", "Medications");
        }

    }
}