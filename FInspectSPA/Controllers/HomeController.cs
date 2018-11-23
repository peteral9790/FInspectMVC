using FInspectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FInspectSPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinalInspectionService _inspectionService = new FinalInspectionService();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetName()
        {
            var InspectorName = _inspectionService.GetAll().FirstOrDefault().Inspector.LastName;
            return Json(new { name = InspectorName }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInspectionHistory()
        {
            var history = _inspectionService.GetAll();
            return Json();
        }
    }
}