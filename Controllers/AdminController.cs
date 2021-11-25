using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CashAdvanceMvC.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {

            IEnumerable<MvcEmployee> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployee>>().Result;
            return View(empList);
        }

        public ActionResult CreateEmp()
        {
          
            return View();
        }
        [HttpPut]
        public ActionResult CreatePost(MvcEmployee emp)
        {
           // HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("CashAdvances", id).Result;

            return RedirectToAction("Index");
        }

        public ActionResult CashList()
        {
             IEnumerable<MMvcCashAdvance> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("AdminCashAdvances").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MMvcCashAdvance>>().Result;

           // return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
           return View(empList);
        }

    }
    
}