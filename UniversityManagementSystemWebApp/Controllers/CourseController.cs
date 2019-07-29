using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class CourseController : Controller
    {
        

        private CourseManager courseManager;
        private DepartmentManager departmentManager;
        private SemesterManager semesterManager;
        public CourseController()
        {
            courseManager=new CourseManager();   
            departmentManager=new DepartmentManager();
            semesterManager=new SemesterManager();
        }
        
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();
            //ViewBag.Departments = departmentManager.GetAllDepartments();
            ViewBag.Semesters = semesterManager.GetSelectListItemsForSemesterDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {

            //if (ModelState.IsValid)
            //{               
                string message = courseManager.Save(course);
                ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();
                ViewBag.Semesters = semesterManager.GetSelectListItemsForSemesterDropdown();
                ViewBag.Message = message;
                ModelState.Clear();
                return View();
            //}
            //else
            //{
            //    ViewBag.Message = "Model state is Invalide";
            //    return View();
            //}

        }
	}
}