using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class StudentController : Controller
    {
        
        private DepartmentManager departmentManager;
        private StudentManager studentManager;

        public StudentController()
        {
            departmentManager=new DepartmentManager();
            studentManager=new StudentManager();
        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            
            //if (ModelState.IsValid)
            //{
                student.RegistrationNo = registrationNumber(student.DepartmentId, student.RegisterDate);
                ViewBag.Departments = departmentManager.GetSelectListItemsForDropdown();
                ViewBag.StudentReg = student.RegistrationNo;
                ViewBag.Name = student.Name;
                ViewBag.Email = student.Email;
                ViewBag.Contact = student.Contact;
                ViewBag.RegDate = student.RegisterDate;
                string message = studentManager.Save(student);

                ViewBag.Message = message;
                //if (message == "Sucesess")
                //{
                //    ViewBag.StudentInfo = studentManager.GetStudentInfoByRagNo(student.RegistrationNo);
                //}
                ModelState.Clear();
                return View();
            //}
            //else
            //{
            //    ViewBag.Message = "Model state is Invalide";
            //    return View();
            //}
        }

        public string registrationNumber(int departmentId,DateTime registerdate)
        {
            string departmentCode = departmentManager.GetDepartmentById(departmentId).Code;
            int year = registerdate.Year;

            int num = 0;
            int count = studentManager.GetAllStudent(departmentId);
            count = count + 1;
            string countString = count.ToString();
            if (countString.Length == 1)
            {
                string newNumber = "00" + countString;
                string RegistrationNo = departmentCode + "-" + year.ToString() + "-"+newNumber;
                return RegistrationNo;
            }
            else if (countString.Length == 2)
            {
                string newNumber = "0" + countString;
                string RegistrationNo = departmentCode + "-" + year.ToString() + "-"+newNumber;
                return RegistrationNo;
            }
            else
            {
                string newNumber = countString;
                string RegistrationNo = departmentCode + "-" + year.ToString() + "-" + newNumber;
                return RegistrationNo;
            }
        }
	}
}