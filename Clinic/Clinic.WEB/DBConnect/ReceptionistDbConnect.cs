using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class ReceptionistDbConnect
    {
        public static List<ReceptionistData> ReadAll()
        {
            List<ReceptionistData> lstReceptionist = new List<ReceptionistData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode, UserName,Password FROM Receptionist";
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "Receptionist");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        ReceptionistData receptionist = new ReceptionistData();
                        receptionist.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        receptionist.Name = sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString();
                        receptionist.DOB = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString());
                        receptionist.Mobile = sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString();
                        receptionist.Email = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        receptionist.Address = sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString();
                        receptionist.Location = sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString();
                        receptionist.Landmark = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        receptionist.City = sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString();
                        receptionist.State = sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString();
                        receptionist.Pincode = sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString();
                        receptionist.UserName = sqlDataset.Tables[0].Rows[i].ItemArray[11].ToString();
                        receptionist.Password = sqlDataset.Tables[0].Rows[i].ItemArray[12].ToString();

                        lstReceptionist.Add(receptionist);
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
            return lstReceptionist;
        }
        public static ReceptionistData ReadById(int IDvalue)
        {
            ReceptionistData receptionistDetail = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,UserName,Password FROM Receptionist Where ID= @Id";
            try
            {
                connection.Open();
                SqlCommand manageCommand = new SqlCommand(selectStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", IDvalue);
                SqlDataReader reader = manageCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    receptionistDetail = new ReceptionistData(IDvalue, reader["Name"].ToString(), Convert.ToDateTime(reader["DOB"].ToString()), reader["Mobile"].ToString(), reader["Email"].ToString(), reader["Address"].ToString(), reader["Location"].ToString(), reader["Landmark"].ToString(), reader["City"].ToString(), reader["State"].ToString(), reader["Pincode"].ToString(),reader["UserName"].ToString(), reader["Password"].ToString());
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
            return receptionistDetail;
        }
        public static int AddNewRow(string name, DateTime dob, string mobile, string email,
               string address, string location, string landmark, string city, string state,
               string pincode, string username, string password)
        {
            int count = -1;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Insert Receptionist (Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,UserName,Password) values ( @Name,@DOB,@Mobile,@Email,@Address,@Location,@Landmark,@City,@State,@Pincode,@UserName,@Password)";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@Name", name);
                manageCommand.Parameters.AddWithValue("@DOB", dob);
                manageCommand.Parameters.AddWithValue("@Mobile", mobile);
                manageCommand.Parameters.AddWithValue("@Email", email);
                manageCommand.Parameters.AddWithValue("@Address", address);
                manageCommand.Parameters.AddWithValue("@Location", location);
                manageCommand.Parameters.AddWithValue("@Landmark", landmark);
                manageCommand.Parameters.AddWithValue("@City", city);
                manageCommand.Parameters.AddWithValue("@state", state);
                manageCommand.Parameters.AddWithValue("@Pincode", pincode);
                manageCommand.Parameters.AddWithValue("@UserName", username);
                manageCommand.Parameters.AddWithValue("@Password", password);
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
        public static bool UpdateRow(int Id, string name, DateTime dob, string mobile, string email,
                string address, string location, string landmark, string city, string state,
                string pincode, string username, string password)
        {
            bool updateStatus = false;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Update Receptionist set Name=@Name,DOB=@dob,Mobile=@mobile,Email=@email, Address=@address,Location=@location, Landmark=@landmark,City=@city,State=@state,Pincode=@pincode,UserName=@username,Password=@password Where ID=@Id";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", Id);
                manageCommand.Parameters.AddWithValue("@Name", name);
                manageCommand.Parameters.AddWithValue("@DOB", dob);
                manageCommand.Parameters.AddWithValue("@Mobile", mobile);
                manageCommand.Parameters.AddWithValue("@Email", email);
                manageCommand.Parameters.AddWithValue("@Address", address);
                manageCommand.Parameters.AddWithValue("@Location", address);
                manageCommand.Parameters.AddWithValue("@Landmark", landmark);
                manageCommand.Parameters.AddWithValue("@City", city);
                manageCommand.Parameters.AddWithValue("@state", state);
                manageCommand.Parameters.AddWithValue("@Pincode", pincode);
                manageCommand.Parameters.AddWithValue("@UserName", username);
                manageCommand.Parameters.AddWithValue("@Password", password);
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
            string sqlStatement = "Delete from Receptionist Where ID= @Id";
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
        public static ReceptionistData Authenticate(string username, string password)
        {
            ReceptionistData receptionistdetails = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,UserName,Password FROM Receptionist Where UserName = @UserName AND Password = @Password";
            try
            {
                connection.Open();
                SqlCommand manageCommand = new SqlCommand(selectStatement, connection);
                manageCommand.Parameters.AddWithValue("@UserName", username);
                manageCommand.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = manageCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    receptionistdetails = new ReceptionistData (
                        Convert.ToInt32(reader["ID"].ToString()),
                        reader["Name"].ToString(),
                        Convert.ToDateTime(reader["DOB"].ToString()),
                        reader["Mobile"].ToString(),
                        reader["Email"].ToString(),
                        reader["Address"].ToString(),
                        reader["Location"].ToString(),
                        reader["Landmark"].ToString(),
                        reader["City"].ToString(),
                        reader["State"].ToString(),
                        reader["Pincode"].ToString(),
                        reader["UserName"].ToString(),
                        reader["Password"].ToString());
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
            return receptionistdetails;
        }
    }
}