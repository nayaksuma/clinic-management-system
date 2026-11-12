using Clinic.WEB.DBConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic.WEB.Models
{
    public class ReceptionistModel
    {
        private ReceptionistData  _receptionistdata;

        public int ID { get { return _receptionistdata .ID; } set { _receptionistdata.ID = value; } }
        [Required]
        [RegularExpression("[a-zA-Z ]+$", ErrorMessage = "Use Characters only")]
        public string Name { get { return _receptionistdata.Name; } set { _receptionistdata.Name = value; } }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get { return _receptionistdata.DOB; } set { _receptionistdata.DOB = value; } }
        [Required]
        [MaxLength(10),MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^([1-9]{2})([0-9]{8})$")]
        public string Mobile { get { return _receptionistdata.Mobile; } set { _receptionistdata.Mobile = value; } }
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get { return _receptionistdata.Email; } set { _receptionistdata.Email = value; } }
        [Required]
        public string Address { get { return _receptionistdata.Address; } set { _receptionistdata.Address = value; } }
        [Required]
        public string Location { get { return _receptionistdata.Location; } set { _receptionistdata.Location = value; } }
        [Required]
        public string Landmark { get { return _receptionistdata.Landmark; } set { _receptionistdata.Landmark = value; } }
        [Required]
        public string City { get { return _receptionistdata.City; } set { _receptionistdata.City = value; } }
        [Required]
        public string State { get { return _receptionistdata.State; } set { _receptionistdata.State = value; } }
        [Required]
        [MaxLength(6), MinLength(6)]
        public string Pincode { get { return _receptionistdata.Pincode; } set { _receptionistdata.Pincode = value; } }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get { return _receptionistdata.UserName; } set { _receptionistdata.UserName = value; } }
        [Required]
        [MaxLength(50), MinLength(5)]
        public string Password { get { return _receptionistdata.Password; } set { _receptionistdata.Password = value; } }

        public ReceptionistData  ReceptionistDetail { get { return _receptionistdata; } }

        public ReceptionistModel(int id, string name, DateTime dob, string mobile, string email,
           string address, string location, string landmark, string city, string state,
           string pincode, string username, string password)
        {
            _receptionistdata = new ReceptionistData (id, name, dob, mobile, email, address, location, landmark, city, state, pincode, username, password);
        }
        public ReceptionistModel ()
        {
            _receptionistdata = new ReceptionistData ();

        }
        public ReceptionistModel (ReceptionistData  receptiondata)
        {
            _receptionistdata = new ReceptionistData (receptiondata.ID, receptiondata.Name, receptiondata.DOB, receptiondata.Mobile, receptiondata.Email, receptiondata.Address, receptiondata.Location, receptiondata.Landmark, receptiondata.City, receptiondata.State, receptiondata.Pincode, receptiondata.UserName, receptiondata.Password);

        }
    }
}