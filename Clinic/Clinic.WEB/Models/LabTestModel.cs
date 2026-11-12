using Clinic.WEB.DBConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic.WEB.Models
{
    public class LabTestModel
    {
        private LabTestData _labtestdata;

        public int ID { get { return _labtestdata.ID; } set { _labtestdata.ID = value; } }
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string Name { get { return _labtestdata.Name; } set { _labtestdata.Name = value; } }
        public string TestName { get { return _labtestdata.TestName ; } set { _labtestdata.TestName = value; } }
        public Boolean  InhouseTest { get { return _labtestdata.InhouseTest ; } set { _labtestdata.InhouseTest  = value; } }
        public int Fees { get { return _labtestdata.Fees; } set { _labtestdata.Fees = value; } }
        public LabTestData  labtestdetails { get { return _labtestdata; } }


        public LabTestModel(int id, string name, string testname, Boolean inhousetest, int fees)
        {
            _labtestdata = new LabTestData (id, name , testname , inhousetest , fees);
        }
        public LabTestModel()
        {
            _labtestdata = new LabTestData();

        }
        public LabTestModel (LabTestData  Labtest)
        {
            _labtestdata = new LabTestData (Labtest.ID, Labtest.Name , Labtest.TestName, Labtest.InhouseTest , Labtest.Fees);
        }


    }
}