using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class GradeLetterManager
    {
        private GradeLetterGateway gradeLetterGateway;

        public GradeLetterManager()
        {
            gradeLetterGateway=new GradeLetterGateway();
        }

        public List<GradeLetter> GetAllGrade()
        {
            return gradeLetterGateway.GetAllGrade();
        } 

        public List<SelectListItem> GetAllSelectListByGrade()
        {
            List<GradeLetter> gradeLetters = GetAllGrade();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = "",
            });
            foreach (var grade in gradeLetters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = grade.Grade;
                selectListItem.Value = grade.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        } 
    }
}