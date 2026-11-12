using System;
using System.Collections.Generic;
using Clinic.WEB.Models;
using System.Web.Mvc;
using Clinic.WEB.DBConnect;
using Clinic.WEB.Controllers;
using Clinic.WEB.ViewModel;

namespace Clinic.WEB.Controllers
{
    public class ReceptionistController : Controller
    {
        // GET: Recepationist
        public ActionResult Index()
        {
           List<ReceptionistModel > lstReceptionist = new List<ReceptionistModel >();

            List<ReceptionistData > lstReceptionistdata = ReceptionistData .ReadAll();

            if (lstReceptionistdata != null)
            {
                foreach (var recepationist in lstReceptionistdata)
                {
                    lstReceptionist.Add(new ReceptionistModel (recepationist.ID, recepationist.Name, recepationist.DOB, recepationist.Mobile, recepationist.Email, recepationist.Address, recepationist.Location, recepationist.Landmark, recepationist.City, recepationist.State, recepationist.Pincode, recepationist.UserName, recepationist.Password));

                }
            }

            return View(lstReceptionist);
        }

        // GET: Recepationist/Details/5
        public ActionResult Details(int id)
        {
            ReceptionistData receptionistdetail = ReceptionistData.ReadById(id);
            ReceptionistModel  receptionmodel = new ReceptionistModel (receptionistdetail );
            return View(receptionmodel );
        }

        // GET: Recepationist/Create
        public ActionResult Create()
        {
            ReceptionistModel  receptionist = new ReceptionistModel ();
            return View(receptionist );
        }

        // POST: Recepationist/Create
        [HttpPost]
        public ActionResult Create(ReceptionistModel  receptionistmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    ReceptionistData.AddNewRow(receptionistmodel.Name, receptionistmodel.DOB, receptionistmodel.Mobile, receptionistmodel.Email, receptionistmodel.Address, receptionistmodel.Location, receptionistmodel.Landmark, receptionistmodel.City, receptionistmodel.State, receptionistmodel.Pincode, receptionistmodel.UserName, receptionistmodel.Password);
                    Session["Toastr"] = "Created Successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(receptionistmodel);
        }

        // GET: Recepationist/Edit/5
        public ActionResult Edit(int id)
        {
            ReceptionistData  receptiondetail = ReceptionistData .ReadById(id);
            ReceptionistModel  receptionmodel = new ReceptionistModel(receptiondetail);
            return View(receptionmodel);
        }

        // POST: Recepationist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReceptionistModel  receptionistmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    receptionistmodel.ReceptionistDetail.UpdateRow();
                    Session["Toastr"] = "Edited Successfully.";
                    return RedirectToAction("Home", "Index");
                }
            }
            catch
            {
            }
            return View(receptionistmodel);
        }

        // GET: Recepationist/Delete/5
        public ActionResult Delete(int id)
        {
            ReceptionistData receptionistdetail = ReceptionistData .ReadById(id);
            ReceptionistModel receptionistmodel = new ReceptionistModel(receptionistdetail);
            return View(receptionistmodel);
        }

        // POST: Recepationist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ReceptionistModel  receptionistmodel)
        {
            try
            {
                // TODO: Add delete logic here
                ReceptionistData.DeleteRow(id);
                Session["Toastr"] = "Deleted Successfully.";
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult RejectedList()
        {
            List<DoctorVisitViewModel> lstdoctorvisit = new List<DoctorVisitViewModel>();

            List<DoctorVisitData> lstdoctorvisitdata = DoctorVisitData.ReadAllRejectedList();

            if (lstdoctorvisitdata != null)
            {
                foreach (var visit in lstdoctorvisitdata)
                {
                    lstdoctorvisit.Add(new DoctorVisitViewModel(visit.ID, visit.DoctorID, visit.DoctorName, visit.PatientID, visit.PatientName, visit.Date, visit.Symptoms, visit.Prescription, visit.Payment, visit.VisitDate, visit.Dateofbooking, visit.Status, visit.ResultDate));
                }
            }

            return View(lstdoctorvisit);
        }
        public ActionResult ReceptionistProfile()
        {
            int id = Convert.ToInt32(Session["LoggedId"].ToString());
            ReceptionistData receptiondetail = ReceptionistData.ReadById(id);
            ReceptionistModel receptionmodel = new ReceptionistModel(receptiondetail);
            return View(receptionmodel);
        }

        // POST: Recepationist/Edit/5
        [HttpPost]
        public ActionResult ReceptionistProfile(ReceptionistModel receptionistmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    receptionistmodel.ReceptionistDetail.UpdateRow();
                    Session["Toastr"] = "Your Profile is Edited.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(receptionistmodel);
        }
    }
}
