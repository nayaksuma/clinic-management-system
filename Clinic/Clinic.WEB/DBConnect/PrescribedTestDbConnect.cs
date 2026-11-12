using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class PrescribedTestDbConnect
    {
        public static List<PrescribedTestData> ReadAll()
        {
            List<PrescribedTestData> lstPrescribed = new List<PrescribedTestData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT PrescribedTest.ID, PrescribedTest.PatientID, Patient.Name AS PatientName, PrescribedTest.TestID, LabTest.TestName as TestName, PrescribedTest.DoctorID, Doctor.Name AS DoctorName, PrescribedTest.Fees, PrescribedTest.Date, PrescribedTest.Result FROM PrescribedTest INNER JOIN Patient ON PrescribedTest.PatientID = Patient.ID INNER JOIN Doctor ON PrescribedTest.DoctorID = Doctor.ID INNER JOIN LabTest ON PrescribedTest.TestID = LabTest.ID";
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "PrescribedTest");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        PrescribedTestData prescribed = new PrescribedTestData();
                        prescribed.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        prescribed.PatientID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString());
                        prescribed.PatientName = sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString();
                        prescribed.TestID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString());
                        prescribed.TestName = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        prescribed.DoctorID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString());
                        prescribed.DoctorName = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        prescribed.Fees = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString());
                        prescribed.Date = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString());
                        prescribed.Result = sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString();
                        lstPrescribed.Add(prescribed);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return lstPrescribed;
        }
        public static List<PrescribedTestData> ReadAllPrescribeTestList(int PatientId)
        {
            List<PrescribedTestData> lstPrescribed = new List<PrescribedTestData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT PrescribedTest.ID, PrescribedTest.PatientID, Patient.Name AS PatientName, PrescribedTest.TestID, LabTest.TestName as TestName, PrescribedTest.DoctorID, Doctor.Name AS DoctorName, PrescribedTest.Fees, PrescribedTest.Date, PrescribedTest.Result FROM PrescribedTest INNER JOIN Patient ON PrescribedTest.PatientID = Patient.ID INNER JOIN Doctor ON PrescribedTest.DoctorID = Doctor.ID INNER JOIN LabTest ON PrescribedTest.TestID = LabTest.ID Where PatientID =@PatientId";
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                sqlAdapter.SelectCommand.Parameters.AddWithValue("@PatientId", PatientId);
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "PrescribedTest");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        PrescribedTestData prescribed = new PrescribedTestData();
                        prescribed.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        prescribed.PatientID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString());
                        prescribed.PatientName = sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString();
                        prescribed.TestID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString());
                        prescribed.TestName = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        prescribed.DoctorID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString());
                        prescribed.DoctorName = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        prescribed.Fees = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString());
                        prescribed.Date = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString());
                        prescribed.Result = sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString();
                        lstPrescribed.Add(prescribed);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return lstPrescribed;
        }
        public static PrescribedTestData ReadById(int IDvalue)
        {
            PrescribedTestData prescribedDetail = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT PrescribedTest.ID, PrescribedTest.PatientID, Patient.Name AS PatientName, PrescribedTest.TestID, LabTest.TestName as TestName, PrescribedTest.DoctorID, Doctor.Name AS DoctorName, PrescribedTest.Fees, PrescribedTest.Date, PrescribedTest.Result FROM PrescribedTest INNER JOIN Patient ON PrescribedTest.PatientID = Patient.ID INNER JOIN Doctor ON PrescribedTest.DoctorID = Doctor.ID INNER JOIN LabTest ON PrescribedTest.TestID = LabTest.ID Where PrescribedTest.ID= @Id";
            try
            {
                connection.Open();
                SqlCommand manageCommand = new SqlCommand(selectStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", IDvalue);
                SqlDataReader reader = manageCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    prescribedDetail = new PrescribedTestData(IDvalue, Convert.ToInt32(reader["PatientID"].ToString()), reader["PatientName"].ToString(), Convert.ToInt32(reader["TestID"].ToString()), reader["TestName"].ToString(), Convert.ToInt32(reader["DoctorID"].ToString()), reader["DoctorName"].ToString(), Convert.ToInt32(reader["Fees"].ToString()), Convert.ToDateTime(reader["Date"].ToString()), reader["Result"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return prescribedDetail;
        }
        public static int AddNewRow(int patientid, int testid, int doctorid, int fees, DateTime date, string result)
        {
            int count = -1;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Insert PrescribedTest (PatientID,TestID,DoctorID,Fees,Date,Result) values (@PatientID,@TestID,@DoctorID,@Fees,@Date,@Result)";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@PatientID", patientid);
                manageCommand.Parameters.AddWithValue("@TestID", testid);
                manageCommand.Parameters.AddWithValue("@DoctorID", doctorid);
                manageCommand.Parameters.AddWithValue("@Fees", fees);
                manageCommand.Parameters.AddWithValue("@Date", date);
                manageCommand.Parameters.AddWithValue("@Result", result);
                connection.Open();
                count = manageCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally    
            {
                connection.Close();
            }
            return count;
        }
        public static bool UpdateRow(int id, int patientid, int testid, int doctorid, int fees, DateTime date, string result)
        {
            bool updateStatus = false;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Update PrescribedTest set PatientID=@patientid,TestID=@testid,DoctorID=@doctorid,Fees=@fees,Date=@date,Result=@result Where ID=@Id";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@ID", id);
                manageCommand.Parameters.AddWithValue("@PatientID", patientid);
                manageCommand.Parameters.AddWithValue("@TestID", testid);
                manageCommand.Parameters.AddWithValue("@DoctorID", doctorid);
                manageCommand.Parameters.AddWithValue("@Fees", fees);
                manageCommand.Parameters.AddWithValue("@Date", date);
                manageCommand.Parameters.AddWithValue("@Result", result);
                connection.Open();
                int count = manageCommand.ExecuteNonQuery();
                if (count > 0)
                {
                    updateStatus = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return updateStatus;
        }
        public static bool DeleteRow(int IDvalue)
        {
            bool deleteStatus = false;
            string connectionString = GlobalData.GetConnectionString();
            string sqlStatement = "Delete from PrescribedTest Where ID= @Id";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", IDvalue);
                connection.Open();
                int count = manageCommand.ExecuteNonQuery();
                if (count > 0)
                {
                    deleteStatus = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return deleteStatus;
        }
    }
}