using Clinic.WEB.DBConnect;
using Clinic.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.WEB.Controllers
{
    public class DoctorVisitController : Controller
    {
        // GET: DoctorVisit
        public ActionResult Index()
        {
            List<DoctorVisitModel> lstdoctorvisit = new List<DoctorVisitModel>();
            List<DoctorVisitData> lstdoctorvisitdata = DoctorVisitData.ReadAll();

            if (lstdoctorvisitdata != null)
            {
                foreach (var visit in lstdoctorvisitdata)
                {
                    lstdoctorvisit.Add(new DoctorVisitModel(visit.ID, visit.DoctorID, visit.DoctorName, visit.PatientID, visit.PatientName, visit.Date, visit.Symptoms, visit.Prescription, visit.Payment, visit.VisitDate, visit.Dateofbooking, visit.Status, visit.ResultDate));
                }
            }

            return View(lstdoctorvisit);
        }

        // GET: DoctorVisit/Details/5
        public ActionResult Details(int id)
        {
            DoctorVisitData doctorvisitdetails = DoctorVisitData.ReadById(id);
            DoctorVisitModel doctorvisitmodel = new DoctorVisitModel(doctorvisitdetails);
            return View(doctorvisitmodel);
        }

        // GET: DoctorVisit/Create
        public ActionResult Create()
        {
            DoctorVisitModel doctorVisit = new DoctorVisitModel();
            return View(doctorVisit);
        }

        // POST: DoctorVisit/Create
        [HttpPost]
        public ActionResult Create(DoctorVisitModel doctorvisitmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    DoctorVisitData.AddNewRow(doctorvisitmodel.DoctorID, doctorvisitmodel.PatientID, doctorvisitmodel.Date, doctorvisitmodel.Symptoms, doctorvisitmodel.Precripation, doctorvisitmodel.Payment, doctorvisitmodel.VisitDate, doctorvisitmodel.Dateofbooking, doctorvisitmodel.Status, doctorvisitmodel.ResultDate);
                    Session["Toastr"] = "Created Successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(doctorvisitmodel);
        }

        // GET: DoctorVisit/Edit/5
        public ActionResult Edit(int id)
        {
            DoctorVisitData doctorvisitdetails = DoctorVisitData.ReadById(id);
            DoctorVisitModel doctorvisitmodel = new DoctorVisitModel(doctorvisitdetails);
            return View(doctorvisitmodel);
        }

        // POST: DoctorVisit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DoctorVisitModel doctorvisitmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    doctorvisitmodel.doctorvisitdetails.UpdateRow();
                    Session["Toastr"] = "Edited Successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(doctorvisitmodel);
        }


        [HttpPost]
        public ActionResult ChangeStatus(int id, string status)
        {
            try
            {
                // TODO: Add insert logic here
                DoctorVisitData.ChangeStatus(id, status);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("ConfirmDocotorVisit", "Patient");
            }
        }
        // GET: DoctorVisit/Delete/5
        public ActionResult Delete(int id)
        {
            DoctorVisitData Doctorvisitdetails = DoctorVisitData.ReadById(id);
            DoctorVisitModel doctorvisitmodel = new DoctorVisitModel(Doctorvisitdetails);
            return View(doctorvisitmodel);
        }

        // POST: DoctorVisit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DoctorVisitModel doctormodel)
        {
            try
            {
                // TODO: Add delete logic here
                DoctorVisitData.DeleteRow(id);
                Session["Toastr"] = "Deleted Successfully.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
