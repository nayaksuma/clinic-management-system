using Clinic.WEB.DBConnect;
using Clinic.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.WEB.Controllers
{
    public class PrescribedTestController : Controller
    {
        // GET: PrescribedTest
        public ActionResult Index()
        {
            List<PrescribedTestModel> lstPrescribed = new List<PrescribedTestModel>();

            List<PrescribedTestData> lstprescribeddata = PrescribedTestData.ReadAll();

            if (lstprescribeddata  != null)
            {
                foreach (var test in lstprescribeddata )
                {
                    lstPrescribed .Add(new PrescribedTestModel (test.ID,test.PatientID ,test.PatientName,test.TestID ,test.TestName,test.DoctorID ,test.DoctorName,test.Fees ,test.Date ,test.Result ));
                }
            }

            return View(lstPrescribed);
        }

        // GET: PrescribedTest/Details/5
        public ActionResult Details(int id)
        {
            PrescribedTestData  prescribeddetail = PrescribedTestData .ReadById(id);
            PrescribedTestModel  prescribedmodel = new PrescribedTestModel (prescribeddetail );
            return View(prescribedmodel );
        }

        // GET: PrescribedTest/Create
        public ActionResult Create()
        {
            PrescribedTestModel  prescribed  = new PrescribedTestModel ();
            return View(prescribed );
        }

        // POST: PrescribedTest/Create
        [HttpPost]
        public ActionResult Create(PrescribedTestModel  prescribedmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    PrescribedTestData.AddNewRow(prescribedmodel.PatientID, prescribedmodel.TestID, prescribedmodel.DoctorID, prescribedmodel.Fees, prescribedmodel.Date, prescribedmodel.Result);
                    Session["Toastr"] = "Created Successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(prescribedmodel);
        }

        // GET: PrescribedTest/Edit/5
        public ActionResult Edit(int id)
        {
            PrescribedTestData  prescribeddetail = PrescribedTestData .ReadById(id);
            PrescribedTestModel  prescribedmodel = new PrescribedTestModel (prescribeddetail);
            return View(prescribedmodel );
        }

        // POST: PrescribedTest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PrescribedTestModel  prescribedtestmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    prescribedtestmodel.PrescribedDetail.UpdateRow();
                    Session["Toastr"] = "Edited Successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(prescribedtestmodel);
        }

        // GET: PrescribedTest/Delete/5
        public ActionResult Delete(int id)
        {
            PrescribedTestData  prescribeddetail = PrescribedTestData .ReadById(id);
            PrescribedTestModel  prescribedmodel = new PrescribedTestModel (prescribeddetail );
            return View(prescribedmodel );
        }

        // POST: PrescribedTest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PrescribedTestModel  prescribedtestmodel)
        {
            try
            {
                // TODO: Add delete logic here
                PrescribedTestData.DeleteRow(id);
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
