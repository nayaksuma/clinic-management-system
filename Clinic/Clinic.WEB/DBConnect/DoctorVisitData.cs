using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class DoctorVisitData
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime Date { get; set; }
        public string Symptoms { get; set; }
        public string Prescription { get; set; }
        public int Payment { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime Dateofbooking { get; set; }
        public string Status { get; set; }
        public DateTime ResultDate { get; set; }



        public DoctorVisitData(int id, int doctorid, string doctorname, int patientid, string patientname, DateTime date, string symptoms,
            string precripation, int payment, DateTime visitdate, DateTime dateofbooking, string status, DateTime resultDate)
        {
            ID = id;
            DoctorID = doctorid;
            DoctorName = doctorname;
            PatientID = patientid;
            PatientName = patientname;
            Date = date;
            Symptoms = symptoms;
            Prescription = precripation;
            Payment = payment;
            VisitDate = visitdate;
            Dateofbooking = dateofbooking;
            Status = status;
            ResultDate = resultDate;
        }
        public DoctorVisitData()
        {
            ID = 0;
            DoctorID = 0;
            DoctorName = "";
            PatientID = 0;
            PatientName = "";
            Date = DateTime.Today;
            Symptoms = "";
            Prescription = "";
            Payment = 0;
            VisitDate = DateTime.Today;
            Dateofbooking = DateTime.Today;
            Status = "";
            ResultDate = DateTime.Today;
        }

        public static List<DoctorVisitData> ReadAll()
        {
            List<DoctorVisitData> lstVisit = null;
            try
            {
                lstVisit = DoctorVistDbConnect.ReadAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstVisit;
        }
        public static List<DoctorVisitData> ReadAllConfirmed(int DoctorId)
        {
            List<DoctorVisitData> lstVisit = null;
            try
            {
                lstVisit = DoctorVistDbConnect.ReadAllConfirmed(DoctorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstVisit;
        }
        public static List<DoctorVisitData> ReadAllRejectedList()
        {
            List<DoctorVisitData> lstVisit = null;
            try
            {
                lstVisit = DoctorVistDbConnect.ReadAllRejectedList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstVisit;
        }
        public static List<DoctorVisitData> ReadAllAppoinment(int PatientId)
        {
            List<DoctorVisitData> lstVisit = null;
            try
            {
                lstVisit = DoctorVistDbConnect.ReadAllAppoinment(PatientId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstVisit;
        }
        public static DoctorVisitData ReadById(int IDvalue)
        {
            DoctorVisitData testdetail = null;
            try
            {
                testdetail = DoctorVistDbConnect.ReadById(IDvalue);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return testdetail;
        }
        public static int AddNewRow(int doctorid, int patientid, DateTime date, string symptoms,
            string prescripation, int payment, DateTime visitdate, DateTime dateofbooking, string status, DateTime resultdate)
        {
            int count = -1;
            try
            {
                count = DoctorVistDbConnect.AddNewRow(doctorid, patientid, date, symptoms, prescripation, payment, visitdate, dateofbooking, status, resultdate);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return count;
        }
        public static bool UpdateRow(int id, int doctorid, int patientid, DateTime date, string symptoms, string prescription, int payment, DateTime visitdate, DateTime dateofbooking, string status, DateTime resultdate)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = DoctorVistDbConnect.UpdateRow(id, doctorid, patientid, date, symptoms, prescription, payment, visitdate, dateofbooking, status, resultdate);
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
                updateStatus = DoctorVistDbConnect.UpdateRow(ID, DoctorID, PatientID, Date, Symptoms, Prescription, Payment, VisitDate, Dateofbooking, Status, ResultDate);
            }
            catch (Exception ex)
            {
            }
            return updateStatus;
        }
        public static bool ChangeStatus(int id, string status)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = DoctorVistDbConnect.ChangeStatus(id, status);
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
                deleteStatus = DoctorVistDbConnect.DeleteRow(IDvalue);
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
                deleteStatus = DoctorVistDbConnect.DeleteRow(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteStatus;
        }
    }
}

