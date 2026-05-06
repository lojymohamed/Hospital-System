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
using HospitalSystemApp.Models;

namespace HospitalSystemApp
{
    public partial class DoctorMainForm : Form
    {
        private User _user;

        public DoctorMainForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null) return;

            string status = dgvRequests.CurrentRow.Cells["Status"].Value.ToString();

            if (status == "Accepted")
            {
                btnCompleted.Enabled = true;
                btnAccept.Enabled = false;
                btnReject.Enabled = false;
            }
            else if (status == "Requested")
            {
                btnAccept.Enabled = true;
                btnReject.Enabled = true;
                btnCompleted.Enabled = false;
            }
            else if (status == "Rejected")
            {
                btnAccept.Enabled = false;
                btnReject.Enabled = false;
                btnCompleted.Enabled = false;
            }
            else if (status == "Completed")
            {
                btnAccept.Enabled = false;
                btnReject.Enabled = false;
                btnCompleted.Enabled = false;
            }
        }
        private void DoctorMainForm_Load(object sender, EventArgs e)
        {
            LoadNurses();
            LoadNurseServices();
            LoadServices();
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.MultiSelect = true;
            dgvRequests.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRequests_SelectionChanged(null, null);
        }
       
        private void cmbNurseServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadServices();
            LoadNurses();
            LoadNurseServices();

            MessageBox.Show("Data refreshed!");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
                var confirm = MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        private void btnManagePatients_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Go to Manage Patients?",
                "Navigation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                ManagePatientsForm form = new ManagePatientsForm();
                form.Show();
                this.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbNurse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAssignNurse_Click(object sender, EventArgs e)
        {
            int serviceId = GetSelectedServiceID();
            if (serviceId == -1) return;

            int nurseId = Convert.ToInt32(cmbNurse.SelectedValue);
            string serviceType = cmbNurseServiceType.Text;

            using (SqlConnection conn = DB.GetConnection())
            {
                conn.Open();

                // 1️⃣ Create NurseServices row (this generates NS_ID)
                string q1 = @"
            INSERT INTO NurseServices (ServiceID, ServiceType)
            VALUES (@sid, @type);
            SELECT SCOPE_IDENTITY();";

                SqlCommand cmd1 = new SqlCommand(q1, conn);
                cmd1.Parameters.AddWithValue("@sid", serviceId);
                cmd1.Parameters.AddWithValue("@type", serviceType);

                int ns_id = Convert.ToInt32(cmd1.ExecuteScalar());

                // 2️⃣ Insert into NurseHisServices
                string q2 = @"
            INSERT INTO NurseHisServices (NS_ID, NurseID)
            VALUES (@nsid, @nid)";

                SqlCommand cmd2 = new SqlCommand(q2, conn);
                cmd2.Parameters.AddWithValue("@nsid", ns_id);
                cmd2.Parameters.AddWithValue("@nid", nurseId);

                cmd2.ExecuteNonQuery();
            }

            MessageBox.Show("Nurse assigned successfully!");
        }
       private void btnReject_Click(object sender, EventArgs e)
        {
     
            int id = GetSelectedServiceID();
            if (id == -1) return;

            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "UPDATE Services SET Status = 'Rejected' WHERE ServiceID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadServices();
        }
       

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int id = GetSelectedServiceID();
            if (id == -1) return;

            using (SqlConnection conn = DB.GetConnection())
            {
                string query = "UPDATE Services SET Status = 'Accepted' WHERE ServiceID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadServices();

        }
        private void btnCompleted_Click(object sender, EventArgs e)
        {
            int id = GetSelectedServiceID();
            if (id == -1) return;

            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"
            UPDATE Services 
            SET Status = 'Completed' 
            WHERE ServiceID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadServices();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void LoadNurses()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"
            SELECT Nurse.NurseID,
                   Person.Fname + ' ' + Person.Lname AS FullName
            FROM Nurse
            JOIN Person ON Nurse.NurseID = Person.PersonID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNurse.DataSource = dt;
                cmbNurse.DisplayMember = "FullName";
                cmbNurse.ValueMember = "NurseID";
            }
        }
        private void LoadNurseServices()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"
            SELECT DISTINCT ServiceType
            FROM NurseServices
            ORDER BY ServiceType";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNurseServiceType.DataSource = dt;
                cmbNurseServiceType.DisplayMember = "ServiceType";
                cmbNurseServiceType.ValueMember = "ServiceType";
            }
        }
        private void LoadServices()
        {
            using (SqlConnection conn = DB.GetConnection())
            {
                string query = @"
            SELECT ServiceID, ServiceDate, PatientID, Notes, Status
            FROM Services";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRequests.DataSource = dt;
            }
        }
        private int GetSelectedServiceID()
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["ServiceID"].Value);
            }

            return -1;
        }
    }
}
