using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class DoctorData
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
        public string Qualification { get; set; }
        public string Specialisation { get; set; }
        public string Department { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }


        public DoctorData(int id, string name, DateTime dob, string mobile, string email,
           string address, string location, string landmark, string city, string state,
           string pincode, string qualification, string specialisation,string department, string username, string password, byte[] photo)
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
            Qualification = qualification;
            Specialisation = specialisation;
            Department = department;
            UserName = username;
            Password = password;
            Photo = photo;
        }
        public DoctorData()
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
            Qualification = "";
            Specialisation = "";
            Department = "";
            UserName = "";
            Password = "";
            Photo = null;
        }
        public static List<DoctorData> ReadAll(int Id=-1)
        {
            List<DoctorData> lstDoctor = null;
            try
            {
                lstDoctor = DoctorDbConnect.ReadAll(Id,true);
            }
            catch (Exception ex)
            {
              //  throw ex;
            }
            return lstDoctor;
        }
        public static DoctorData ReadById(int IDvalue)
        {
            DoctorData doctordetail = null;
            try
            {
                doctordetail = DoctorDbConnect.ReadById(IDvalue);
            }
            catch (Exception ex)
            {
                //Handles Exception
            }
            return doctordetail;
        }


        public static int AddNewRow(string name, DateTime dob, string mobile, string email,
            string address, string location, string landmark, string city, string state, string pincode, string qualification, string specialisation,string department, string username, string password, byte[] photo)
        {
            int count = -1;
            try
            {
                count = DoctorDbConnect.AddNewRow(name, dob, mobile, email, address, location, landmark, city, state, pincode, qualification, specialisation, department, username, password, photo);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return count;
        }
        public static bool UpdateRow(int id, string name, DateTime dob, string mobile, string email,
            string address, string location, string landmark, string city, string state, string pincode, string qualification, string specialisation,string department,string username, string password, byte[] photo)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = DoctorDbConnect.UpdateRow(id, name, dob, mobile, email, address, location, landmark, city, state, pincode, qualification, specialisation, department, username, password,photo);
            }
            catch (Exception ex)
            {
                //Handle Excepation
            }
            return updateStatus;
        }
        public bool UpdateRow()
        {
            bool updateStatus = false;
            try
            {
                updateStatus = DoctorDbConnect.UpdateRow(ID, Name, DOB, Mobile, Email, Address, Location, Landmark, City, State, Pincode, Qualification, Specialisation,Department, UserName, Password,Photo);
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
                deleteStatus = DoctorDbConnect.DeleteRow(IDvalue);
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
                deleteStatus = DoctorDbConnect.DeleteRow(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteStatus;
        }

        public static DoctorData Authenticate(string username, string password)
        {
            DoctorData doctordetail = null;
            try
            {
                doctordetail = DoctorDbConnect.Authenticate(username, password);
            }
            catch (Exception ex)
            {
                //Handles Exception
            }
            return doctordetail;
        }
    }
}