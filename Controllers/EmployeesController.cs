using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CashAdvanceMvC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<MvcEmployee> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployee>>().Result;
            return View(empList);
        }

        //public ActionResult AdminIndex()
        //{
        //    IEnumerable<MvcEmployee> empList;
        //    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("AdminEmployees").Result;
        //    empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployee>>().Result;
        //    return View(empList);
        //}
        // GET: Employees
        public ActionResult AddorEdit(int id = 0)
        {
            return View(new MvcEmployee());
        }
        [HttpPost]
        public ActionResult AddorEditPost(MvcEmployee emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employees", emp).Result;

            return RedirectToAction("Index");
        }
    }
}