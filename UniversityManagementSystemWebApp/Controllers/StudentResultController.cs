using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class StudentResultController : Controller
    {
        private GradeLetterManager gradeLetterManager;
        private StudentManager studentManager;
        private CourseManager courseManager;
        private StudentResultManager studentResultManager;
        private EnrollManager enrollManager;

        public StudentResultController()
        {
            gradeLetterManager=new GradeLetterManager();
            studentManager=new StudentManager();
            courseManager=new CourseManager();
            studentResultManager=new StudentResultManager();
            enrollManager=new EnrollManager();
        }
        
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.RegNo = enrollManager.GetSelectListItemsForDropdown();
            ViewBag.Grades = gradeLetterManager.GetAllSelectListByGrade();
            return View();
        }

        [HttpPost]
        public ActionResult Save(StudentResult studentResult)
        {
            string message = studentResultManager.Save(studentResult);
            ViewBag.RegNo = enrollManager.GetSelectListItemsForDropdown();
            ViewBag.Grades = gradeLetterManager.GetAllSelectListByGrade();
            ViewBag.Message = message;
            ModelState.Clear();
            return View();
        }
        public JsonResult GetRegNoByStudentInfo(int registrationNo)
        {
            List<EnrollViewModel> studentResultViewModels = enrollManager.GetStudentNoByInfo(registrationNo);
            return Json(studentResultViewModels);
        }
	}
}