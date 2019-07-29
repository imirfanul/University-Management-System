using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Manager
{
    public class StudentManager
    {
        private StudentGateway studentGateway;
        private DepartmentManager departmentManager;
        public StudentManager()
        {
            studentGateway=new StudentGateway();
            departmentManager = new DepartmentManager();
        }

        public List<Department> GetAllDepartments()
        {
            return studentGateway.GetAllDepaertments();
        }

        public List<SelectListItem> GetSelectDropdownList()
        {
            List<Department> departments = GetAllDepartments();
            List<SelectListItem> selectListItems=new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (var department in departments)
            {
                SelectListItem selectListItem=new SelectListItem();
                selectListItem.Value = department.Id.ToString();
                selectListItem.Text = department.Code;
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        //public int GetStudentCountByYearAndDepartment(int departmentId, int year)
        //{
        //    return studentGateway.GetStudentCountByYearAndDepartment(departmentId, year);
        //}

        public StudentViewModel GetStudentInfoByRagNo(string RegistrationNo)
        {
            return studentGateway.GetStudentInfoByRagNo(RegistrationNo);
        }

        public int GetAllStudent(int departmentId)
        {
            return studentGateway.GetAllStudent(departmentId);
        }

        public string Save(Student student)
        {
            if (studentGateway.IsNameExsists(student))
            {
                return "This Email Already Exist";
            }
            else
            {
                int rowAffect = studentGateway.Save(student);
                if (rowAffect > 0)
                {
                    StudentViewModel studentView = new StudentViewModel();
                    return "Registered Successfully\n" + student.Name + Environment.NewLine + "\nRegistration No. : " + student.RegistrationNo + Environment.NewLine + "\nContact No. : " + student.Contact + Environment.NewLine  + Environment.NewLine + "\n Address : " + student.Address;
                }
                else
                {
                    return "Failed";
                }
            }
        }

        public List<Student> GetAllStudentRegNo()
        {
            return studentGateway.GetAllStudentRegNo();
        }

        public List<SelectListItem> GetSelectListItemsForDropdown()
        {
            List<Student> students = GetAllStudentRegNo();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Student student in students)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = student.RegistrationNo;
                selectListItem.Value = student.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public List<StudentResultViewModel> GetRegNoByStudentInfo(int RegistrationNo)
        {
            return studentGateway.GetRegNoByStudentInfo(RegistrationNo);
        }

        
    }
}