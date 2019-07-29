using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnallocateClassroomsController : Controller
    {
        AllocateClassroomsManager allocateClassroomsManager=new AllocateClassroomsManager();
        
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unassign(AllocateClassrooms allocate)
        {
            if (allocateClassroomsManager.isActionExist())
            {
                foreach (var courses in allocateClassroomsManager.GetAllCourseAction())
                {
                    ViewBag.Output = allocateClassroomsManager.updateCourseAction(courses);
                }
            }
            else
            {
                ViewBag.Output = "Already Unassigned";
            }
            return View();
        }
	}
}