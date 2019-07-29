using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class ViewAllDepartmentController : Controller
    {

        private DepartmentManager departmentManager;

        public ViewAllDepartmentController()
        {
            departmentManager=new DepartmentManager();
        }
        
        public ActionResult ViewAll()
        {
            List<Department> departmentList = departmentManager.GetAllDepartments();
            return View(departmentList);
        }
	}
}