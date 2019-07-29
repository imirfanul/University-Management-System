using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class TeacherController : Controller
    {
        
        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;
        private DesignationManager designationManager;

        public TeacherController()
        {
            teacherManager=new TeacherManager();
            departmentManager=new DepartmentManager();
            designationManager=new DesignationManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Designation = designationManager.GetSelectListItemsForDesignationDropdown();
            ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();            
            return View();
        }
        
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            if (ModelState.IsValid)
            {

                string message = teacherManager.Save(teacher);
                ViewBag.Designation = designationManager.GetSelectListItemsForDesignationDropdown();
                ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();
                ViewBag.Message = message;

                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.Message = "Model state is Invalide";
                return View();
            }
        }
    }
}