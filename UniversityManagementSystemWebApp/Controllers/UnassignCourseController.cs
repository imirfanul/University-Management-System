using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnassignCourseController : Controller
    {
        private CourseManager courseManager=new CourseManager();
        
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unassign(Course course)
        {
            if (courseManager.isActionExist())
            {
                foreach (var courses in courseManager.GetAllCourseAction())
                {
                    ViewBag.Output = courseManager.updateCourseAction(courses);
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