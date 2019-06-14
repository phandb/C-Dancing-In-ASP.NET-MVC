
using PatientApplication.Models;
using PatientApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientApplication.Controllers
{
    
    public class PharmaciesController : Controller
    {
        private ApplicationDbContext _context;

        public PharmaciesController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose the db context object

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Pharmacies
        public ActionResult Index()
        {
            var pharmacies = _context.Pharmacies.ToList();

            return View(pharmacies);
        }

        //GET Pharmacies/Details/{id}
        public ActionResult Details(int pharmacyId)
        {
            var pharmacy = _context.Pharmacies.SingleOrDefault(p => p.Id == pharmacyId);

            if (pharmacy == null)
                return HttpNotFound();

            return View(pharmacy);


        }

        public ActionResult Edit(int pharmacyId)
        {
            var pharmacy = _context.Pharmacies.SingleOrDefault(p => p.Id == pharmacyId);

            //check if pharmacy exist
            if (pharmacy == null)
                return HttpNotFound();

            var viewModel = new PharmacyViewModel
            {
                Pharmacy = pharmacy
            };

            return View("PharmacyForm", viewModel);

        }

        public ActionResult NewPharmacy()
        {
            var viewModel = new PharmacyViewModel { };

            return View("PharmacyForm", viewModel);
        }

        //read and save data from pharmacy form
        [HttpPost]
        public ActionResult Save(Pharmacy pharmacy)
        {
            //check if it is new pharmacy
            if (pharmacy.Id == 0)
            {
                //add new pharmacy
                _context.Pharmacies.Add(pharmacy);

            }
            //otherwise update pharmacy
            else
            {
                var pharmacyInDb = _context.Pharmacies.Single(p => p.Id == pharmacy.Id);

                //Mapper.Map(Pharmacy, pharmacyInDb);
                pharmacyInDb.PharmacyName = pharmacy.PharmacyName;
                pharmacyInDb.PharmacyPhone = pharmacy.PharmacyPhone;
                pharmacyInDb.PharmacyAddress = pharmacy.PharmacyAddress;

            }
            //persist the change to database
            _context.SaveChanges();

            //redirect to index
            return RedirectToAction("Index", "Pharmacies");
        }

        //GET Pharmacies/Delete/{pharmacyId}
        public ActionResult Delete(int pharmacyId)
        {
            //get pharmacy via id
            Pharmacy pharmacy = _context.Pharmacies.Single(p => p.Id == pharmacyId);

            //Check if exist

            if (pharmacy == null)
            {
                return HttpNotFound();
            }

            return View(pharmacy);
        }

        //POST Pharmacies/Delete/{pharmacyId)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int pharmacyId)
        {
            Pharmacy pharmacy = _context.Pharmacies.SingleOrDefault(ph => ph.Id == pharmacyId);

            _context.Pharmacies.Remove(pharmacy);

            _context.SaveChanges();

            return RedirectToAction("Index", "Pharmacies");
        }


        /*****************************************************************************************/

        //Action method to display selection of pharmacies
        public ActionResult GetPharmacyList(int patientId)
        {

            var viewModel = new PharmacySelectionViewModel();

            foreach (var pharmacy in _context.Pharmacies)
            {
                var editorViewModel = new SelectPharmacyEditorViewModel()
                {
                    Selected = false,
                    Name = pharmacy.PharmacyName,
                    Address = pharmacy.PharmacyAddress,
                    pharmacyId = pharmacy.Id,
                    patientId = patientId


                };
                viewModel.PharmacyList.Add(editorViewModel);

            }
            viewModel.thePatient = _context.Patients.Find(patientId);


            return View("PharmacyListForSelection", viewModel);
        }

        /********************************************************************************************/
        //Action method to handle data, selected physicians, when submit button pressed
        [HttpPost]
        public ActionResult SubmitSelectedPharmacyList(int thePatientId, PharmacySelectionViewModel viewModel)
        {
            Patient patient = _context.Patients.Find(thePatientId);

            //Patient patient = viewModel.thePatient;
            //var thePatientId = viewModel.getPatientId();

            //get the ids from items selected
            var selectedPharmacyIds = viewModel.getSelectedPharmacyIds();


            //Use the ids to retrieve the records for the selected physicians
            //from database

            var selectedPharmacies = (from x in _context.Pharmacies where selectedPharmacyIds.Contains(x.Id) select x).ToList();



            //add each selected physician to the patient
            foreach (var pharmacy in selectedPharmacies)
            {

                patient.Pharmacies.Add(pharmacy);
                //System.Diagnostics.Debug.WriteLine(physician.PhysicianName, physician.PhysicianSpecialty);

                // _context.SaveChanges();
            }


            _context.SaveChanges();

            //If everything is ok, redirect back to patient detail
            if (ModelState.IsValid)
            {
                Session["PharmacySelectionViewModel"] = viewModel;

                // var patientID = viewModel.Patient.Id;
                return RedirectToAction("Details", "Patients", new { patientId = thePatientId });
            }

            //If something goes wrong, keep user at the same page
            //return View("PhysicianListForSelection", viewModel);
            return RedirectToAction("Details", "Patients", new { patientId = thePatientId });

        }

        /*****************************/

        public ActionResult DeletePharmacyFromPatient(int patientId, int pharmacyId)
        {

            Patient patient = _context.Patients.Find(patientId);
            Pharmacy pharmacy = _context.Pharmacies.Find(pharmacyId);

            patient.Pharmacies.Remove(pharmacy);

            _context.SaveChanges();

            return RedirectToAction("Details", "Patients", new { patientId = patientId });
        }
    }
}