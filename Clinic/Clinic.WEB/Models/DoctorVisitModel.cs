using Clinic.WEB.DBConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic.WEB.Models
{
    public class DoctorVisitModel
    {
        private DoctorVisitData _doctorVisitData;

        public int ID { get { return _doctorVisitData.ID; } set { _doctorVisitData.ID = value; } }
        public int DoctorID { get { return _doctorVisitData.DoctorID; } set { _doctorVisitData.DoctorID = value; } }
        public int PatientID { get { return _doctorVisitData.PatientID; } set { _doctorVisitData.PatientID = value; } }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get { return _doctorVisitData.Date; } set { _doctorVisitData.Date = value; } }
        public string Symptoms { get { return _doctorVisitData.Symptoms; } set { _doctorVisitData.Symptoms = value; } }
        public string Precripation { get { return _doctorVisitData.Prescription; } set { _doctorVisitData.Prescription = value; } }
        public int Payment { get { return _doctorVisitData.Payment; } set { _doctorVisitData.Payment = value; } }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime VisitDate { get { return _doctorVisitData.VisitDate; } set { _doctorVisitData.VisitDate = value; } }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dateofbooking { get { return _doctorVisitData.Dateofbooking; } set { _doctorVisitData.Dateofbooking = value; } }
        public string Status { get { return _doctorVisitData.Status; } set { _doctorVisitData.Status = value; } }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next Visit")]
        public DateTime ResultDate { get { return _doctorVisitData.ResultDate; } set { _doctorVisitData.ResultDate = value; } }
        public DoctorVisitData doctorvisitdetails { get { return _doctorVisitData; } }


        public DoctorVisitModel(int id, int doctorid, string doctorname,int patientid, string patientname, DateTime date, string symptoms,
            string precripation, int payment, DateTime visitdate, DateTime dateofbooking, string status, DateTime resultDate)
        {

            _doctorVisitData = new DoctorVisitData(id, doctorid, doctorname, patientid, patientname, date, symptoms, precripation, payment, visitdate, dateofbooking, status,resultDate);
        }
        public DoctorVisitModel()
        {
            _doctorVisitData = new DoctorVisitData();

        }
        public DoctorVisitModel(DoctorVisitData doctorvisitdata)
        {
            _doctorVisitData = new DoctorVisitData(doctorvisitdata.ID, doctorvisitdata.DoctorID, doctorvisitdata.DoctorName, doctorvisitdata.PatientID, doctorvisitdata.PatientName , doctorvisitdata.Date, doctorvisitdata.Symptoms, doctorvisitdata.Prescription, doctorvisitdata.Payment,doctorvisitdata.VisitDate,doctorvisitdata.Dateofbooking,doctorvisitdata.Status, doctorvisitdata.ResultDate);
        }
    }
}