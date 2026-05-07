using System;
using System.Data.SqlClient;
using HospitalSystemApp.Models;

public class AuthRepository
{
    public User Login(string email, string dob)
    {
        using (SqlConnection conn = DB.GetConnection())
        {
            // Query uses LEFT JOINs to identify the role 
            string query = @"
                SELECT P.PersonID, P.Fname, P.Lname,
                       CASE 
                           WHEN D.DoctorID IS NOT NULL THEN 'Doctor'
                           WHEN PA.PatientID IS NOT NULL THEN 'Patient'
                           WHEN N.NurseID IS NOT NULL THEN 'Nurse'
                           ELSE 'Unknown'
                       END AS UserRole
                FROM Person P
                LEFT JOIN Doctor D ON P.PersonID = D.DoctorID
                LEFT JOIN Patient PA ON P.PersonID = PA.PatientID
                LEFT JOIN NURSE N ON P.PersonID = N.NurseID
                WHERE P.Email = @email AND P.BirthDate = @dob";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter paramEmail = new SqlParameter("@email", email);
            cmd.Parameters.Add(paramEmail);
            SqlParameter paramDob = new SqlParameter("@dob", dob); // User enters: YYYY-MM-DD
            cmd.Parameters.Add(paramDob);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    PersonID = (int)reader["PersonID"],
                    Fname = reader["Fname"].ToString(),
                    Lname = reader["Lname"].ToString(),
                    Role = reader["UserRole"].ToString()
                };
            }
            return null; // Login failed
        }
    }
}