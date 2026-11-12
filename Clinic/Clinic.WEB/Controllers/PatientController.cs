using Clinic.WEB.DBConnect;
using Clinic.WEB.Models;
using Clinic.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.WEB.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            List<PatientModel> LstPatients = new List<PatientModel>();
            List<PatientData> lstpatientdata;
            if (User.IsInRole("SuperAdmin"))
            {
                lstpatientdata = PatientData.ReadAll();
            }
            else
            {
                lstpatientdata = PatientData.ReadAll(Convert.ToInt32(Session["LoggedId"].ToString()));
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

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            PatientData patientdetails = PatientData.ReadById(id);
            PatientModel patientmodel = new PatientModel(patientdetails);
            return View(patientmodel);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            PatientModel patient = new PatientModel();
            return View(patient);
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(PatientModel patientmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    PatientData.AddNewRow(patientmodel.Name, patientmodel.DOB, patientmodel.Mobile, patientmodel.Email, patientmodel.Address, patientmodel.Location, patientmodel.Landmark, patientmodel.City, patientmodel.State, patientmodel.Pincode, patientmodel.BloodGroup, patientmodel.AdharNo, patientmodel.UserName, patientmodel.Password);
                    Session["Toastr"] = "Created Successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(patientmodel);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            PatientData patientdetails = PatientData.ReadById(id);
            PatientModel patientmodel = new PatientModel(patientdetails);
            return View(patientmodel);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PatientModel patientmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    patientmodel.Patientdetail.UpdateRow();
                    Session["Toastr"] = "Edited Successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(patientmodel);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            PatientData patientdetails = PatientData.ReadById(id);
            PatientModel patientmodel = new PatientModel(patientdetails);
            return View(patientmodel);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PatientModel patientmodel)
        {
            try
            {
                // TODO: Add delete logic here
                PatientData.DeleteRow(id);
                Session["Toastr"] = "Deleted Successfully.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DoctorVisit()
        {
            DoctorVisitViewModel doctorVisit = new DoctorVisitViewModel();
            doctorVisit.PatientID = Convert.ToInt32(Session["LoggedId"].ToString());
            return View(doctorVisit);
        }

        // POST: DoctorVisit/Create
        [HttpPost]
        public ActionResult DoctorVisit(DoctorVisitViewModel doctorvisitmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (doctorvisitmodel.Dateofbooking <= DateTime.Today)
                    {
                        ModelState.AddModelError("", "Can't book for selected Booking Date");
                        return View(doctorvisitmodel);
                    }
                }
                // TODO: Add insert logic here
                doctorvisitmodel.Precripation = "";
                doctorvisitmodel.Payment = 0;
                doctorvisitmodel.Status = "";
                doctorvisitmodel.ResultDate = DateTime.Today;
                doctorvisitmodel.PatientID = Convert.ToInt32(Session["LoggedId"].ToString());
                DoctorVisitData.AddNewRow(doctorvisitmodel.DoctorID, doctorvisitmodel.PatientID, doctorvisitmodel.Date, doctorvisitmodel.Symptoms, doctorvisitmodel.Precripation, doctorvisitmodel.Payment, doctorvisitmodel.VisitDate, doctorvisitmodel.Dateofbooking, doctorvisitmodel.Status, doctorvisitmodel.ResultDate);
                Session["Toastr"] = "Appoinment Booked.";
                return RedirectToAction("Index", "Home");
            }

            catch
            {
                DoctorVisitViewModel doctorVisit = new DoctorVisitViewModel(doctorvisitmodel.Doctorvisitdetails);
                return View(doctorVisit);
            }
        }

        public ActionResult DoctorVisitEntry()
        {
            int did = 0;
            if (Session["LoggedId"] != null)
                did = Convert.ToInt32(Session["LoggedId"].ToString());
            List<DoctorVisitViewModel> lstdoctorvisit = new List<DoctorVisitViewModel>();

            List<DoctorVisitData> lstdoctorvisitdata = DoctorVisitData.ReadAllConfirmed(did);

            if (lstdoctorvisitdata != null)
            {
                foreach (var visit in lstdoctorvisitdata)
                {
                    lstdoctorvisit.Add(new DoctorVisitViewModel(visit.ID, visit.DoctorID, visit.DoctorName, visit.PatientID, visit.PatientName, visit.Date, visit.Symptoms, visit.Prescription, visit.Payment, visit.VisitDate, visit.Dateofbooking, visit.Status, visit.ResultDate));
                }
            }

            return View(lstdoctorvisit);
        }

        // POST: DoctorVisit/Edit/5
        [HttpPost]
        public ActionResult DoctorVisitEntry(int id, DoctorVisitModel doctorvisitmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    doctorvisitmodel.doctorvisitdetails.UpdateRow();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(doctorvisitmodel);
        }


        public ActionResult ConfirmDoctorVisit()
        {
            int did;
            if (Session["LoggedId"] != null)
                did = Convert.ToInt32(Session["LoggedId"].ToString());
            List<DoctorVisitViewModel> lstdoctorvisit = new List<DoctorVisitViewModel>();

            List<DoctorVisitData> lstdoctorvisitdata = DoctorVisitData.ReadAll();

            if (lstdoctorvisitdata != null)
            {
                foreach (var visit in lstdoctorvisitdata)
                {
                    lstdoctorvisit.Add(new DoctorVisitViewModel(visit.ID, visit.DoctorID, visit.DoctorName, visit.PatientID, visit.PatientName, visit.Date, visit.Symptoms, visit.Prescription, visit.Payment, visit.VisitDate, visit.Dateofbooking, visit.Status, visit.ResultDate));
                }
            }

            return View(lstdoctorvisit);
        }
        public ActionResult DoctorVisitEntryEdit(int id)
        {
            DoctorVisitData doctorvisitdetails = DoctorVisitData.ReadById(id);
            DoctorVisitForDoctorViewModel doctorvisitmodel = new DoctorVisitForDoctorViewModel(doctorvisitdetails);
            //return View(doctorvisitmodel);
            DoctorVisitData dv = DoctorVisitData.ReadById(id);

            //PrescribedTestForDoctorViewModel prescribedtest = new PrescribedTestForDoctorViewModel();

            doctorvisitmodel.DoctorID = dv.DoctorID;

            doctorvisitmodel.PatientID = dv.PatientID;
            doctorvisitmodel.DoctorName = User.Identity.Name;

            PatientData pd = PatientData.ReadById(dv.PatientID);
            doctorvisitmodel.PatientName = pd.Name;
            return View(doctorvisitmodel);
        }

        // POST: DoctorVisit/Edit/5
        [HttpPost]
        public ActionResult DoctorVisitEntryEdit(int id, DoctorVisitViewModel doctorvisitmodel)
        {
            try
            {
                // TODO: Add update logic here
                doctorvisitmodel.Doctorvisitdetails.UpdateRow();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PrescribedTest(int id)
        {
            DoctorVisitData dv = DoctorVisitData.ReadById(id);

            PrescribedTestForDoctorViewModel prescribedtest = new PrescribedTestForDoctorViewModel();

            prescribedtest.DoctorID = dv.DoctorID;

            prescribedtest.PatientID = dv.PatientID;
            prescribedtest.DoctorName = User.Identity.Name;

            PatientData pd = PatientData.ReadById(dv.PatientID);
            prescribedtest.PatientName = pd.Name;
            return View(prescribedtest);
        }

        // POST: PrescribedTest/Create
        [HttpPost]
        public ActionResult PrescribedTest(PrescribedTestModel prescribedmodel)
        {
            try
            {
                // TODO: Add insert logic here
                PrescribedTestData.AddNewRow(prescribedmodel.PatientID, prescribedmodel.TestID, prescribedmodel.DoctorID, prescribedmodel.Fees, prescribedmodel.Date, prescribedmodel.Result);
                Session["Toastr"] = "Report Generated";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                PrescribedTestViewModel prescribedTest = new PrescribedTestViewModel(prescribedmodel.PrescribedDetail);
                return View(prescribedTest);
            }
        }
        public ActionResult PrescribeTestList()
        {
            int pid = 0;
            if (Session["LoggedId"] != null)
                pid = Convert.ToInt32(Session["LoggedId"].ToString());
            List<PrescribedTestViewModel> lstPrescribed = new List<PrescribedTestViewModel>();

            List<PrescribedTestData> lstprescribeddata = PrescribedTestData.ReadAllPrescribeTestList(pid);

            if (lstprescribeddata != null)
            {
                foreach (var test in lstprescribeddata)
                {
                    lstPrescribed.Add(new PrescribedTestViewModel(test.ID, test.PatientID, test.PatientName, test.TestID, test.TestName, test.DoctorID, test.DoctorName, test.Fees, test.Date, test.Result));
                }
            }

            return View(lstPrescribed);
        }


        public ActionResult PrescribedTestDetails(int id)
        {
            PrescribedTestData prescribeddetail = PrescribedTestData.ReadById(id);
            PrescribedTestViewModel prescribedmodel = new PrescribedTestViewModel(prescribeddetail);
            return View(prescribedmodel);
        }
        public ActionResult PatientProfile()
        {
            int id = Convert.ToInt32(Session["LoggedId"].ToString());
            PatientData patientdetails = PatientData.ReadById(id);
            PatientModel patientmodel = new PatientModel(patientdetails);
            return View(patientmodel);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult PatientProfile(PatientModel patientmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    patientmodel.Patientdetail.UpdateRow();
                    Session["Toastr"] = "Your Profile is Edited.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(patientmodel);
        }
        public ActionResult Appoinment()
        {
            int pid = 0;
            if (Session["LoggedId"] != null)
                pid = Convert.ToInt32(Session["LoggedId"].ToString());
            List<DoctorVisitViewModel> lstdoctorvisit = new List<DoctorVisitViewModel>();

            List<DoctorVisitData> lstdoctorvisitdata = DoctorVisitData.ReadAllAppoinment(pid);

            if (lstdoctorvisitdata != null)
            {
                foreach (var visit in lstdoctorvisitdata)
                {
                    lstdoctorvisit.Add(new DoctorVisitViewModel(visit.ID, visit.DoctorID, visit.DoctorName, visit.PatientID, visit.PatientName, visit.Date, visit.Symptoms, visit.Prescription, visit.Payment, visit.VisitDate, visit.Dateofbooking, visit.Status, visit.ResultDate));
                }
            }

            return View(lstdoctorvisit);
        }

    }
}