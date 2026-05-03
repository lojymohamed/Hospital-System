using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using HospitalSystemApp.Models;

namespace HospitalSystemApp
{
    public partial class PatientMainForm : Form
    {
        private User _user;
        private DataTable dtServices = new DataTable();

        public PatientMainForm(User loggedInUser)
        {
            InitializeComponent();
            _user = loggedInUser;
        }

        private void PatientMainForm_Load(object sender, EventArgs e)
        {
            LoadPatientData();
        }

        private void LoadPatientData()
        {
          
            lblWelcome.Text = $"Welcome, {_user.Fname} {_user.Lname}";
            lblEmail.Text = _user.Email;

            LoadInsurance();

            LoadServices();
        }

        private void LoadInsurance()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                // Joins with Patient table implicitly via Foreign Key PatientID
                string sql = "SELECT CompanyName, CompanyType FROM Insurance WHERE PatientID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", _user.PersonID);

                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    lblInsCompany.Text = "Insurance: " + r["CompanyName"].ToString();
                    lblInsType.Text = "Policy: " + r["CompanyType"].ToString();
                }
            }
        }

        private void LoadServices()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                // SQL joining Services (S) and DoctorServices (DS)
                string sql = @"SELECT S.ServiceDate, S.Notes, DS.ServiceType 
                       FROM Services S 
                       LEFT JOIN DoctorServices DS ON S.ServiceID = DS.ServiceID 
                       WHERE S.PatientID = @id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@id", _user.PersonID);

                dtServices.Clear();
                da.Fill(dtServices);

                // Handle Empty State
                if (dtServices.Rows.Count == 0)
                {
                    dgvServices.Visible = false;
                    lblEmptyState.Visible = true; // Add a label with "No medical history found"
                    lblEmptyState.Text = "No medical history found.";
                }
                else
                {
                    dgvServices.Visible = true;
                    lblEmptyState.Visible = false;
                    dgvServices.DataSource = dtServices;
                }
            }
        }
       

        //  Show Doctors Involved 
        private void btnShowDoctors_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string sql = @"SELECT P.Fname, P.Lname, D.Name AS Department, DR.Shift 
                               FROM Doctor DR
                               JOIN Person P ON DR.DoctorID = P.PersonID
                               JOIN Department D ON DR.DepartmentID = D.DepartmentID";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dtDocs = new DataTable();
                da.Fill(dtDocs);
                dgvServices.DataSource = dtDocs;
            }
        }

        // Request Service
        private void btnRequestService_Click(object sender, EventArgs e)
        {
            PatientEntryForm entry = new PatientEntryForm(_user.PersonID);
            if (entry.ShowDialog() == DialogResult.OK)
            {
                LoadServices(); // Refresh grid
            }
        }
    }
}