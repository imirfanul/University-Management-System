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
    public class CourseAssignController : Controller
    {
        double CreditToken;
        private CourseAssignManager courseAssignManager;
        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;
        private CourseManager courseManager;
        public CourseAssignController()
        {
            courseAssignManager=new CourseAssignManager();
            teacherManager=new TeacherManager();
            departmentManager=new DepartmentManager();
            courseManager=new CourseManager();
        }


        [HttpGet]
        public ActionResult CourseAssign()
        {
            ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();

            return View();
        }
        [HttpPost]
        public ActionResult CourseAssign(CourseAssign courseAssign)
        {
            if (ModelState.IsValid)
            {
                string message = courseAssignManager.Save(courseAssign);
                ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();
                ViewBag.Message = message;
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.Message = "Model is not valid";
                return View();
            }
        }
        public JsonResult GetDepartmentId(int departmentId)
        {
            List<CourseAssignViewModel> courseAssignView= courseAssignManager.GetTeachersByDepartmentId(departmentId);
            return Json(courseAssignView);
        }

        public JsonResult GetDepartmentIdByCourse(int departmentId)
        {
            List<CourseAssignViewModel> courseAssignView1 = courseAssignManager.GetCoursesByDepartmentId(departmentId);
            return Json(courseAssignView1);
        }
        public JsonResult GetCourseId(int courseId)
        {
            List<Course> courseAssignViews = courseAssignManager.GetCourseCode(courseId);
            return Json(courseAssignViews);
        }
        public JsonResult GetTeacherId(int teacherId)
        {
            List<Teacher> courseAssignViewsTeachers = teacherManager.GetTeacherId(teacherId);
            return Json(courseAssignViewsTeachers);
        }

        public ActionResult CourseView()
        {
            ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();
            return View();
        }

        public JsonResult GetDepartmentByCourseView(int departmentId)
        {
            List<CourseStaticViewModel> courseModel = courseAssignManager.GetCourseInfo(departmentId);
            return Json(courseModel);
        }

        public JsonResult GetRemainingCredit(string Id)
        {
            List<Teacher> creditTaken = teacherManager.GetCreditTaken(Id);
            bool CheckEntry = courseAssignManager.CheckAssignCourseEntry(Id);
            if (CheckEntry)
            {
                string TotalCredit = courseAssignManager.GetTotalCredit(Id);
                double TotalCredits = Convert.ToDouble(TotalCredit);
                foreach (var i in creditTaken)
                {
                    CreditToken = i.CreditToken;
                }

                double RemainingCredit = CreditToken - TotalCredits;
                foreach (var i in creditTaken)
                {
                    i.CreditToken = RemainingCredit;
                }
            }
            else
            {
                foreach (var i in creditTaken)
                {
                    ViewBag.Res = i.CreditToken;
                }
            }
            return Json(creditTaken);
        }
	}
}