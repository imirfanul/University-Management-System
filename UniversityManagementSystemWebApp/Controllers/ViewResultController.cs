using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class ViewResultController : Controller
    {
        private EnrollManager enrollManager;
        private StudentResultManager studentResultManager;

        public ViewResultController()
        {
            enrollManager=new EnrollManager();
            studentResultManager=new StudentResultManager();
        }
        
        public ActionResult ViewResult()
        {
            ViewBag.RegNo = enrollManager.GetSelectListItemsForDropdown();
            return View();
        }

        public JsonResult GetRegNoByStudentInfo(int registrationNo)
        {
            List<StudentResultViewModel> studentResultViewModels = studentResultManager.GetRegNoByStudentResultInfo(registrationNo);
            return Json(studentResultViewModels);
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
	}
}