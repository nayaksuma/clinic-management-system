using Clinic.WEB.DBConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic.WEB.Models
{
    public class PatientModel
    {
        private PatientData  _patientdata;

        public int ID { get { return _patientdata.ID; } set { _patientdata.ID = value; } }
        [Required]
        [RegularExpression("[a-zA-Z ]+$", ErrorMessage ="Use Characters only")]
        public string Name { get { return _patientdata.Name; } set { _patientdata.Name = value; } }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get { return _patientdata.DOB; } set { _patientdata.DOB = value; } }
        [Required]
        [MaxLength(10),MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^([1-9]{2})([0-9]{8})$")]
        public string Mobile { get { return _patientdata.Mobile; } set { _patientdata.Mobile = value; } }
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get { return _patientdata .Email; } set { _patientdata .Email = value; } }
        public string Address { get { return _patientdata .Address; } set { _patientdata .Address = value; } }
        public string Location { get { return _patientdata .Location; } set { _patientdata .Location = value; } }
        public string Landmark { get { return _patientdata .Landmark; } set { _patientdata .Landmark = value; } }
        public string City { get { return _patientdata .City; } set { _patientdata .City = value; } }
        public string State { get { return _patientdata .State; } set { _patientdata .State = value; } }
        [MaxLength(6),MinLength(6)]
        public string Pincode { get { return _patientdata .Pincode; } set { _patientdata .Pincode = value; } }
        [Required]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get { return _patientdata .BloodGroup ; } set { _patientdata .BloodGroup  = value; } }
        
        [Required]
        [MaxLength(14),MinLength(14)]
        [Display(Name = "Adhar No")]
        public string AdharNo { get { return _patientdata.AdharNo; } set { _patientdata.AdharNo = value; } }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get { return _patientdata .UserName; } set { _patientdata .UserName = value; } }
        [Required]
        [MaxLength(50),MinLength(5)]
        public string Password { get { return _patientdata .Password; } set { _patientdata .Password = value; } }

        public PatientData  Patientdetail { get { return _patientdata ; } }

        public PatientModel(int id, string name, DateTime dob, string mobile, string email,
            string address, string location, string landmark, string city, string state,
            string pincode, string bloodgroup, string adharno, string username, string password)
        {
            _patientdata  = new PatientData (id, name, dob, mobile, email, address, location, landmark, city,
                state, pincode,  bloodgroup , adharno , username, password);
        }
        public PatientModel ()
        {
            _patientdata = new PatientData();

        }
        public PatientModel (PatientData  patientdata)
        {
           _patientdata  = new PatientData (patientdata.ID, patientdata.Name, patientdata.DOB,patientdata.Mobile, patientdata.Email, patientdata.Address, patientdata.Location, patientdata.Landmark, patientdata.City, patientdata.State, patientdata.Pincode, patientdata.BloodGroup, patientdata.AdharNo, patientdata.UserName, patientdata.Password);           
        }

    }
}