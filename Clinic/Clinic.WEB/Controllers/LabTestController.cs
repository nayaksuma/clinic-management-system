using Clinic.WEB.DBConnect;
using Clinic.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.WEB.Controllers
{
    public class LabTestController : Controller
    {
        // GET: labTest
        public ActionResult Index()
        {
            List<LabTestModel> lstlabtest = new List<LabTestModel>();

            List<LabTestData> lstlabtestdata = LabTestData.ReadAll();

            if (lstlabtestdata != null)
            {
                foreach (var test in lstlabtestdata)
                {
                    lstlabtest.Add(new LabTestModel(test.ID, test.Name, test.TestName, test.InhouseTest, test.Fees));
                }
            }

            return View(lstlabtest);
        }

        // GET: labTest/Details/5
        public ActionResult Details(int id)
        {
            LabTestData labtestdetails = LabTestData.ReadById(id);
            LabTestModel labtestmodel = new LabTestModel(labtestdetails);
            return View(labtestmodel);
        }

        // GET: labTest/Create
        public ActionResult Create()
        {
            LabTestModel labtest = new LabTestModel();
            return View(labtest);
        }

        // POST: labTest/Create
        [HttpPost]
        public ActionResult Create(LabTestModel labtestmodel)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    LabTestData.AddNewRow(labtestmodel.Name, labtestmodel.TestName, labtestmodel.InhouseTest, labtestmodel.Fees);
                    Session["Toastr"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(labtestmodel); 
        }

        // GET: labTest/Edit/5
        public ActionResult Edit(int id)
        {

            LabTestData  labtestdetails = LabTestData.ReadById(id);
            LabTestModel  labtestmodel = new LabTestModel(labtestdetails);
            return View(labtestmodel);
        }

        // POST: labTest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LabTestModel labtestmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    labtestmodel.labtestdetails.UpdateRow();
                    Session["Toastr"] = "Edited Successfully";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(labtestmodel);

        }

        // GET: labTest/Delete/5
        public ActionResult Delete(int id)
        {
            LabTestData  labtestdetails = LabTestData.ReadById(id);
            LabTestModel  labtestmodel = new LabTestModel(labtestdetails);
            return View(labtestmodel);
        }

        // POST: labTest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LabTestModel labtestmodel)
        {
            try
            {
                // TODO: Add delete logic here
                LabTestData .DeleteRow(id);
                Session["Toastr"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
