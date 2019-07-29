using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class SemesterManager
    {
        private SemesterGateway semesterGateway;

        public SemesterManager()
        {
            semesterGateway=new SemesterGateway();
        }

        public List<SemesterModel> GetSemesters()
        {
            return semesterGateway.GetSemesters();
        }

        public List<SelectListItem> GetSelectListItemsForSemesterDropdown()
        {
            List<SemesterModel> semesters = GetSemesters();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (SemesterModel semester in semesters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = semester.Semester;
                selectListItem.Value = semester.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        } 
    }
}