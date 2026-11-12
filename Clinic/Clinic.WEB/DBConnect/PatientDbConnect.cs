using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    class PatientDbConnect
    {
        public static List<PatientData> ReadAll(int id = -1)
        {
            List<PatientData> lstPatient = new List<PatientData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,BloodGroup,AdharNo,UserName,Password FROM Patient";
            if (id != -1)
            {
                selectStatement = selectStatement + " Where ID = @Id";
            }
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                if (id != -1)
                {
                    sqlAdapter.SelectCommand.Parameters.AddWithValue("Id", id);
                }
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "Patient");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        PatientData patient = new PatientData();
                        patient.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        patient.Name = sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString();
                        patient.DOB = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString());
                        patient.Mobile = sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString();
                        patient.Email = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        patient.Address = sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString();
                        patient.Location = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        patient.Landmark = sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString();
                        patient.City = sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString();
                        patient.State = sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString();
                        patient.Pincode = sqlDataset.Tables[0].Rows[i].ItemArray[10].ToString();
                        patient.BloodGroup = sqlDataset.Tables[0].Rows[i].ItemArray[11].ToString();
                        patient.AdharNo = sqlDataset.Tables[0].Rows[i].ItemArray[12].ToString();
                        patient.UserName = sqlDataset.Tables[0].Rows[i].ItemArray[13].ToString();
                        patient.Password = sqlDataset.Tables[0].Rows[i].ItemArray[14].ToString();

                        lstPatient.Add(patient);
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
            return lstPatient;
        }



        public static PatientData ReadById(int IDvalue)
        {
            PatientData patientDetail = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,Bloodgroup,AdharNo,UserName,Password FROM Patient Where ID= @Id";
            try
            {
                connection.Open();
                SqlCommand manageCommand = new SqlCommand(selectStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", IDvalue);
                SqlDataReader reader = manageCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    patientDetail = new PatientData(IDvalue, reader["Name"].ToString(), Convert.ToDateTime(reader["DOB"].ToString()), reader["Mobile"].ToString(), reader["Email"].ToString(), reader["Address"].ToString(), reader["Location"].ToString(), reader["Landmark"].ToString(), reader["City"].ToString(), reader["State"].ToString(), reader["Pincode"].ToString(), reader["BloodGroup"].ToString(), reader["AdharNo"].ToString(), reader["UserName"].ToString(), reader["Password"].ToString());
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
            return patientDetail;
        }
        public static int AddNewRow(string name, DateTime dob, string mobile, string email,
                string address, string location, string landmark, string city, string state,
                string pincode, string bloodgroup, string adharno, string username, string password)
        {
            int count = -1;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Insert Patient (Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,BloodGroup,AdharNo,UserName,Password) values ( @Name,@DOB,@Mobile,@Email,@Address,@Location,@Landmark,@City,@State,@Pincode,@BloodGroup,@AdharNo,@UserName,@Password)";
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
                manageCommand.Parameters.AddWithValue("@BloodGroup", bloodgroup);
                manageCommand.Parameters.AddWithValue("@AdharNo", adharno);
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
                string pincode, string bloodgroup, string adharno, string username, string password)
        {
            bool updateStatus = false;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Update Patient set Name=@Name,DOB=@dob,Mobile=@mobile,Email=@email, Address=@address,Location=@location, Landmark=@landmark,City=@city,State=@state,Pincode=@pincode,BloodGroup=@bloodgroup,AdharNo=@adharno,UserName=@username,Password=@password Where ID=@Id";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", Id);
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
                manageCommand.Parameters.AddWithValue("@BloodGroup", bloodgroup);
                manageCommand.Parameters.AddWithValue("@AdharNo", adharno);
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
            string sqlStatement = "Delete from Patient Where ID= @Id";
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
        public static PatientData Authenticate(string username, string password)
        {
            PatientData patientdetails = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,BloodGroup,AdharNo,UserName,Password FROM Patient Where UserName = @UserName AND Password = @Password";
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
                    patientdetails = new PatientData(
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
                        reader["BloodGroup"].ToString(),
                        reader["AdharNo"].ToString(),
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
            return patientdetails;
        }
    }
}