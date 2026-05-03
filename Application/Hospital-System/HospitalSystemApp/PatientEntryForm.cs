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
        }

        private void PatientEntryForm_Load(object sender, EventArgs e)
        {
            FillDoctorComboBox();
            FillServiceTypeComboBox();
        }

        private void FillDoctorComboBox()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                // Join Doctor and Person tables from your SQL schema
                string sql = @"SELECT P.PersonID, P.Fname + ' ' + P.Lname AS Name 
                           FROM Doctor D 
                           JOIN Person P ON D.DoctorID = P.PersonID";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbDoctor.DataSource = dt;
                cmbDoctor.DisplayMember = "Name";    // The doctor's name the patient sees
                cmbDoctor.ValueMember = "PersonID";   // The ID used for the database link
            }
        }

        private void FillServiceTypeComboBox()
        {
            // You can either pull these from a table or add them manually
            cmbServiceType.Items.Add("General Checkup");
            cmbServiceType.Items.Add("Surgery");
            cmbServiceType.Items.Add("Radiology");
            cmbServiceType.Items.Add("Emergency");
            cmbServiceType.SelectedIndex = 0; // Select the first one by default
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); // Keeps data safe across 3 tables

                try
                {
                    // STEP 1: Insert into Services
                    string sqlService = "INSERT INTO Services (ServiceDate, Notes, PatientID) VALUES (@date, @notes, @pid); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd1 = new SqlCommand(sqlService, conn, trans);
                    cmd1.Parameters.AddWithValue("@date", dtpDate.Value);
                    cmd1.Parameters.AddWithValue("@notes", txtNote.Text);
                    cmd1.Parameters.AddWithValue("@pid", _patientID);
                    int newServiceID = Convert.ToInt32(cmd1.ExecuteScalar());

                    // STEP 2: Insert into DoctorServices (The "Type")
                    string sqlDocService = "INSERT INTO DoctorServices (ServiceID, ServiceType) VALUES (@sid, @stype); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd2 = new SqlCommand(sqlDocService, conn, trans);
                    cmd2.Parameters.AddWithValue("@sid", newServiceID);
                    cmd2.Parameters.AddWithValue("@stype", cmbServiceType.Text);
                    int newDS_ID = Convert.ToInt32(cmd2.ExecuteScalar());

                    // STEP 3: Insert into DoctorHisServices (The "Doctor")
                    string sqlHis = "INSERT INTO DoctorHisServices (DS_ID, DoctorID) VALUES (@dsid, @did)";
                    SqlCommand cmd3 = new SqlCommand(sqlHis, conn, trans);
                    cmd3.Parameters.AddWithValue("@dsid", newDS_ID);
                    cmd3.Parameters.AddWithValue("@did", cmbDoctor.SelectedValue);
                    cmd3.ExecuteNonQuery();

                    trans.Commit(); // All 3 succeed together
                    MessageBox.Show("Service and Doctor assigned successfully!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback(); // If one fails, undo everything
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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
