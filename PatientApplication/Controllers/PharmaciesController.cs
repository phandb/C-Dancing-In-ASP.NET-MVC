
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
        public ActionResult Details(int id)
        {
            var pharmacy = _context.Pharmacies.SingleOrDefault(p => p.Id == id);

            if (pharmacy == null)
                return HttpNotFound();

            return View(pharmacy);


        }

        public ActionResult Edit(int id)
        {
            var pharmacy = _context.Pharmacies.SingleOrDefault(p => p.Id == id);

            //check if pharmacy exist
            if (pharmacy == null)
                return HttpNotFound();

            var viewModel = new PharmacyFormViewModel
            {
                Pharmacy = pharmacy
            };

            return View("PharmacyForm", viewModel);

        }

        public ActionResult NewPharmacy()
        {
            var viewModel = new PharmacyFormViewModel { };

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
    }
}