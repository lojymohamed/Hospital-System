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
            FadeIn();
        }
        private async void FadeIn()
        {
            for (double i = 0; i <= 1.0; i += 0.05)
            {
                this.Opacity = i;
                await System.Threading.Tasks.Task.Delay(15);
            }
            this.Opacity = 1;
        }
        private async System.Threading.Tasks.Task FadeOut()
        {
            for (double i = 1.0; i >= 0; i -= 0.05)
            {
                this.Opacity = i;
                await System.Threading.Tasks.Task.Delay(15);
            }
            this.Opacity = 0;
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
                string sql = @"
                        SELECT
                            S.ServiceDate   AS [Date],
                            DS.ServiceType  AS [Type],
                            S.Status        AS [Status],
                            S.Notes         AS [Notes],
                            P.Fname + ' ' + P.Lname AS [Doctor]
                        FROM Services S
                        LEFT JOIN DoctorServices DS   ON S.ServiceID  = DS.ServiceID
                        LEFT JOIN DoctorHisServices H ON DS.DS_ID     = H.DS_ID
                        LEFT JOIN Person P            ON H.DoctorID   = P.PersonID
                        WHERE S.PatientID = @id
                        ORDER BY S.ServiceDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@id", _user.PersonID);

                dtServices.Clear();
                da.Fill(dtServices);

                if (dtServices.Rows.Count == 0)
                {
                    dgvServices.Visible = false;
                    lblEmptyState.Visible = true;
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

        private void btnShowDoctors_Click(object sender, EventArgs e)
        {
            DoctorsListForm doctorsForm = new DoctorsListForm();
            doctorsForm.ShowDialog();
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                await FadeOut();
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        private void btnRequestService_Click(object sender, EventArgs e)
        {
            PatientEntryForm entry = new PatientEntryForm(_user.PersonID);
            if (entry.ShowDialog() == DialogResult.OK)
            {
                LoadServices();
                MessageBox.Show("Service requested successfully!", "Done",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PatientMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && this.Opacity > 0)
            {
                e.Cancel = true;
                btnLogout_Click(sender, e);
            }
        }

        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
