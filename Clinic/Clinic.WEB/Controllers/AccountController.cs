using Clinic.WEB.DBConnect;
using Clinic.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Clinic.WEB.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            PatientModel patient = new PatientModel();
            return View(patient);
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Index(PatientModel patientmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    PatientData.AddNewRow(patientmodel.Name, patientmodel.DOB, patientmodel.Mobile, patientmodel.Email, patientmodel.Address, patientmodel.Location, patientmodel.Landmark, patientmodel.City, patientmodel.State, patientmodel.Pincode, patientmodel.BloodGroup, patientmodel.AdharNo, patientmodel.UserName, patientmodel.Password);
                    Session["Toastr"] = "Registered Successfully";
                    return RedirectToAction("Index","Home");
                }
            }
            catch
            {  
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string btnPatient, string btnDoctor, string btnReceptionist, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                String verifiedRoles = string.Empty;
                bool authenticUser = false;

                if (btnPatient != null && btnPatient.Length > 0)
                {
                    PatientData pdata = PatientData.Authenticate(model.UserName, model.Password);
                    if (pdata != null)
                    {
                        Session["LoggedId"] = pdata.ID;
                        authenticUser = true;
                    }

                    verifiedRoles = "User";
                }
                else if (btnDoctor != null && btnDoctor.Length > 0)
                {
                    {
                        DoctorData ddata = DoctorData.Authenticate(model.UserName, model.Password);
                        if (ddata != null)
                        {
                            Session["LoggedId"] = ddata.ID;
                            authenticUser = true;
                        }
                        verifiedRoles = "Doctor";
                    }
                }
                else if (btnReceptionist != null && btnReceptionist.Length > 0)
                {
                    ReceptionistData rdata = ReceptionistData.Authenticate(model.UserName, model.Password);
                    if (rdata != null)
                    {
                        Session["LoggedId"] = rdata.ID;
                        authenticUser = true;
                    }
                    verifiedRoles = "SuperAdmin";
                }

                if (authenticUser)
                {

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(2880), false, verifiedRoles, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    Response.Cookies.Add(cookie);
                    Session["Toastr"] = " You Logined";
                    return RedirectToAction("Index", "Home");

                }
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["Toastr"] = "You LogOut";
            return RedirectToAction("Index", "Home");
        }

    }
}
