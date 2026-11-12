using Clinic.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic.WEB.DBConnect;
using Clinic.WEB.Controllers;

namespace Clinic.WEB.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            List<DoctorModel> lstDoctors = new List<DoctorModel>();
            List<DoctorData> lstDoctordata;
            if (User.IsInRole("SuperAdmin"))
            {
                 lstDoctordata = DoctorData.ReadAll();

            }
            else
            {
                lstDoctordata = DoctorData.ReadAll(Convert.ToInt32(Session["LoggedId"].ToString()));
            }
           

            if (lstDoctordata != null)
            {
                foreach (var doctor in lstDoctordata)
                {
                    lstDoctors.Add(new DoctorModel(doctor.ID, doctor.Name, doctor.DOB, doctor.Mobile, doctor.Email, doctor.Address, doctor.Location, doctor.Landmark, doctor.City, doctor.State, doctor.Pincode, doctor.Qualification, doctor.Specialisation, doctor.Department, doctor.UserName, doctor.Password,doctor.Photo));

                }
            }

            return View(lstDoctors);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            DoctorData doctordetail = DoctorData.ReadById(id);
            DoctorModel doctormodel = new DoctorModel(doctordetail);
            return View(doctormodel );
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            DoctorModel doctor = new DoctorModel();
            return View(doctor);
        }

        // POST: Doctor/Create
        [HttpPost]

        public ActionResult Create(DoctorModel doctormodel, HttpPostedFileBase doctorPhoto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (doctorPhoto != null)
                    {
                        System.IO.Stream fs = doctorPhoto.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                        doctormodel.Photo = br.ReadBytes((Int32)fs.Length);
                    }
                    int newIdValue = DoctorData.AddNewRow(doctormodel.Name, doctormodel.DOB, doctormodel.Mobile, doctormodel.Email, doctormodel.Address, doctormodel.Location, doctormodel.Landmark, doctormodel.City, doctormodel.State, doctormodel.Pincode, doctormodel.Qualification, doctormodel.Specialisation, doctormodel.Department, doctormodel.UserName, doctormodel.Password, doctormodel.Photo);
                    if (newIdValue > 0)
                    {
                        Session["Toastr"] = "Created Successfully";
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
            }
            return View(doctormodel);
        }


       

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)

        {
            DoctorData doctordetails = DoctorData.ReadById(id);
            DoctorModel doctorModel  = new DoctorModel(doctordetails );
            return View(doctorModel);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(/*int id,*/ DoctorModel doctormodel, HttpPostedFileBase doctorPhoto)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    if (doctorPhoto != null)
                    {
                        System.IO.Stream fs = doctorPhoto.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                        doctormodel.Photo = br.ReadBytes((Int32)fs.Length);
                    }
                    bool updateStatus = DoctorData.UpdateRow(doctormodel.ID, doctormodel.Name, doctormodel.DOB, doctormodel.Mobile, doctormodel.Email, doctormodel.Address, doctormodel.Location, doctormodel.Landmark, doctormodel.City, doctormodel.State, doctormodel.Pincode, doctormodel.Qualification, doctormodel.Specialisation, doctormodel.Department, doctormodel.UserName, doctormodel.Password, doctormodel.Photo);
                    if (updateStatus)
                    {
                        Session["Toastr"] = "Edited Successfully";
                        return RedirectToAction("Index");
                    }
                }
               
            }
            catch
            {
            }
            return View(doctormodel);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            DoctorData doctordetail = DoctorData.ReadById(id);
            DoctorModel doctorModel  = new DoctorModel(doctordetail );
            return View(doctorModel );
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DoctorModel  doctormodel)
        {
            try
            {
                // TODO: Add delete logic here
                DoctorData.DeleteRow(id);
                Session["Toastr"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DoctorProfile()
        {
            int id = Convert.ToInt32(Session["LoggedId"].ToString());
            DoctorData doctordetails = DoctorData.ReadById(id);
            DoctorModel doctorModel = new DoctorModel(doctordetails);
            return View(doctorModel);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult DoctorProfile(/*int id,*/ DoctorModel doctormodel, HttpPostedFileBase doctorPhoto)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    if (doctorPhoto != null)
                    {
                        System.IO.Stream fs = doctorPhoto.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                        doctormodel.Photo = br.ReadBytes((Int32)fs.Length);
                    }
                    bool updateStatus = DoctorData.UpdateRow(doctormodel.ID, doctormodel.Name, doctormodel.DOB, doctormodel.Mobile, doctormodel.Email, doctormodel.Address, doctormodel.Location, doctormodel.Landmark, doctormodel.City, doctormodel.State, doctormodel.Pincode, doctormodel.Qualification, doctormodel.Specialisation, doctormodel.Department, doctormodel.UserName, doctormodel.Password, doctormodel.Photo);
                    if (updateStatus)
                    {
                        Session["Toastr"] = " Your Profile is Edited";
                        return RedirectToAction("Index");
                    }
                }
                doctormodel.DoctorDetail.UpdateRow();
                return RedirectToAction("Home","Index");
            }
            catch
            {
            }
            return View(doctormodel);
        }
    }
}
