using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class PatientData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string BloodGroup { get; set; }
        public string AdharNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public PatientData(int id, string name, DateTime dob, string mobile, string email,
            string address, string location, string landmark, string city, string state,
            string pincode, string bloodgroup, string adharno, string username, string password)
        {
            ID = id;
            Name = name;
            DOB = dob;
            Mobile = mobile;
            Email = email;
            Address = address;
            Location = location;
            Landmark = landmark;
            City = city;
            State = state;
            Pincode = pincode;
            BloodGroup = bloodgroup;
            AdharNo = adharno;
            UserName = username;
            Password = password;
        }


        public PatientData()
        {
            ID = 0;
            Name = "";
            DOB = DateTime.Today;
            Mobile = "";
            Email = "";
            Address = "";
            Location = "";
            Landmark = "";
            City = "";
            State = "";
            Pincode = "";
            BloodGroup = "";
            AdharNo = "";
            UserName = "";
            Password = "";
        }
        public static List<PatientData> ReadAll(int Id = -1)
        {
            List<PatientData> lstPatient = null;
            try
            {
                lstPatient = PatientDbConnect.ReadAll(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPatient;
        }
        public static PatientData ReadById(int IDvalue)
        {
            PatientData patientdetail = null;
            try
            {
                patientdetail = PatientDbConnect.ReadById(IDvalue);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return patientdetail;
        }
        public static int AddNewRow(string name, DateTime dob, string mobile, string email,
            string address, string location, string landmark, string city, string state, string pincode, string bloodgroup, string adharno, string username, string password)
        {
            int count = -1;
            try
            {
                count = PatientDbConnect.AddNewRow(name, dob, mobile, email, address, location, landmark, city, state, pincode, bloodgroup, adharno, username, password);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return count;
        }
        public static bool UpdateRow(int id, string name, DateTime dob, string mobile, string email,
            string address, string location, string landmark, string city, string state, string pincode, string bloodgroup, string adharno, string username, string password)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = PatientDbConnect.UpdateRow(id, name, dob, mobile, email, address, location, landmark, city, state, pincode, bloodgroup, adharno, username, password);
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
                updateStatus = updateStatus = PatientDbConnect.UpdateRow(ID, Name, DOB, Mobile, Email, Address, Location, Landmark, City, State, Pincode, BloodGroup, AdharNo, UserName, Password);
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
                deleteStatus = PatientDbConnect.DeleteRow(IDvalue);
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
                deleteStatus = PatientDbConnect.DeleteRow(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteStatus;
        }
        public static PatientData Authenticate(string username, string password)
        {
            PatientData patientdetails = null;
            try
            {
                patientdetails = PatientDbConnect.Authenticate(username, password);
            }
            catch (Exception ex)
            {
                //Handles Exception
            }
            return patientdetails;
        }



    }
}