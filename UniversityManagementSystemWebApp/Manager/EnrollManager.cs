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
    public class EnrollManager
    {
        EnrollGateway enrollGateway=new EnrollGateway();

        public EnrollManager()
        {
            enrollGateway=new EnrollGateway();
        }

        public List<EnrollViewModel> GetStudentNoByView(int registrationId)
        {
            return enrollGateway.GetStudentNoByView(registrationId);
        }

        public string Save(EnrollCourse enrollCourse)
        {
            if (enrollGateway.IsNameExsists(enrollCourse))
            {
                return "This Course Already Exist";
            }
            else
            {
                int rowAffect = enrollGateway.Save(enrollCourse);
            if (rowAffect>0)
            {
                return "Enrolled Successfuly";
            }
            else
            {
                return "Enrolled Failed";
            }
            }
            
        }

        public List<Student> GetAllStudentRegNo()
        {
            return enrollGateway.GetAllStudentRegNo();
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

        public List<EnrollViewModel> GetStudentNoByInfo(int registrationId)
        {
            return enrollGateway.GetStudentNoByInfo(registrationId);
        }

    }
}