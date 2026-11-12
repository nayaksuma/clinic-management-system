using Clinic.WEB.DBConnect;
using Clinic.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.WEB.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Doctor()
        {
            List<DoctorModel> lstDoctors = new List<DoctorModel>();

            List<DoctorData> lstDoctordata = DoctorData.ReadAll();

            if (lstDoctordata != null)
            {
                foreach (var doctor in lstDoctordata)
                {
                    lstDoctors.Add(new DoctorModel(doctor.ID, doctor.Name, doctor.DOB, doctor.Mobile, doctor.Email, doctor.Address, doctor.Location, doctor.Landmark, doctor.City, doctor.State, doctor.Pincode, doctor.Qualification, doctor.Specialisation, doctor.Department, doctor.UserName, doctor.Password,doctor.Photo));

                }
            }

            return View(lstDoctors);
        }

        public ActionResult DoctorDetails(int id)
        {
            DoctorData doctordetail = DoctorData.ReadById(id);
            DoctorModel doctormodel = new DoctorModel(doctordetail);
            return View(doctormodel);
        }

        public ActionResult Patient()
        {
            List<PatientModel> LstPatients = new List<PatientModel>();
            List<PatientData> lstpatientdata;
            if (User.IsInRole("User"))
            {
                lstpatientdata = PatientData.ReadAll(Convert.ToInt32(Session["LoggedId"].ToString()));
            }
            else
            {
                lstpatientdata = PatientData.ReadAll();
            }

            if (lstpatientdata != null)
            {
                foreach (var patient in lstpatientdata)
                {
                    LstPatients.Add(new PatientModel(patient.ID, patient.Name, patient.DOB, patient.Mobile, patient.Email, patient.Address, patient.Location, patient.Landmark, patient.City, patient.State, patient.Pincode, patient.BloodGroup, patient.AdharNo, patient.UserName, patient.Password));

                }
            }

            return View(LstPatients);
        }

        public ActionResult PatientDetails(int id)
        {
            PatientData patientdetails = PatientData.ReadById(id);
            PatientModel patientmodel = new PatientModel(patientdetails);
            return View(patientmodel);
        }
    }
}