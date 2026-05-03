using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HospitalSystemApp.Models; // This allows the repo to see the Person class

namespace HospitalSystemApp.Repos
{
    public class PatientRepository
    {

        public void AddPatient(Person person, string phone, string insCompany, string insType, string notes)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Insert into Person and get the IDENTITY ID
                    string personQuery = @"INSERT INTO Person (Fname, Lname, Email, BirthDate)
                                   VALUES (@fn, @ln, @em, @bd);
                                   SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd1 = new SqlCommand(personQuery, conn, trans);
                    cmd1.Parameters.Add("@fn", SqlDbType.VarChar, 50).Value = person.Fname;
                    cmd1.Parameters.Add("@ln", SqlDbType.VarChar, 50).Value = person.Lname;
                    cmd1.Parameters.Add("@em", SqlDbType.VarChar, 100).Value = person.Email;
                    cmd1.Parameters.Add("@bd", SqlDbType.Date).Value = person.BirthDate;

                    int newID = Convert.ToInt32(cmd1.ExecuteScalar());

                    // 2. Insert into Patient
                    string patientQuery = "INSERT INTO Patient (PatientID) VALUES (@id)";
                    SqlCommand cmd2 = new SqlCommand(patientQuery, conn, trans);
                    cmd2.Parameters.Add("@id", SqlDbType.Int).Value = newID;
                    cmd2.ExecuteNonQuery();

                    // 3. Insert into PersonPhone (Optional)
                    if (!string.IsNullOrWhiteSpace(phone))
                    {
                        string phoneQuery = "INSERT INTO PersonPhone (PersonID, PhoneNumber) VALUES (@id, @ph)";
                        SqlCommand cmd3 = new SqlCommand(phoneQuery, conn, trans);
                        cmd3.Parameters.Add("@id", SqlDbType.Int).Value = newID;
                        cmd3.Parameters.Add("@ph", SqlDbType.VarChar, 20).Value = phone;
                        cmd3.ExecuteNonQuery();
                    }

                    // 4. Insert into Insurance (Optional)
                    if (!string.IsNullOrWhiteSpace(insCompany))
                    {
                        string insQuery = "INSERT INTO Insurance (PatientID, CompanyName, CompanyType) VALUES (@id, @co, @typ)";
                        SqlCommand cmd4 = new SqlCommand(insQuery, conn, trans);
                        cmd4.Parameters.Add("@id", SqlDbType.Int).Value = newID;
                        cmd4.Parameters.Add("@co", SqlDbType.VarChar, 100).Value = insCompany;
                        cmd4.Parameters.Add("@typ", SqlDbType.VarChar, 50).Value = insType;
                        cmd4.ExecuteNonQuery();
                    }

                    // 5. Insert into Services (Initial Notes/Check-up)
                    if (!string.IsNullOrWhiteSpace(notes))
                    {
                        string serviceQuery = "INSERT INTO Services (ServiceDate, Notes, PatientID) VALUES (GETDATE(), @nt, @id)";
                        SqlCommand cmd5 = new SqlCommand(serviceQuery, conn, trans);
                        cmd5.Parameters.Add("@nt", SqlDbType.VarChar, 255).Value = notes;
                        cmd5.Parameters.Add("@id", SqlDbType.Int).Value = newID;
                        cmd5.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }


        public DataTable GetAllPatientsTable()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"
                    SELECT 
                    p.PersonID, p.Fname, p.Lname, p.Email, p.BirthDate,
                    pp.PhoneNumber,
                    i.CompanyName AS Insurance,
                    s.Notes AS LastNotes
                    FROM Person p
                    JOIN Patient pa ON p.PersonID = pa.PatientID
                    LEFT JOIN PersonPhone pp ON p.PersonID = pp.PersonID
                    LEFT JOIN Insurance i ON pa.PatientID = i.PatientID
                    LEFT JOIN Services s ON pa.PatientID = s.PatientID";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                table.Load(reader);
            }

            return table;
        }

     
        public void UpdatePatient(Person person)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"UPDATE Person
                                 SET Fname = @fn,
                                     Lname = @ln,
                                     Email = @em,
                                     BirthDate = @bd
                                 WHERE PersonID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = person.PersonID;
                cmd.Parameters.Add("@fn", SqlDbType.VarChar, 50).Value = person.Fname;
                cmd.Parameters.Add("@ln", SqlDbType.VarChar, 50).Value = person.Lname;
                cmd.Parameters.Add("@em", SqlDbType.VarChar, 100).Value = person.Email;
                cmd.Parameters.Add("@bd", SqlDbType.Date).Value = person.BirthDate;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

     
        public void DeletePatient(int id)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "DELETE FROM Person WHERE PersonID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}