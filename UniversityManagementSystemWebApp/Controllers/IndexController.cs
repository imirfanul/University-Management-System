using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class IndexController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
        
        public ActionResult Index()
        {
            ViewBag.Departments=departmentManager.GetSelectListItemsForDropdown();
            return View();
        }
        [HttpGet]
        public ActionResult TimePicker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TimePicker(Timepicker timepicker)
        {
            //timepicker.Time = TimeSpan.FromDays(1);
            return View();
        }
	}
}