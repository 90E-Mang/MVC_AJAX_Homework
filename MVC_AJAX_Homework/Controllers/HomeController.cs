using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_AJAX_Homework.Models;

namespace MVC_AJAX_Homework.Controllers
{
    public class HomeController : Controller
    {
        EmpDB empDB = new EmpDB();

        public JsonResult SelectAll()
        {
            return Json(empDB.SelectEmp(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SelectByEmpno(int id)
        {
            var emp = empDB.SelectEmp().Find(x => x.Empno.Equals(id));
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Insert(EMP emp)
        {
            return Json(empDB.InsertEmp(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(EMP emp)
        {
            return Json(empDB.UpdateEmp(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int empno)
        {
            return Json(empDB.DeleteEmp(empno), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}