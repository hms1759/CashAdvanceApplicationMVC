using CashAdvanceMvC.Models.LogEntity;
using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CashAdvanceMvC.Controllers
{
    public class CashADvanceController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<MMvcCashAdvance> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CashAdvances").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MMvcCashAdvance>>().Result;

           // return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
           return View(empList);
        }
        // GET: Employees
        public ActionResult AddorEdit(int id=0)
        {
            if(id==0)
            {
              
            return View(new MMvcCashAdvance());
            }

            using(CashAdvanceDbEntities db = new CashAdvanceDbEntities())
            {

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("CashAdvances/" + id.ToString()).Result;
            var res = response.Content.ReadAsAsync<MMvcCashAdvance>().Result;
            res.approvedBY = Session["HODName"].ToString();


            var empl = db.DbEmployees.FirstOrDefault(x=> x.Name == res.requestBy);
                res.Employee_Id = empl.Id;


            HttpResponseMessage result = GlobalVariables.WebApiClient.PutAsJsonAsync("CashAdvances/"+ res.Id, res).Result;

            }

            //  HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("CashAdvances", id).Result;
         //   HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CashAdvances", res).Result;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddorEditPost(MMvcCashAdvance emp)
        {
            var amount = Convert.ToInt32(emp.amount);
            
            if (emp.Id> 0)
            {
               
                _= GlobalVariables.WebApiClient.PutAsJsonAsync("CashAdvances", emp).Result;

                return View("Index");

            }
            if(amount < 50001)
            {

                emp.department = Session["Department"].ToString();
                emp.requestBy = Session["Name"].ToString();

                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("CashAdvances", emp).Result;

        
                emp.LOginErrorMessage = "Request Successfully Submitted";
           

                    ViewBag.message = "RequesT Successfully Submitted";
                    return View("Successfull", emp);

            }
            else
            {

                emp.LOginErrorMessage = "Your Limitation has been Exceeded";


                return View("AddorEdit", emp);
            }
           
        }
        public ActionResult Successfull()
        {
            return View();
        }
        [HttpPut]
        public ActionResult Approve
        (MMvcCashAdvance emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("CashAdvances", emp).Result;
            // var res = response.Content.ReadAsAsync<MMvcCashAdvance>().Result;
            return RedirectToAction("Index");
        }
    }

       
    
}