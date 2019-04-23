using PatientApplication.Models;
using PatientApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientApplication.Controllers
{
    public class PhysiciansController : Controller
    {
        private ApplicationDbContext _context;

        public PhysiciansController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose the db context object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Physicians
        public ActionResult Index()
        {
            var physicians = _context.Physicians.ToList();

            return View(physicians);
        }

        //GET Physicians/Details/{id}
        public ActionResult Details(int id)
        {
            var physician = _context.Physicians.SingleOrDefault(p => p.Id == id);

            if (physician == null)
                return HttpNotFound();

            return View(physician);


        }

        public ActionResult Edit(int id)
        {
            var physician = _context.Physicians.SingleOrDefault(p => p.Id == id);

            //check if Physician exist
            if (physician == null)
                return HttpNotFound();

            var viewModel = new PhysicianFormViewModel
            {
                Physician = physician
            };

            return View("PhysicianForm", viewModel);

        }

        public ActionResult NewPhysician()
        {
            var viewModel = new PhysicianFormViewModel { };

            return View("PhysicianForm", viewModel);
        }

        //read and save data from Physician form
        [HttpPost]
        public ActionResult Save(Physician physician)
        {
            //check if it is new physician
            if (physician.Id == 0)
            {
                //add new physician
                _context.Physicians.Add(physician);

            }
            //otherwise update physician
            else
            {
                var physicianInDb = _context.Physicians.Single(p => p.Id == physician.Id);

                //Mapper.Map(physician, physicianInDb);
                physicianInDb.PhysicianName = physician.PhysicianName;
                physicianInDb.PhysicianPhone = physician.PhysicianPhone;
                physicianInDb.PhysicianAddress = physician.PhysicianAddress;
                physicianInDb.PhysicianSpecialty = physician.PhysicianSpecialty;

            }
            //persist the change to database
            _context.SaveChanges();

            //redirect to index
            return RedirectToAction("Index", "Physicians");
        }
    }
}