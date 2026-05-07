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
    public partial class PatientEntryForm : Form
    {
        private int _patientID;

        // Constructor accepts the PatientID from the Main Form
        public PatientEntryForm(int patientID)
        {
            InitializeComponent();
            _patientID = patientID;
            this.Opacity = 0;
        }

        private void PatientEntryForm_Load(object sender, EventArgs e)
        {
            FillDoctorComboBox();
            FillServiceTypeComboBox();
            dtpDate.Value = DateTime.Today;

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

        private void FillDoctorComboBox()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string sql = @"SELECT P.PersonID, P.Fname + ' ' + P.Lname AS Name
                           FROM Doctor D
                           JOIN Person P ON D.DoctorID = P.PersonID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("PersonID", typeof(int));
                dt.Columns.Add("Name", typeof(string));

                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row["PersonID"] = reader["PersonID"];
                    row["Name"] = reader["Name"];
                    dt.Rows.Add(row);
                }

                reader.Close();

                // Add a placeholder row at the top
                DataRow placeholder = dt.NewRow();
                placeholder["PersonID"] = DBNull.Value;
                placeholder["Name"] = "-- Select a Doctor --";
                dt.Rows.InsertAt(placeholder, 0);

                cmbDoctor.DataSource = dt;
                cmbDoctor.DisplayMember = "Name";
                cmbDoctor.ValueMember = "PersonID";
                cmbDoctor.SelectedIndex = 0;
            }
        }

        private void FillServiceTypeComboBox()
        {
            cmbServiceType.Items.Clear();
            cmbServiceType.Items.Add("-- Select Service Type --");
            cmbServiceType.Items.Add("General Checkup");
            cmbServiceType.Items.Add("Surgery");
            cmbServiceType.Items.Add("Radiology");
            cmbServiceType.Items.Add("Emergency");
            cmbServiceType.SelectedIndex = 0;
        }

        private bool ValidateInputs()
        {
            // Doctor must be selected (not placeholder)
            if (cmbDoctor.SelectedIndex == 0 || cmbDoctor.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Please select a doctor.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDoctor.Focus();
                return false;
            }

            // Service type must be selected (not placeholder)
            if (cmbServiceType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a service type.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbServiceType.Focus();
                return false;
            }

            // Date cannot be in the past
            if (dtpDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Service date cannot be in the past.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Focus();
                return false;
            }

            return true;
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (!ValidateInputs()) return;
            btnSubmit.Enabled = false;
            btnSubmit.Text = "Submitting...";
            using (SqlConnection conn = DB.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); // Keeps data safe across 3 tables

                try
                {
                    // STEP 1: Insert into Services
                    string sqlService = "INSERT INTO Services (ServiceDate, Notes, PatientID) VALUES (@date, @notes, @pid); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd1 = new SqlCommand(sqlService, conn, trans);
                    SqlParameter paramDate = new SqlParameter("@date", dtpDate.Value);
                    cmd1.Parameters.Add(paramDate);
                    SqlParameter paramNotes = new SqlParameter("@notes", txtNote.Text);
                    cmd1.Parameters.Add(paramNotes);
                    SqlParameter paramPid = new SqlParameter("@pid", _patientID);
                    cmd1.Parameters.Add(paramPid);
                    int newServiceID = Convert.ToInt32(cmd1.ExecuteScalar());


                    trans.Commit(); // All 3 succeed together
                   
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Failed to submit: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Re-enable so user can try again
                    btnSubmit.Enabled = true;
                    btnSubmit.Text = "Submit";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Only ask if they've typed something
            bool hasInput = !string.IsNullOrWhiteSpace(txtNote.Text)
                         || cmbDoctor.SelectedIndex > 0
                         || cmbServiceType.SelectedIndex > 0;

            if (hasInput)
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to cancel? Your changes will be lost.",
                    "Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
