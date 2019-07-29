using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Manager
{
    public class CourseAssignManager
    {
        private CourseAssignGateway courseAssignGateway;
        private TeacherGateway teacherGateway;

        public CourseAssignManager()
        {
            courseAssignGateway=new CourseAssignGateway();
            teacherGateway=new TeacherGateway();
        }

        public string Save(CourseAssign courseAssign)
        {
           
            if (courseAssignGateway.IsSubjectExsists(courseAssign))
            {
                return "The Course is already Assigned";
            }
            else
            {
                float Credit = Convert.ToSingle(courseAssignGateway.GetCourseId(courseAssign.CourseCode).Credit);
                float AvailableCredit = Convert.ToSingle(courseAssignGateway.GetAvailableCreditByTeacherId(courseAssign.TeacherId).ReminingCredit);
                float RemainingCredit = (AvailableCredit - Credit);

                
                    int rowAffect = courseAssignGateway.UpdateTeacher(courseAssign.TeacherId, RemainingCredit);
                    if (rowAffect > 0)
                    {
                        int affect = courseAssignGateway.Save(courseAssign);
                        if (affect > 0)
                        {
                            return "Save Successfully";

                        }
                        else
                        {
                            return "Failed";
                        }
                    }

                    else
                    {
                        return "Failed";
                    }
            }

        }

        public bool CheckAssignCourseEntry(string Id)
        {
            return courseAssignGateway.CheckAssignCourseEntry(Id);
        }

        public string GetTotalCredit(string Id)
        {
            return courseAssignGateway.GetTotalCredit(Id);
        }

        public List<CourseAssignViewModel> GetTeachersByDepartmentId(int departmentId)
        {
            return courseAssignGateway.GetTeachersByDepartmentId(departmentId);
        }
        public List<CourseAssignViewModel> GetCoursesByDepartmentId(int departmentId)
        {
            return courseAssignGateway.GetCoursesByDepartmentId(departmentId);
        }

        public List<Course> GetCourseCode(int courseCode)
        {
            return courseAssignGateway.GetCourseCode(courseCode);
        }

        public List<CourseStaticViewModel> GetCourseInfo(int departmentId)
        {
            return courseAssignGateway.GetCourseInfo(departmentId);
        }

    }
}