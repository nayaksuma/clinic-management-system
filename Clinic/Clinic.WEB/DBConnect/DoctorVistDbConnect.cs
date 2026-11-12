using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class DoctorVistDbConnect
    {
        public static List<DoctorVisitData> ReadAll()
        {
            List<DoctorVisitData> lstVisit = new List<DoctorVisitData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT DoctorVisit.ID, DoctorVisit.DoctorID, Doctor.Name AS DoctorName, DoctorVisit.PatientID, Patient.Name AS PatientName, DoctorVisit.Date, DoctorVisit.Symptoms, DoctorVisit.Prescription, DoctorVisit.Payment,DoctorVisit.VisitDate,DoctorVisit.Dateofbooking,DoctorVisit.Status,DoctorVisit.ResultDate FROM DoctorVisit INNER JOIN Doctor ON DoctorVisit.DoctorID = Doctor.ID INNER JOIN Patient ON DoctorVisit.PatientID = Patient.ID";
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "DoctorVisit");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        DoctorVisitData doctor = new DoctorVisitData();
                        doctor.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        doctor.DoctorID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString());
                        doctor.DoctorName = sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString();
                        doctor.PatientID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString());
                        doctor.PatientName = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        doctor.Date = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString());
                        doctor.Symptoms = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        doctor.Prescription = sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString();
                        doctor.Payment = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString());
                        doctor.VisitDate = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString());
                        doctor.Dateofbooking = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[10].ToString());
                        doctor.Status = sqlDataset.Tables[0].Rows[i].ItemArray[11].ToString();
                        doctor.ResultDate = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[12].ToString());
                        lstVisit.Add(doctor);
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
            return lstVisit;
        }

        public static List<DoctorVisitData> ReadAllConfirmed(int DoctorId)
        {
            List<DoctorVisitData> lstVisit = new List<DoctorVisitData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT DoctorVisit.ID, DoctorVisit.DoctorID, Doctor.Name AS DoctorName, DoctorVisit.PatientID, Patient.Name AS PatientName, DoctorVisit.Date, DoctorVisit.Symptoms, DoctorVisit.Prescription, DoctorVisit.Payment,DoctorVisit.VisitDate,DoctorVisit.Dateofbooking,DoctorVisit.Status,DoctorVisit.ResultDate FROM DoctorVisit INNER JOIN Doctor ON DoctorVisit.DoctorID = Doctor.ID INNER JOIN Patient ON DoctorVisit.PatientID = Patient.ID Where DoctorVisit.Status='Accepted' AND DoctorID =@DoctorId AND DoctorVisit.VisitDate=@VisitDate";
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                sqlAdapter.SelectCommand.Parameters.AddWithValue("@DoctorId", DoctorId);
                sqlAdapter.SelectCommand.Parameters.AddWithValue("@VisitDate", DateTime.Today);
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "DoctorVisit");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        DoctorVisitData doctor = new DoctorVisitData();
                        doctor.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        doctor.DoctorID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString());
                        doctor.DoctorName = sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString();
                        doctor.PatientID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString());
                        doctor.PatientName = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        doctor.Date = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString());
                        doctor.Symptoms = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        doctor.Prescription = sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString();
                        doctor.Payment = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString());
                        doctor.VisitDate = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString());
                        doctor.Dateofbooking = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[10].ToString());
                        doctor.Status = sqlDataset.Tables[0].Rows[i].ItemArray[11].ToString();
                        doctor.ResultDate = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[12].ToString());
                        lstVisit.Add(doctor);
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
            return lstVisit;
        }
        public static List<DoctorVisitData> ReadAllAppoinment(int PatientId)
        {
            List<DoctorVisitData> lstVisit = new List<DoctorVisitData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT DoctorVisit.ID, DoctorVisit.DoctorID, Doctor.Name AS DoctorName, DoctorVisit.PatientID, Patient.Name AS PatientName, DoctorVisit.Date, DoctorVisit.Symptoms, DoctorVisit.Prescription, DoctorVisit.Payment,DoctorVisit.VisitDate,DoctorVisit.Dateofbooking,DoctorVisit.Status,DoctorVisit.ResultDate FROM DoctorVisit INNER JOIN Doctor ON DoctorVisit.DoctorID = Doctor.ID INNER JOIN Patient ON DoctorVisit.PatientID = Patient.ID Where PatientID =@PatientId";
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                sqlAdapter.SelectCommand.Parameters.AddWithValue("@PatientId", PatientId);
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "DoctorVisit");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        DoctorVisitData doctor = new DoctorVisitData();
                        doctor.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        doctor.DoctorID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString());
                        doctor.DoctorName = sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString();
                        doctor.PatientID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString());
                        doctor.PatientName = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        doctor.Date = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString());
                        doctor.Symptoms = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        doctor.Prescription = sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString();
                        doctor.Payment = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString());
                        doctor.VisitDate = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString());
                        doctor.Dateofbooking = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[10].ToString());
                        doctor.Status = sqlDataset.Tables[0].Rows[i].ItemArray[11].ToString();
                        doctor.ResultDate = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[12].ToString());
                        lstVisit.Add(doctor);
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
            return lstVisit;
        }
        public static List<DoctorVisitData> ReadAllRejectedList()
        {
            List<DoctorVisitData> lstVisit = new List<DoctorVisitData>();
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT DoctorVisit.ID, DoctorVisit.DoctorID, Doctor.Name AS DoctorName, DoctorVisit.PatientID, Patient.Name AS PatientName, DoctorVisit.Date, DoctorVisit.Symptoms, DoctorVisit.Prescription, DoctorVisit.Payment,DoctorVisit.VisitDate,DoctorVisit.Dateofbooking,DoctorVisit.Status,DoctorVisit.ResultDate FROM DoctorVisit INNER JOIN Doctor ON DoctorVisit.DoctorID = Doctor.ID INNER JOIN Patient ON DoctorVisit.PatientID = Patient.ID Where DoctorVisit.Status='Reject'";
            try
            {
                connection.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(selectStatement, connection);
                DataSet sqlDataset = new DataSet();
                sqlAdapter.Fill(sqlDataset, "DoctorVisit");
                int rcount = sqlDataset.Tables[0].Rows.Count;
                if (rcount > 0)
                {
                    for (int i = 0; i < rcount; i++)
                    {
                        DoctorVisitData doctor = new DoctorVisitData();
                        doctor.ID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[0].ToString());
                        doctor.DoctorID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[1].ToString());
                        doctor.DoctorName = sqlDataset.Tables[0].Rows[i].ItemArray[2].ToString();
                        doctor.PatientID = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[3].ToString());
                        doctor.PatientName = sqlDataset.Tables[0].Rows[i].ItemArray[4].ToString();
                        doctor.Date = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[5].ToString());
                        doctor.Symptoms = sqlDataset.Tables[0].Rows[i].ItemArray[6].ToString();
                        doctor.Prescription = sqlDataset.Tables[0].Rows[i].ItemArray[7].ToString();
                        doctor.Payment = Convert.ToInt32(sqlDataset.Tables[0].Rows[i].ItemArray[8].ToString());
                        doctor.VisitDate = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[9].ToString());
                        doctor.Dateofbooking = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[10].ToString());
                        doctor.Status = sqlDataset.Tables[0].Rows[i].ItemArray[11].ToString();
                        doctor.ResultDate = Convert.ToDateTime(sqlDataset.Tables[0].Rows[i].ItemArray[12].ToString());
                        lstVisit.Add(doctor);
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
            return lstVisit;
        }

        public static DoctorVisitData ReadById(int IDvalue)
        {
            DoctorVisitData visitDetail = null;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            string selectStatement = "SELECT DoctorVisit.ID, DoctorVisit.DoctorID, Doctor.Name AS DoctorName, DoctorVisit.PatientID, Patient.Name AS PatientName, DoctorVisit.Date, DoctorVisit.Symptoms, DoctorVisit.Prescription, DoctorVisit.Payment,DoctorVisit.VisitDate,DoctorVisit.Dateofbooking,DoctorVisit.Status,DoctorVisit.ResultDate  FROM DoctorVisit INNER JOIN Doctor ON DoctorVisit.DoctorID = Doctor.ID INNER JOIN Patient ON DoctorVisit.PatientID = Patient.ID Where DoctorVisit.ID = @Id";
            try
            {
                connection.Open();
                SqlCommand manageCommand = new SqlCommand(selectStatement, connection);
                manageCommand.Parameters.AddWithValue("@Id", IDvalue);
                SqlDataReader reader = manageCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    visitDetail = new DoctorVisitData(IDvalue, Convert.ToInt32(reader["DoctorID"].ToString()), reader["DoctorName"].ToString(), Convert.ToInt32(reader["PatientID"].ToString()), reader["PatientName"].ToString(), Convert.ToDateTime(reader["Date"].ToString()), reader["Symptoms"].ToString(), reader["Prescription"].ToString(), Convert.ToInt32(reader["Payment"].ToString()), Convert.ToDateTime(reader["Visitdate"].ToString()), Convert.ToDateTime(reader["Dateofbooking"].ToString()), reader["Status"].ToString(), Convert.ToDateTime(reader["ResultDate"].ToString()));
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
            return visitDetail;
        }
        public static int AddNewRow(int doctorid, int patientid, DateTime date, string symptoms, string prescription,
                int payment, DateTime visitdate, DateTime dateofbooking, string status, DateTime resultdate)
        {
            int count = -1;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Insert DoctorVisit (DoctorID,PatientID,Date,Symptoms,Prescription,Payment,VisitDate,Dateofbooking,Status,ResultDate) values (@DoctorID,@PatientID,@Date,@Symptoms,@Prescription,@Payment,@VisitDate,@Dateofbooking,@Status,@ResultDate)";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@DoctorID", doctorid);
                manageCommand.Parameters.AddWithValue("@PatientID", patientid);
                manageCommand.Parameters.AddWithValue("@Date", date);
                manageCommand.Parameters.AddWithValue("@Symptoms", symptoms);
                manageCommand.Parameters.AddWithValue("@Prescription", prescription);
                manageCommand.Parameters.AddWithValue("@Payment", payment);
                manageCommand.Parameters.AddWithValue("@VisitDate", visitdate);
                manageCommand.Parameters.AddWithValue("@Dateofbooking", dateofbooking);
                manageCommand.Parameters.AddWithValue("@Status", status);
                manageCommand.Parameters.AddWithValue("@ResultDate", resultdate);
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
        public static bool UpdateRow(int id, int doctorid, int patientid, DateTime date, string symptoms, string prescription, int payment, DateTime visitdate, DateTime dateofbooking, string status, DateTime resultdate)
        {
            bool updateStatus = false;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Update DoctorVisit set DoctorID=@doctorid,PatientID=@patientid,Date=@date,Symptoms=@symptoms,Prescription=@prescription,Payment=@payment,VisitDate=@visitdate,Dateofbooking=@dateofbooking,Status=@status,ResultDate=@ResultDate Where ID=@Id";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@ID", id);
                manageCommand.Parameters.AddWithValue("@DoctorID", doctorid);
                manageCommand.Parameters.AddWithValue("@PatientID", patientid);
                manageCommand.Parameters.AddWithValue("@Date", date);
                manageCommand.Parameters.AddWithValue("@Symptoms", symptoms);
                manageCommand.Parameters.AddWithValue("@Prescription", prescription);
                manageCommand.Parameters.AddWithValue("@Payment", payment);
                manageCommand.Parameters.AddWithValue("@VisitDate", visitdate);
                manageCommand.Parameters.AddWithValue("@Dateofbooking", dateofbooking);
                manageCommand.Parameters.AddWithValue("@Status", status);
                manageCommand.Parameters.AddWithValue("@ResultDate", resultdate);
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
        public static bool ChangeStatus(int id, string status)
        {
            bool updateStatus = false;
            string connectionString = GlobalData.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlStatement;
                SqlCommand manageCommand;
                sqlStatement = "Update DoctorVisit set Status=@status Where ID=@Id";
                manageCommand = new SqlCommand(sqlStatement, connection);
                manageCommand.Parameters.AddWithValue("@ID", id);
                manageCommand.Parameters.AddWithValue("@Status", status);
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
            string sqlStatement = "Delete from DoctorVisit Where ID= @Id";
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