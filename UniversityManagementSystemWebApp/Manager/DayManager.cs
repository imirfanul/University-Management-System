using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DayManager
    {
        private DayGateway dayGateway;

        public DayManager()
        {
            dayGateway=new DayGateway();
        }

        public List<DayModel> GetAllDay()
        {
            return dayGateway.GetAllDay();
        } 
        public List<SelectListItem> GetAllDayList()
        {
            List<DayModel> days = GetAllDay();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (DayModel day in days)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = day.Day;
                selectListItem.Value = day.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
    }
}