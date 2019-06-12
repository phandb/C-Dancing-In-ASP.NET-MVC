using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatientApplication.Models;
using PatientApplication.ViewModels;

namespace PatientApplication.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose the db context object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }

        //GET Patients
        public ActionResult Index()
        {
            var patients = _context.Patients.ToList();

            return View(patients);
        }
        
        //GET Patients/Details/{id}
        public ActionResult Details(int patientId)
        {
            var patient = _context.Patients
                            .Include(p=>p.Medications)
                            .Include(p=>p.Pharmacies)
                            .Include(p=>p.Physicians)
                            .SingleOrDefault(p => p.Id == patientId);

            if (patient == null)
                return HttpNotFound();

            return View(patient);
                
        }

        public ActionResult Edit(int patientId)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == patientId);

            //check if patient exist
            if (patient == null)
                return HttpNotFound();

            var viewModel = new PatientViewModel
            {
                Patient = patient

            };

            return View("PatientForm", viewModel);
        }

        public ActionResult NewPatient()
        {
            var viewModel = new PatientViewModel { };

            return View("PatientForm", viewModel);
        }

        //Read and Save data from new patient form
        [HttpPost]
        public ActionResult Save(Patient patient)
        {
            //Check if it is new patient
            if( patient.Id == 0){
                //add new patient to database
                _context.Patients.Add(patient);
            }

            //otherwise update patient
            else
            {
                var patientInDb = _context.Patients.Single(p => p.Id == patient.Id);

                patientInDb.Name = patient.Name;
                patientInDb.Address = patient.Address;
                patientInDb.Birthdate = patient.Birthdate;
                patientInDb.Gender = patient.Gender;
               

            }

            //persist the change to database
            _context.SaveChanges();

            //redirect to index in the PatientsController
            return RedirectToAction("Index", "Patients");
        }

        //GET Patients/Delete/{id}
        
        public ActionResult Delete(int patientId)
        {
            Patient patient = _context.Patients.Find(patientId);

            //check if patient exist
            if (patient == null)
                return HttpNotFound();

            

            return View(patient);
        }

        //POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]        
        public ActionResult DeleteConfirmed(int patientId)
        {
            Patient patient = _context.Patients.Find(patientId);
            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return RedirectToAction("Index", "Patients");

        }


        //Action method to display selection of physicians
        public ActionResult GetPhysicianList(int patientId)
        {
            
            var viewModel = new PhysicianSelectionViewModel();

            foreach (var physician in _context.Physicians)
            {
                var editorViewModel = new SelectPhysicianEditorViewModel()
                {
                    Selected = false,
                    Name = physician.PhysicianName,
                    Specialty = physician.PhysicianSpecialty,
                    Address = physician.PhysicianAddress,
                    physicianId = physician.Id,
                    patientId = patientId


                };
                viewModel.PhysicianList.Add(editorViewModel);

            }
            viewModel.thePatient = _context.Patients.Find(patientId);
          
            
            return View("PhysicianListForSelection", viewModel );
        }

        /********************************************************************************************/
        //Action method to handle data, selected physicians, when submit button pressed
        [HttpPost]
        public ActionResult SubmitSelectedPhysicianList(int thePatientId, PhysicianSelectionViewModel viewModel)
        {
            Patient patient = _context.Patients.Find(thePatientId);

            //Patient patient = viewModel.thePatient;
            //var thePatientId = viewModel.getPatientId();

            //get the ids from items selected
            var selectedPhysicianIds = viewModel.getSelectedPhysicianIds();


            //Use the ids to retrieve the records for the selected physicians
            //from database

            var selectedPhysicians = (from x in _context.Physicians where selectedPhysicianIds.Contains(x.Id) select x).ToList();



            //add each selected physician to the patient
            foreach (var physician in selectedPhysicians)
            {
                    
                patient.Physicians.Add(physician);
                //System.Diagnostics.Debug.WriteLine(physician.PhysicianName, physician.PhysicianSpecialty);

               // _context.SaveChanges();
            }


            _context.SaveChanges();

            //If everything is ok, redirect back to patient detail
            if (ModelState.IsValid)
            {
                Session["PhysicianSelectionViewModel"] = viewModel;

               // var patientID = viewModel.Patient.Id;
                return RedirectToAction("Details", "Patients", new { patientId = thePatientId });
            }

            //If something goes wrong, keep user at the same page
           //return View("PhysicianListForSelection", viewModel);
           return RedirectToAction("Details", "Patients", new { patientId = thePatientId });

        }

        /*****************************/
        
        public ActionResult DeletePhysicianFromPatient(int patientId, int physicianId)
        {

            Patient patient = _context.Patients.Find(patientId);
            Physician physician = _context.Physicians.Find(physicianId);

            patient.Physicians.Remove(physician);

            _context.SaveChanges();

            return RedirectToAction("Details", "Patients", new { patientId = patientId });
        }

        private IEnumerable<Physician> GetAllPhysicians()
        {
            //var allPhysicians = new List<Physician>

            var allPhysicians = _context.Physicians.ToList();

            return allPhysicians;


        }
        
        //This is the most important method
        //this method takes a list of strings and returns a list of SelectListItem objects.
        //These objects are going to be used later in the PhysicianList.Html to reder the DropDownList

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<Physician> elements)
        {
            //create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            //for each string in the elements variable, create a new SelectListItem object
            //that has both its Value and Text properties set to a particular value
            //This will result in MVC redering each item as:
            //   <option value="Physician Name">Physician Name</option>

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value= element.Id.ToString(),
                    Text= element.PhysicianName
                });

            }

            return selectList;
        }

    }
}
