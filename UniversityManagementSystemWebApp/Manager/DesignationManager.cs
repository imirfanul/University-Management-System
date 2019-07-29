using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DesignationManager
    {
        private DesignationGateway designationGateway;

        public DesignationManager()
        {
            designationGateway=new DesignationGateway();
        }

        public List<DesignationModel> GetDesignations()
        {
            return designationGateway.GetAllDesignations();
        }

        public List<SelectListItem> GetSelectListItemsForDesignationDropdown()
        {
            List<DesignationModel> designations = GetDesignations();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (DesignationModel designation in designations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = designation.Designation;
                selectListItem.Value = designation.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        } 
    }
}