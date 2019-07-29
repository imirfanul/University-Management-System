using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Manager
{
    public class AllocateClassroomsManager
    {
        private AllocateClassroomsGateway allocateClassroomsGateway;

        public AllocateClassroomsManager()
        {
            allocateClassroomsGateway=new AllocateClassroomsGateway();
        }

        public string Save(AllocateClassrooms allocateClassrooms)
        {
            if (allocateClassrooms.FromTime > allocateClassrooms.ToTime)
            {
                return "This Time is not Avaiable";
            }
            bool isTimeClassAllocateValid = IsTimeClassAllocateValid(allocateClassrooms.DayId, allocateClassrooms.RoomId,allocateClassrooms.FromTime, allocateClassrooms.ToTime);
            if (isTimeClassAllocateValid == false)
            {
                int rowAffect = allocateClassroomsGateway.Save(allocateClassrooms);
                if (rowAffect > 0)
                {
                    return "Save Successfully";
                }
                else
                {
                    return "Save Failed";
                }
            }
            return "Overlapping not allowed";
        }


        private bool IsTimeClassAllocateValid(int DayId, int RoomId, DateTime FromTime, DateTime ToTime)
        {
            List<AllocateClassrooms> allocateClassroomses= allocateClassroomsGateway.GetTimeAllocate(DayId, RoomId, FromTime, ToTime);

            foreach (var allocate in allocateClassroomses)
            {
                if ((allocate.DayId == DayId && RoomId == allocate.RoomId) &&
                    (FromTime < allocate.FromTime && ToTime > allocate.ToTime) ||
                    (FromTime < allocate.FromTime && ToTime > allocate.ToTime) || (FromTime == allocate.FromTime) ||
                    (allocate.FromTime < FromTime && allocate.ToTime > FromTime))
                {
                    return true;
                }                
            }
            return false;
        }

        //----------------Class Schedule-------------------

        public string GetAllSchedule(int departmentId)
        {
           List<ScheduleViewMode> claViewModes= allocateClassroomsGateway.GetAllSchedule(departmentId);
           string scheduleInfo = "";
           foreach (var schedule in claViewModes)
           {
               scheduleInfo += "R.No: " + schedule.RoomName + ", " + schedule.DayName + ", " + schedule.FromTime.ToShortTimeString() +
                                     " - " + schedule.ToTime.ToShortTimeString() + ";<br />";               
           }
            return scheduleInfo;
        }

        //----------Unassign Classrooms---------------------
        public string updateCourseAction(AllocateClassrooms allocate)
        {
            int rowAffect = allocateClassroomsGateway.UpdateCourse(allocate);
            if (rowAffect > 0)
            {
                return "Unassign Successfully";
            }
            else
            {
                return "Unassign Failed";
            }

        }

        public bool isActionExist()
        {
            return allocateClassroomsGateway.isActionExist();
        }

        public List<AllocateClassrooms> GetAllCourseAction()
        {
            return allocateClassroomsGateway.GetAllCourseByAction();
        } 


    }
}