using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CashAdvanceMvC.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments

        public ActionResult Index()
        {
            IEnumerable<MvcDepartment> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Departments").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcDepartment>>().Result;
            return View(empList);
        }
        // Creat: Departments
        public ActionResult AddorEdit(int id = 0)
        {
            return View(new MvcDepartment());
        }
        [HttpPost]
        public ActionResult AddorEditPost(MvcDepartment dpt)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Departments", dpt).Result;

            return RedirectToAction("Index");
        }
    }
}

