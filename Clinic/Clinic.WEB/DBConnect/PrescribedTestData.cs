using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class PrescribedTestData
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int TestID { get; set; }
        public string TestName { get; set; }    
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int Fees { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }



        public PrescribedTestData(int id, int patientid,string patientname, int testid,string testname, int doctorid,string doctorname, int fees, DateTime date, string result)
        {
            ID = id;
            PatientID = patientid;
            PatientName = patientname;
            TestID = testid;
            TestName = testname;
            DoctorID = doctorid;
            DoctorName = doctorname;
            Fees = fees;
            Date = date;
            Result = result;

        }
        public PrescribedTestData()
        {
            ID = 0;
            PatientID = 0;
            PatientName = "";
            TestID = 0;
            TestName = "";
            DoctorID = 0;
            DoctorName = "";
            Fees = 0;
            Date = DateTime.Today;
            Result = "";
        }
        public static List<PrescribedTestData> ReadAll()
        {
            List<PrescribedTestData> lstprescribed = null;
            try
            {
                lstprescribed  = PrescribedTestDbConnect.ReadAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstprescribed ;
        }
        public static List<PrescribedTestData> ReadAllPrescribeTestList(int PatientId)
        {
            List<PrescribedTestData> lstprescribed = null;
            try
            {
                lstprescribed = PrescribedTestDbConnect.ReadAllPrescribeTestList(PatientId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstprescribed;
        }
        public static PrescribedTestData ReadById(int IDvalue)
        {
            PrescribedTestData prescribeddetail = null;
            try
            {
                prescribeddetail  = PrescribedTestDbConnect .ReadById(IDvalue);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return prescribeddetail ;
        }
        public static int AddNewRow(int patientid, int testid, int doctorid, int fees, DateTime date, string result)
        {
            int count = -1;
            try
            {
                count = PrescribedTestDbConnect .AddNewRow(patientid, testid, doctorid, fees, date, result);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return count;
        }
        public static bool UpdateRow(int id, int patientid, int testid, int doctorid, int fees, DateTime date, string result)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = PrescribedTestDbConnect.UpdateRow(id, patientid, testid, doctorid, fees, date, result);
            }
            catch (Exception ex)
            {
            }
            return updateStatus;
        }
        public bool UpdateRow()
        {
            bool updateStatus = false;
            try
            {
                updateStatus = updateStatus = PrescribedTestDbConnect.UpdateRow(ID, PatientID, TestID, DoctorID, Fees, Date, Result);
            }
            catch (Exception ex)
            {
            }
            return updateStatus;
        }
        public static bool DeleteRow(int IDvalue)
        {
            bool deleteStatus = false;
            try
            {
                deleteStatus = PrescribedTestDbConnect.DeleteRow(IDvalue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteStatus;
        }
        public bool DeleteRow()
        {
            bool deleteStatus = false;
            try
            {
                deleteStatus = PrescribedTestDbConnect.DeleteRow(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteStatus;
        }
    }
}