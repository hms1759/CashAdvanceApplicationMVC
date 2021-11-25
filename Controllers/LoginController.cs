using CashAdvanceMvC.Models;
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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Log()
        {
            return View( );
        }
        [HttpPost]
        public ActionResult LogIn(LoginModel credential)
        {
           if( String.IsNullOrEmpty(credential.Username) || String.IsNullOrEmpty(credential.Password))
            {

                credential.LOginErrorMessage = "Please fill the neccesarry field";
                return View("Log", credential);

            }

            if (credential.Username.Contains("admin") && credential.Password.Contains("microsft"))
            {
                return RedirectToAction("Admin");
            }
            using (CashAdvanceDbEntities db = new CashAdvanceDbEntities())
            {
                var check = db.DbEmployees.FirstOrDefault(x => x.Email == credential.Username && x.Phone == credential.Password);
                if (check != null)
                {


                    var hod = db.DbDepartments.FirstOrDefault(x => x.hodName == check.Name && x.Name == check.Department);
                        if (hod != null)
                        {

                        Session["HODName"] = check.Name;
                        return RedirectToAction ("Hod");
                        }



                    Session["Name"] = check.Name;
                    Session["Department"] = check.Department;

                    return RedirectToAction("Employee");
                  };

                credential.LOginErrorMessage = "User not Found";
                return View("Log", credential);
            }
           
           
        }


        public ActionResult Employee()
        {
            return RedirectToAction("AddorEdit", "CashADvance");
        }
        public ActionResult Hod()
        {
            return RedirectToAction("Index", "CashADvance");
        }

        public ActionResult Admin()
        {
            return RedirectToAction("index", "Admin");
        }
    }
}