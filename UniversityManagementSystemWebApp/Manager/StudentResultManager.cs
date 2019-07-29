using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Manager
{
    public class StudentResultManager
    {
        private StudentResultGateway studentResultGateway;

        public StudentResultManager()
        {
            studentResultGateway=new StudentResultGateway();
        }

        public string Save(StudentResult studentResult)
        {
            if (studentResultGateway.IsNameExsists(studentResult))
            {
                return "This Course Grade Already Insert";
            }
            else
            {
                int rowAffect = studentResultGateway.Save(studentResult);
            if (rowAffect > 0)
            {
                return "Save Successfully";
            }
            else
            {
                return "Save Failed";
            }
            }
        }

        public List<StudentResultViewModel> GetRegNoByStudentResultInfo(int RegistrationNo)
        {
            return studentResultGateway.GetRegNoByStudentResultInfo(RegistrationNo);
        }
    }
}