using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class DoctorDbConnect
    {
        public static List<DoctorData> ReadAll(int id=-1, bool isPhotoRequired = true) 
        {
            List<DoctorData> lstDoctor = new List<DoctorData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,Qualification,Specialisation,Department, UserName,Password,Photo FROM Doctor";
            if (id != -1)
            {
                selectStatement = selectStatement + " Where ID = @Id";
            }
            if (!isPhotoRequired)
            {
                selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,Qualification,Specialisation,Department, UserName,Password, null AS Photo FROM Doctor";
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
                sqlAdapter.Fill(sqlDataset, "Doctor");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        DoctorData doctor = new DoctorData();
                        doctor.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        doctor.Name = sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString();
                        doctor.DOB = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString());
                        doctor.Mobile = sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString();
                        doctor.Email = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        doctor.Address = sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString();
                        doctor.Location = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        doctor.Landmark = sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString();
                        doctor.City = sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString();
                        doctor.State = sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString();
                        doctor.Pincode = sqlDataset.Tables[0].Rows[i].ItemArray[10].ToString();
                        doctor.Qualification = sqlDataset.Tables[0].Rows[i].ItemArray[11].ToString();
                        doctor.Specialisation = sqlDataset.Tables[0].Rows[i].ItemArray[12].ToString();
                        doctor.Department = sqlDataset.Tables[0].Rows[i].ItemArray[13].ToString();
                        doctor.UserName = sqlDataset.Tables[0].Rows[i].ItemArray[14].ToString();
                        doctor.Password = sqlDataset.Tables[0].Rows[i].ItemArray[15].ToString();
                        if (sqlDataset.Tables[0].Rows[i].ItemArray[16] != DBNull.Value)
                        {
                            doctor.Photo = (byte[])sqlDataset.Tables[0].Rows[i].ItemArray[16];
                        }
                        lstDoctor.Add(doctor);
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
            return lstDoctor;
        }
        public static DoctorData ReadById(int IDvalue)
        {
            DoctorData doctorDetail = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,Qualification,Specialisation,Department,UserName,Password,Photo FROM Doctor Where ID= @Id";
            try
            {
                connection.Open();
                SqlCommand manageCommand = new SqlCommand(selectStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", IDvalue);
                SqlDataReader reader = manageCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    doctorDetail = new DoctorData(IDvalue, reader["Name"].ToString(), Convert.ToDateTime(reader["DOB"].ToString()), reader["Mobile"].ToString(), reader["Email"].ToString(), reader["Address"].ToString(), reader["Location"].ToString(), reader["Landmark"].ToString(), reader["City"].ToString(), reader["State"].ToString(), reader["Pincode"].ToString(), reader["Qualification"].ToString(), reader["Specialisation"].ToString(), reader["Department"].ToString(), reader["UserName"].ToString(), reader["Password"].ToString(), (reader["Photo"] == System.DBNull.Value) ? null : (byte[])reader["Photo"]);
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
            return doctorDetail;
        }
        public static int AddNewRow(string name, DateTime dob, string mobile, string email,
                string address, string location, string landmark, string city, string state,
                string pincode, string qualification, string specialisation,string department, string username, string password, byte[] photo)
        {
            int count = -1;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Insert Doctor (Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,Qualification,Specialisation,Department,UserName,Password,Photo) values ( @Name,@DOB,@Mobile,@Email,@Address,@Location,@Landmark,@City,@State,@Pincode,@Qualification,@Specialisation,@Department,@Username,@Password,@Photo)";
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
                manageCommand.Parameters.AddWithValue("@Qualification", qualification);
                manageCommand.Parameters.AddWithValue("@Specialisation", specialisation);
                manageCommand.Parameters.AddWithValue("@Department", department);
                manageCommand.Parameters.AddWithValue("@UserName", username);
                manageCommand.Parameters.AddWithValue("@Password", password);
                if (photo != null)
                { 
                    manageCommand.Parameters.AddWithValue("@Photo", photo); 
                }
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
        public static bool UpdateRow(int id, string name, DateTime dob, string mobile, string email,
                string address, string location, string landmark, string city, string state,
                string pincode, string qualification, string specialisation, string department, string username, string password, byte[] photo)
        {
            bool updateStatus = false;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Update Doctor set Name=@name,DOB=@dob,Mobile=@mobile,Email=@email, Address=@address,Location=@location, Landmark=@landmark,City=@city,State=@state,Pincode=@pincode,Qualification=@qualification,Specialisation=@specialisation,Department=@department,UserName=@username,Password=@password, Photo=@Photo Where ID=@Id";
                if (photo == null)
                {
                    sqlStatement = "Update Doctor set Name=@name,DOB=@dob,Mobile=@mobile,Email=@email, Address=@address,Location=@location, Landmark=@landmark,City=@city,State=@state,Pincode=@pincode,Qualification=@qualification,Specialisation=@specialisation,Department=@department,UserName=@username,Password=@password Where ID=@Id";
                }
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", id );
                manageCommand.Parameters.AddWithValue("@Name", name);
                manageCommand.Parameters.AddWithValue("@DOB", dob);
                manageCommand.Parameters.AddWithValue("@Mobile", mobile);
                manageCommand.Parameters.AddWithValue("@Email", email);
                manageCommand.Parameters.AddWithValue("@Address", address);
                manageCommand.Parameters.AddWithValue("@Location", location );
                manageCommand.Parameters.AddWithValue("@Landmark", landmark);
                manageCommand.Parameters.AddWithValue("@City", city);
                manageCommand.Parameters.AddWithValue("@state", state);
                manageCommand.Parameters.AddWithValue("@Pincode", pincode);
                manageCommand.Parameters.AddWithValue("@Qualification", qualification);
                manageCommand.Parameters.AddWithValue("@Specialisation", specialisation);
                manageCommand.Parameters.AddWithValue("@Department", department);
                manageCommand.Parameters.AddWithValue("@UserName", username);
                manageCommand.Parameters.AddWithValue("@Password", password);
                if (photo!= null)
                { 
                    manageCommand.Parameters.AddWithValue("@Photo", photo); 
                }
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
            string sqlStatement = "Delete from Doctor Where ID= @Id";
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


        public static DoctorData Authenticate(string username, string password)
        {
            DoctorData doctorDetail = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "Select ID, Name,DOB,Mobile,Email,Address,Location,Landmark,City,State,Pincode,Qualification,Specialisation,Department,UserName,Password,Photo FROM Doctor Where UserName = @UserName AND Password = @Password";
            try
            {
                connection.Open();
                SqlCommand manageCommand = new SqlCommand(selectStatement, connection);
                manageCommand.Parameters.AddWithValue("@UserName",username);
                manageCommand.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = manageCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    doctorDetail = new DoctorData(
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
                        reader["Qualification"].ToString(), 
                        reader["Specialisation"].ToString(), 
                        reader["Department"].ToString(), 
                        reader["UserName"].ToString(), 
                        reader["Password"].ToString(),
                        (reader["Photo"] == System.DBNull.Value) ? null : (byte[])reader["Photo"]);
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
            return doctorDetail;
        }

    }
}


