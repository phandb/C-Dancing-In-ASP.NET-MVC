using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientApplication.ViewModels
{
    public class AssignedPhysicianData
    {
        public int PhysicanID { get; set; }
        public string PhysicianName { get; set; }
        public bool IsAssigned { get; set; }
    }
}