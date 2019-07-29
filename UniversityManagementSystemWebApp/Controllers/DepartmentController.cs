using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        

        private DepartmentManager departmentManager;
        private CourseManager courseManager;

        public DepartmentController()
        {
            departmentManager=new DepartmentManager();
            courseManager=new CourseManager();
        }

       

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (ModelState.IsValid)
            {
                string message = departmentManager.Save(department);
                ViewBag.Message = message;
                ModelState.Clear();
                return View();
            }
            else
            {
                string message = "Model State is Invalid";
                return View();
            }
        }
       
    }
}