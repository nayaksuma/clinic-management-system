using Clinic.WEB.DBConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic.WEB.ViewModel
{
    public class PrescribedTestForDoctorViewModel
    {
        private PrescribedTestData _prescribeddata;

        private List<LabTestData> lstLabTest;

        //public List<DoctorData> DoctorsList { get { return lstDoctors; } }
        //public List<PatientData> PatientsList { get { return lstPatients; } }
        public List<LabTestData> LabList { get { return lstLabTest; } }

        public int ID { get { return _prescribeddata.ID; } set { _prescribeddata.ID = value; } }
        public int PatientID { get { return _prescribeddata.PatientID; } set { _prescribeddata.PatientID = value; } }
        public int TestID { get { return _prescribeddata.TestID; } set { _prescribeddata.TestID = value; } }
        public int DoctorID { get { return _prescribeddata.DoctorID; } set { _prescribeddata.DoctorID = value; } }
        public int Fees { get { return _prescribeddata.Fees; } set { _prescribeddata.Fees = value; } }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get { return _prescribeddata.Date; } set { _prescribeddata.Date = value; } }
        public string Result { get { return _prescribeddata.Result; } set { _prescribeddata.Result = value; } }

        public PrescribedTestData PrescribedDetail { get { return _prescribeddata; } }


        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public PrescribedTestForDoctorViewModel(int id, int patientid, string patientname, int testid, string testname, int doctorid, string doctorname, int fees,
           DateTime date, string result)
        {
            _prescribeddata = new PrescribedTestData(id, patientid, patientname, testid, testname, doctorid, doctorname, fees, date, result);
            //lstDoctors = DoctorData.ReadAll();
            //lstPatients = PatientData.ReadAll();
            lstLabTest = LabTestData.ReadAll();
        }
        public PrescribedTestForDoctorViewModel()
        {
            _prescribeddata = new PrescribedTestData();
            //lstDoctors = DoctorData.ReadAll();
            //lstPatients = PatientData.ReadAll();
            lstLabTest = LabTestData.ReadAll();

        }
        public PrescribedTestForDoctorViewModel(PrescribedTestData prescribedtest)
        {
            _prescribeddata = new PrescribedTestData(prescribedtest.ID, prescribedtest.PatientID, prescribedtest.PatientName, prescribedtest.TestID, prescribedtest.TestName, prescribedtest.DoctorID, prescribedtest.DoctorName, prescribedtest.Fees, prescribedtest.Date, prescribedtest.Result);
            //lstDoctors = DoctorData.ReadAll();
            //lstPatients = PatientData.ReadAll();
            lstLabTest = LabTestData.ReadAll();

        }

    }
}