using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PatientApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name:"AddMedicationToPatient",
                url: "{Save}/{Medication}/{patientId}",
                defaults: new { controller="Medications", action="Save", Medication = UrlParameter.Optional, patientId = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "SubmitSelectedPhysicianList",
                url: "{SubmitSelectedPhysicianList}/{Patient}/{thePatientId}",
                defaults: new { controller = "Patients", action = "Save", Patient = UrlParameter.Optional, patientId = UrlParameter.Optional }
                );
        }
    }
}
