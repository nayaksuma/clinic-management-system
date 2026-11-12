using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class LabTestDbConnect
    {
        public static List<LabTestData> ReadAll()
        {
            List<LabTestData> lstTest = new List<LabTestData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,TestName,InhouseTest,Fees FROM LabTest";
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "LabTest");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        LabTestData test = new LabTestData();
                        test.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        test.Name = sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString();
                        test.TestName = sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString();
                        test.InhouseTest = Convert.ToBoolean( sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString());
                        test.Fees =Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString());
                        lstTest.Add(test);
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
            return lstTest;
        }
        public static LabTestData ReadById(int IDvalue)
        {
            LabTestData testDetail = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,TestName,InhouseTest,Fees FROM LabTest Where ID= @Id";
            try
            {
                connection.Open();
                SqlCommand manageCommand = new SqlCommand(selectStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", IDvalue);
                SqlDataReader reader = manageCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    testDetail = new LabTestData(IDvalue, reader["Name"].ToString(), reader["TestName"].ToString(),Convert.ToBoolean( reader["InhouseTest"].ToString()),Convert.ToInt32(reader["Fees"].ToString()));
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
            return testDetail;
        }
        public static int AddNewRow(string name, string  testname, Boolean inhousetest, int fees)
        {
            int count = -1;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Insert LabTest (Name,TestName,InhouseTest,Fees) values (@Name,@TestName,@InhouseTest,@Fees)";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@Name", name);
                manageCommand.Parameters.AddWithValue("@TestName", testname);
                manageCommand.Parameters.AddWithValue("@InhouseTest", inhousetest);
                manageCommand.Parameters.AddWithValue("@Fees", fees);
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
        public static bool UpdateRow(int id, string name, string testname, Boolean inhousetest, int fees)
        {
            bool updateStatus = false;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Update LabTest set Name=@name,TestName=@testname,InhouseTest=@inhousetest,Fees=@fees Where ID=@Id";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@ID", id);
                manageCommand.Parameters.AddWithValue("@Name", name);
                manageCommand.Parameters.AddWithValue("@TestName", testname );
                manageCommand.Parameters.AddWithValue("@InhouseTest", inhousetest);
                manageCommand.Parameters.AddWithValue("@Fees", fees);
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
            string sqlStatement = "Delete from LabTest Where ID= @Id";
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