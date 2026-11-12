using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Clinic.WEB.DBConnect;

namespace Clinic.WEB.Models
{
    public class DoctorModel
    {
        private DoctorData _doctorData;

        public int ID { get { return _doctorData.ID; } set { _doctorData.ID = value; } }
        [Required]
        [RegularExpression("[a-zA-Z ]+$", ErrorMessage = "Use Characters only")]
        public string Name { get { return _doctorData.Name; } set { _doctorData.Name = value; } }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get { return _doctorData.DOB; } set { _doctorData.DOB = value; } }
        [Required]
        //[RegularExpression]
        [MaxLength(10),MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^([1-9]{1})([0-9]{9})$")]
        public string Mobile { get { return _doctorData.Mobile; } set { _doctorData.Mobile = value; } }
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get { return _doctorData.Email; } set { _doctorData.Email = value; } }
        [Required]
        
        public string Address { get { return _doctorData.Address; } set { _doctorData.Address = value; } }
        public string Location { get { return _doctorData.Location; } set { _doctorData.Location = value; } }
        public string Landmark { get { return _doctorData.Landmark; } set { _doctorData.Landmark = value; } }
        public string City { get { return _doctorData.City; } set { _doctorData.City = value; } }
        public string State { get { return _doctorData.State; } set { _doctorData.State = value; } }
        [MaxLength(6), MinLength(6)]
        public string Pincode { get { return _doctorData.Pincode; } set { _doctorData.Pincode = value; }}
        [Required]
        public string Qualification { get { return _doctorData.Qualification; } set { _doctorData.Qualification = value; } }
        [Required]
        public string Specialisation { get { return _doctorData.Specialisation; } set { _doctorData.Specialisation = value; } }
        [Required]
        public string Department { get { return _doctorData.Department; } set { _doctorData.Department = value; } }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get { return _doctorData.UserName; } set { _doctorData.UserName = value; } }
        [Required]
        [MaxLength(50),MinLength(5)]
        public string Password { get { return _doctorData.Password; } set { _doctorData.Password = value; } }
        public byte[] Photo
        {
            get {return _doctorData.Photo; }
            set { _doctorData.Photo = value; }
        }
        public DoctorData DoctorDetail { get { return _doctorData; } }

        public DoctorModel(int id, string name, DateTime dob, string mobile, string email,
           string address, string location, string landmark, string city, string state,
           string pincode, string qualification, string specialisation, string department, string username, string password, byte[] photo)
        {
            _doctorData = new DoctorData(id, name, dob, mobile, email, address, location, landmark, city, state, pincode, qualification, specialisation, department, username, password,photo);
            Photo = photo;
        }
        public DoctorModel()
        {
            _doctorData = new DoctorData();
           
        }
        public DoctorModel(DoctorData doctordata)
        {
            _doctorData = new DoctorData(doctordata.ID, doctordata.Name, doctordata.DOB, doctordata.Mobile, doctordata.Email, doctordata.Address, doctordata.Location, doctordata.Landmark, doctordata.City, doctordata.State, doctordata.Pincode, doctordata.Qualification, doctordata.Specialisation, doctordata.Department, doctordata.UserName, doctordata.Password, doctordata.Photo);

        }


    }
}