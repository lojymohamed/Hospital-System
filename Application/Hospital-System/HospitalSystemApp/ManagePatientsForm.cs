using HospitalSystemApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemApp
{
    public partial class ManagePatientsForm : Form
    {
        private User _user;
        public ManagePatientsForm(User user)
        {
            InitializeComponent();
            _user = user;
        }
        private void ManagePatientsForm_Load(object sender, EventArgs e)
        {
            dgvPatients.MultiSelect = false;
            LoadPatients();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Clear();
            txtLName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtCompany.Clear();
            txtCoverage.Clear();

            dgvPatients.ClearSelection();
        }
        private int selectedPersonId = -1;

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPatients.Rows[e.RowIndex];

                selectedPersonId = Convert.ToInt32(row.Cells["PersonID"].Value);

                txtFName.Text = row.Cells["Fname"].Value.ToString();
                txtLName.Text = row.Cells["Lname"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtBirth.Text = row.Cells["BirthDate"].Value.ToString();
                txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString();
                txtCompany.Text = row.Cells["CompanyName"].Value.ToString();
                txtCoverage.Text = row.Cells["CompanyType"].Value.ToString();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int patientId = GetSelectedPatientID();
            if (patientId == -1)
            {
                MessageBox.Show("Please select a patient first!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill the required fields: First Name, Last Name, Email, and Phone!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DB.GetConnection())
            {
                conn.Open();

                string q1 = @"
                UPDATE Person
                SET Fname = @fname,
                Lname = @lname,
                Email = @email,
                BirthDate = @birth
                WHERE PersonID = @id";

                SqlCommand cmd1 = new SqlCommand(q1, conn);
                SqlParameter paramFname = new SqlParameter("@fname", txtFName.Text);
                cmd1.Parameters.Add(paramFname);
                SqlParameter paramLname = new SqlParameter("@lname", txtLName.Text);
                cmd1.Parameters.Add(paramLname);
                SqlParameter paramEmail = new SqlParameter("@email", txtEmail.Text);
                cmd1.Parameters.Add(paramEmail);
                SqlParameter paramBirth = new SqlParameter("@birth", txtBirth.Value);
                cmd1.Parameters.Add(paramBirth);
                SqlParameter paramId1 = new SqlParameter("@id", patientId);
                cmd1.Parameters.Add(paramId1);
                cmd1.ExecuteNonQuery();

                string q2 = @"
                UPDATE PersonPhone
                SET PhoneNumber = @phone
                WHERE PersonID = @id";

                SqlCommand cmd2 = new SqlCommand(q2, conn);
                SqlParameter paramPhone = new SqlParameter("@phone", txtPhone.Text);
                cmd2.Parameters.Add(paramPhone);
                SqlParameter paramId2 = new SqlParameter("@id", patientId);
                cmd2.Parameters.Add(paramId2);
                cmd2.ExecuteNonQuery();

                string q3 = @"
                IF EXISTS (SELECT 1 FROM Insurance WHERE PatientID = @id)
                    UPDATE Insurance
                    SET CompanyName = @company,
                        CompanyType = @coverage
                    WHERE PatientID = @id
                ELSE
                    INSERT INTO Insurance (PatientID, CompanyName, CompanyType)
                    VALUES (@id, @company, @coverage)";

                SqlCommand cmd3 = new SqlCommand(q3, conn);
                SqlParameter paramCompany = new SqlParameter("@company", string.IsNullOrWhiteSpace(txtCompany.Text) ? (object)DBNull.Value : txtCompany.Text);
                cmd3.Parameters.Add(paramCompany);
                SqlParameter paramCoverage = new SqlParameter("@coverage", string.IsNullOrWhiteSpace(txtCoverage.Text) ? (object)DBNull.Value : txtCoverage.Text);
                cmd3.Parameters.Add(paramCoverage);
                SqlParameter paramId3 = new SqlParameter("@id", patientId);
                cmd3.Parameters.Add(paramId3);
                cmd3.ExecuteNonQuery();
            }

            MessageBox.Show("Patient updated successfully!");

            LoadPatients();
        }
        private int GetSelectedPatientID()
        {
            if (dgvPatients.CurrentRow != null)
            {
                return Convert.ToInt32(dgvPatients.CurrentRow.Cells["PersonID"].Value);
            }
            return -1;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int patientId = GetSelectedPatientID();
            if (patientId == -1)
            {
                MessageBox.Show("Please select a patient.");
                return;
            }
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this patient and ALL related data?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            using (SqlConnection conn = DB.GetConnection())
            {
                conn.Open();

                string q1 = @"
                DELETE FROM NurseHisServices
                WHERE NS_ID IN (
                SELECT NS_ID FROM NurseServices
                WHERE ServiceID IN (
                SELECT ServiceID FROM Services WHERE PatientID = @id))";

                new SqlCommand(q1, conn)
                {
                    Parameters = { new SqlParameter("@id", patientId) }
                }.ExecuteNonQuery();
                string q2 = @"
                DELETE FROM NurseServices
                WHERE ServiceID IN (
                SELECT ServiceID FROM Services WHERE PatientID = @id)";
                new SqlCommand(q2, conn)
                {
                    Parameters = { new SqlParameter("@id", patientId) }
                }.ExecuteNonQuery();

                // 3. Doctor history
                string q3 = @"
                DELETE FROM DoctorHisServices
                WHERE DS_ID IN (
                SELECT DS_ID FROM DoctorServices
                WHERE ServiceID IN (
                SELECT ServiceID FROM Services WHERE PatientID = @id))";
                new SqlCommand(q3, conn)
                {
                    Parameters = { new SqlParameter("@id", patientId) }
                }.ExecuteNonQuery();
                string q4 = @"
                DELETE FROM DoctorServices
                WHERE ServiceID IN (
                SELECT ServiceID FROM Services WHERE PatientID = @id )";
                new SqlCommand(q4, conn)
                {
                    Parameters = { new SqlParameter("@id", patientId) }
                }.ExecuteNonQuery();
                string q5 = "DELETE FROM Services WHERE PatientID = @id";
                new SqlCommand(q5, conn)
                {
                    Parameters = { new SqlParameter("@id", patientId) }
                }.ExecuteNonQuery();
                string q6 = "DELETE FROM Insurance WHERE PatientID = @id";
                new SqlCommand(q6, conn)
                {
                    Parameters = { new SqlParameter("@id", patientId) }
                }.ExecuteNonQuery();
                string q7 = "DELETE FROM Person WHERE PersonID = @id";

                new SqlCommand(q7, conn)
                {
                    Parameters = { new SqlParameter("@id", patientId) }
                }.ExecuteNonQuery();
            }

            MessageBox.Show("Patient deleted successfully!");
            LoadPatients();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill the required fields: First Name, Last Name, Email, and Phone!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DB.GetConnection())
            {
                conn.Open();
                string insertPerson = @"
                INSERT INTO Person (Fname, Lname, Email, BirthDate)
                VALUES (@fname, @lname, @email, @birth);
                SELECT SCOPE_IDENTITY();";
                SqlCommand cmd1 = new SqlCommand(insertPerson, conn);
                SqlParameter paramFname = new SqlParameter("@fname", txtFName.Text);
                cmd1.Parameters.Add(paramFname);
                SqlParameter paramLname = new SqlParameter("@lname", txtLName.Text);
                cmd1.Parameters.Add(paramLname);
                SqlParameter paramEmail = new SqlParameter("@email", txtEmail.Text);
                cmd1.Parameters.Add(paramEmail);
                SqlParameter paramBirth = new SqlParameter("@birth", txtBirth.Value);
                cmd1.Parameters.Add(paramBirth);
                int personId = Convert.ToInt32(cmd1.ExecuteScalar());
                string insertPatient = @"
                INSERT INTO Patient (PatientID)
                VALUES (@id)";
                SqlCommand cmd2 = new SqlCommand(insertPatient, conn);
                SqlParameter paramId2 = new SqlParameter("@id", personId);
                cmd2.Parameters.Add(paramId2);
                cmd2.ExecuteNonQuery();
                string insertPhone = @"
                INSERT INTO PersonPhone (PersonID, PhoneNumber)
                VALUES (@id, @phone)";
                SqlCommand cmd3 = new SqlCommand(insertPhone, conn);
                SqlParameter paramId3 = new SqlParameter("@id", personId);
                cmd3.Parameters.Add(paramId3);
                SqlParameter paramPhone = new SqlParameter("@phone", txtPhone.Text);
                cmd3.Parameters.Add(paramPhone);
                cmd3.ExecuteNonQuery();

                if (!string.IsNullOrWhiteSpace(txtCompany.Text) || !string.IsNullOrWhiteSpace(txtCoverage.Text))
                {
                    string insertInsurance = @"
                    INSERT INTO Insurance (PatientID, CompanyName, CompanyType)
                    VALUES (@id, @company, @coverage)";
                    SqlCommand cmd4 = new SqlCommand(insertInsurance, conn);
                    SqlParameter paramId4 = new SqlParameter("@id", personId);
                    cmd4.Parameters.Add(paramId4);
                    SqlParameter paramCompany = new SqlParameter("@company", string.IsNullOrWhiteSpace(txtCompany.Text) ? (object)DBNull.Value : txtCompany.Text);
                    cmd4.Parameters.Add(paramCompany);
                    SqlParameter paramCoverage = new SqlParameter("@coverage", string.IsNullOrWhiteSpace(txtCoverage.Text) ? (object)DBNull.Value : txtCoverage.Text);
                    cmd4.Parameters.Add(paramCoverage);
                    cmd4.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Patient added successfully!");

            LoadPatients();
        }

        private void LoadPatients()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"
                SELECT
                    P.PersonID,
                    P.Fname,
                    P.Lname,
                    P.Email,
                    P.BirthDate,
                    PH.PhoneNumber,
                    I.CompanyName,
                    I.CompanyType
                    FROM Person P
                    INNER JOIN Patient PT ON P.PersonID = PT.PatientID
                    LEFT JOIN PersonPhone PH ON P.PersonID = PH.PersonID
                    LEFT JOIN Insurance I ON PT.PatientID = I.PatientID";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("PersonID", typeof(int));
                dt.Columns.Add("Fname", typeof(string));
                dt.Columns.Add("Lname", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("BirthDate", typeof(DateTime));
                dt.Columns.Add("PhoneNumber", typeof(string));
                dt.Columns.Add("CompanyName", typeof(string));
                dt.Columns.Add("CompanyType", typeof(string));

                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row["PersonID"] = reader["PersonID"];
                    row["Fname"] = reader["Fname"];
                    row["Lname"] = reader["Lname"];
                    row["Email"] = reader["Email"];
                    row["BirthDate"] = reader["BirthDate"];
                    row["PhoneNumber"] = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? (object)DBNull.Value : reader["PhoneNumber"];
                    row["CompanyName"] = reader.IsDBNull(reader.GetOrdinal("CompanyName")) ? (object)DBNull.Value : reader["CompanyName"];
                    row["CompanyType"] = reader.IsDBNull(reader.GetOrdinal("CompanyType")) ? (object)DBNull.Value : reader["CompanyType"];
                    dt.Rows.Add(row);
                }

                reader.Close();
                dgvPatients.DataSource = dt;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCountPatients_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Patient";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Number of Patients : " + count.ToString());
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
