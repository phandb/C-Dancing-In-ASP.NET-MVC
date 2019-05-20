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

        public ActionResult Edit(int patientId, int medicationId)
        {
            var medication = _context.Medications.SingleOrDefault(m => m.Id == medicationId);
            var patient = _context.Patients.SingleOrDefault(p => p.Id == patientId);

            //check if medicaion exists
            if (medication == null)
                return HttpNotFound();

            var viewModel = new MedicationViewModel
            {
                Medication = medication,
                Patient = patient
            };

            return View("MedicationForm", viewModel);
        }

        //This method add medication to patient
        

        public ActionResult Create(int patientId)
        {
            var thePatient = _context.Patients.SingleOrDefault(p => p.Id == patientId);
            if (thePatient == null)
                return HttpNotFound();

            var viewModel = new MedicationViewModel
            {
                Patient = thePatient           
            };

            return View("MedicationForm", viewModel);
        }

        //Read and save data from new medication form
        [HttpPost]
        public ActionResult Save(Medication medication, int patientId)
        {
            
           // var medication = _context.Medications.SingleOrDefault(m => m.Id == Medication.Id);

            var thePatient = _context.Patients.SingleOrDefault(p => p.Id == patientId);
            if (thePatient == null)
                return HttpNotFound();

            //check if new medication
            if (medication.Id == 0)
            {
               
               
                //add new medication
              thePatient.Medications.Add(medication);

              
            }
            //otherwise update the medication
            else
            {
                

                var medicationInDb = _context.Medications.Single(m => m.Id == medication.Id);

                //Mapper.Map(medication, medicationInDb);
                medicationInDb.MedicationName = medication.MedicationName;
                medicationInDb.MedicationStrength = medication.MedicationStrength;
                medicationInDb.MedicationDosage = medication.MedicationDosage;
               // medicationInDb.PatientId = medication.PatientId;


            }

            //persist the change to database
            _context.SaveChanges();

            //redirect to index in the PatientsController
            return RedirectToAction("Details", "Patients", new { patientId = patientId });
        }

        //GET Medications/Delete/{medicationId, patientId}
        public ActionResult Delete(int medicationId, int patientId)
        {
            Medication medication = _context.Medications.Find(medicationId);

            //check medication available
            if (medication == null)
            {
                return HttpNotFound();
            }

            _context.Medications.Remove(medication);
            _context.SaveChanges();


            return RedirectToAction("Details", "Patients", new { patientId = patientId });
        }
         

    }
}