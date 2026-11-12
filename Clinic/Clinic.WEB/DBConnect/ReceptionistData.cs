using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class ReceptionistData
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
        public string UserName { get; set; }
        public string Password { get; set; }

        public ReceptionistData(int id, string name, DateTime dob, string mobile, string email,
           string address, string location, string landmark, string city, string state,
           string pincode, string username, string password)
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
            UserName = username;
            Password = password;
        }
        public ReceptionistData()
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
            UserName = "";
            Password = "";
        }
        public static List<ReceptionistData> ReadAll()
        {
            List<ReceptionistData> lstReceptionist = null;
            try
            {
                lstReceptionist = ReceptionistDbConnect.ReadAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReceptionist;
        }
        public static ReceptionistData ReadById(int IDvalue)
        {
            ReceptionistData receptionistDetail = null;
            try
            {
                receptionistDetail = ReceptionistDbConnect .ReadById(IDvalue);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return receptionistDetail;
        }
        public static int AddNewRow(string name, DateTime dob, string mobile, string email,
            string address, string location, string landmark, string city, string state, string pincode, string username, string password)
        {
            int count = -1;
            try
            {
                count = ReceptionistDbConnect.AddNewRow(name, dob, mobile, email, address, location, landmark, city, state, pincode,  username, password);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return count;
        }
        public static bool UpdateRow(int id, string name, DateTime dob, string mobile, string email,
            string address, string location, string landmark, string city, string state, string pincode,  string username, string password)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = ReceptionistDbConnect.UpdateRow(id, name, dob, mobile, email, address, location, landmark, city, state, pincode, username, password);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return updateStatus;
        }
        public bool UpdateRow()
        {
            bool updateStatus = false;
            try
            {
                updateStatus = updateStatus = ReceptionistDbConnect.UpdateRow(ID, Name, DOB, Mobile, Email, Address, Location, Landmark, City, State, Pincode, UserName, Password);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return updateStatus;
        }
        public static bool DeleteRow(int IDvalue)
        {
            bool deleteStatus = false;
            try
            {
                deleteStatus = ReceptionistDbConnect.DeleteRow(IDvalue);
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
                deleteStatus = ReceptionistDbConnect.DeleteRow(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteStatus;
        }
        public static ReceptionistData  Authenticate(string username, string password)
        {
            ReceptionistData  receptionistdetails = null;
            try
            {
                receptionistdetails = ReceptionistDbConnect.Authenticate(username, password);
            }
            catch (Exception ex)
            {
                //Handles Exception
            }
            return receptionistdetails;
        }
    }
}