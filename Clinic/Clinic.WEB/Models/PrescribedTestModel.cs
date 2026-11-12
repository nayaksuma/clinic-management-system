using Clinic.WEB.DBConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Clinic.WEB.Models
{
    public class PrescribedTestModel
    {
        private PrescribedTestData _prescribeddata;

        public int ID { get { return _prescribeddata.ID; } set { _prescribeddata.ID = value; } }
        public int PatientID { get { return _prescribeddata.PatientID; } set { _prescribeddata.PatientID = value; } }
        public int TestID { get { return _prescribeddata.TestID; } set { _prescribeddata.TestID = value; } }
        public int DoctorID { get { return _prescribeddata.DoctorID; } set { _prescribeddata.DoctorID = value; } }
        public int Fees { get { return _prescribeddata.Fees; } set { _prescribeddata.Fees = value; } }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get { return _prescribeddata.Date; } set { _prescribeddata.Date = value; } } 
        public string Result { get { return _prescribeddata.Result; } set { _prescribeddata.Result = value; } }

        public PrescribedTestData PrescribedDetail { get { return _prescribeddata; } }

        public PrescribedTestModel (int id, int  patientid,string patientname, int  testid,string testname, int doctorid,string doctorname, int fees,
           DateTime  date, string result)
        {
            _prescribeddata = new PrescribedTestData (id, patientid ,patientname, testid  ,testname, doctorid,doctorname, fees , date , result );
        }
        public PrescribedTestModel ()
        {
            _prescribeddata = new PrescribedTestData ();

        }
        public PrescribedTestModel (PrescribedTestData prescribedtest)
        {
            _prescribeddata = new PrescribedTestData(prescribedtest.ID,prescribedtest.PatientID,prescribedtest.PatientName,prescribedtest.TestID,prescribedtest.TestName,prescribedtest.DoctorID,prescribedtest.DoctorName,prescribedtest.Fees,prescribedtest.Date,prescribedtest.Result);
        }


    }

}
