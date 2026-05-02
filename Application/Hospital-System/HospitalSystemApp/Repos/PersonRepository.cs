using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HospitalSystemApp.Models; // This allows the repo to see the Person class

namespace HospitalSystemApp.Repos
{
    public class PersonRepository
    {
        //  CREATE
        public void AddPerson(Person p)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"INSERT INTO Person 
                            (PersonID, Fname, Lname, Email, BirthDate)
                            VALUES (@id, @fn, @ln, @em, @bd)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", p.PersonID);
                cmd.Parameters.AddWithValue("@fn", p.Fname);
                cmd.Parameters.AddWithValue("@ln", p.Lname);
                cmd.Parameters.AddWithValue("@em", p.Email);
                cmd.Parameters.AddWithValue("@bd", p.BirthDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // READ (ALL) 
        public List<Person> GetAllPersons()
        {
            List<Person> list = new List<Person>();

            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "SELECT * FROM Person";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Person
                    {
                        PersonID = (int)reader["PersonID"],
                        Fname = reader["Fname"].ToString(),
                        Lname = reader["Lname"].ToString(),
                        Email = reader["Email"].ToString(),
                        BirthDate = (DateTime)reader["BirthDate"]
                    });
                }
            }

            return list;
        }

        //  UPDATE
        public void UpdatePerson(Person p)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"UPDATE Person
                             SET Fname=@fn,
                                 Lname=@ln,
                                 Email=@em,
                                 BirthDate=@bd
                             WHERE PersonID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", p.PersonID);
                cmd.Parameters.AddWithValue("@fn", p.Fname);
                cmd.Parameters.AddWithValue("@ln", p.Lname);
                cmd.Parameters.AddWithValue("@em", p.Email);
                cmd.Parameters.AddWithValue("@bd", p.BirthDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE 
        public void DeletePerson(int id)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "DELETE FROM Person WHERE PersonID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}