using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway;

        public DepartmentManager()
        {
            departmentGateway=new DepartmentGateway();
        }

        public string Save(Department department)
        {
            if (departmentGateway.IsCodeExsists(department.Code))
            {
                return "This Code Already Insert";
            }

            else if (departmentGateway.IsNameExsists(department.Name))
            {
                return "This Name Already Insert";
            }
            else
            {
                int rowAffect = departmentGateway.Save(department);
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

        public Department GetDepartmentById(int departmentId)
        {
            return departmentGateway.GetDepartmentById(departmentId);
        }
        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }

        public List<SelectListItem> GetSelectListItemsForDropdown()
        {
            List<Department> departments = GetAllDepartments();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = department.Name;
                selectListItem.Value = department.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public Department GetDepartmentNameById(string departmentName)
        {
            return departmentGateway.GetDepartmentNameById(departmentName);
        }
    }
}