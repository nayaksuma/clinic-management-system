using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class LabTestData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TestName{ get; set; }
        public Boolean InhouseTest { get; set; }
        public int Fees { get; set; }
        
        public LabTestData(int id, string name, string testname, Boolean inhousetest, int fees)
        {
            ID = id;
            Name = name;
            TestName = testname;
            InhouseTest = inhousetest;
            Fees = fees;
        }
        public LabTestData()
        {
            ID = 0;
            Name = "";
            TestName = "";
            InhouseTest = false;
            Fees = 0;
        }
        public static List<LabTestData> ReadAll()
        {
            List<LabTestData> lstTest= null;
            try
            {
                lstTest = LabTestDbConnect.ReadAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTest;
        }
        public static LabTestData ReadById(int IDvalue)
        {
            LabTestData testDetail = null;
            try
            {
                testDetail = LabTestDbConnect.ReadById(IDvalue);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return testDetail;
        }
        public static int AddNewRow(string name, string testname, Boolean inhousetest, int fees)
        {
            int count = -1;
            try
            {
                count = LabTestDbConnect.AddNewRow(name, testname , inhousetest, fees);
            }
            catch (Exception ex)
            {
                //Handle Exception
            }
            return count;
        }
        public static bool UpdateRow(int id, string name, string testname, Boolean inhousetest,int fees)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = LabTestDbConnect.UpdateRow(id, name, testname , inhousetest, fees);
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
                updateStatus = updateStatus = LabTestDbConnect.UpdateRow(ID, Name, TestName , InhouseTest, Fees);
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
                deleteStatus = LabTestDbConnect.DeleteRow(IDvalue);
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
                deleteStatus = LabTestDbConnect.DeleteRow(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deleteStatus;
        }
    }
}