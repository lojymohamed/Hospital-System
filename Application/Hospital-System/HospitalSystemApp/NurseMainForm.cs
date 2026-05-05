using HospitalSystemApp;
using HospitalSystemApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

public partial class NurseMainForm : Form
{
    private Label lblTitle;
    private DataGridView dgvTasks;
    private Button btnRefresh;
    private Button BtnLogout;
    private Label lblStatus;
    private int _nurseId;

    public NurseMainForm(User user)
    {
        _nurseId = user.PersonID;
        InitializeComponent();
        LoadTasks();
    }

    public NurseMainForm(int nurseId)
    {
        _nurseId = nurseId;
        InitializeComponent();
        LoadTasks();
    }

    private void BtnRefresh_Click(object sender, EventArgs e)
    {
        LoadTasks();
    }

    private void BtnLogout_Click(object sender, EventArgs e)
    {
        LoginForm login = new LoginForm();
        login.Show();
        this.Close();
    }

    private void LoadTasks()
    {
        using (SqlConnection conn = DB.GetConnection())
        {
            string sql = @"
                SELECT S.ServiceDate, NS.ServiceType, S.Notes,
                       P.Fname + ' ' + P.Lname AS PatientName
                FROM NurseHisServices NH
                JOIN NurseServices NS ON NH.NS_ID = NS.NS_ID
                JOIN Services S ON NS.ServiceID = S.ServiceID
                JOIN Patient Pat ON S.PatientID = Pat.PatientID
                JOIN Person P ON Pat.PatientID = P.PersonID
                WHERE NH.NurseID = @nid
                ORDER BY S.ServiceDate DESC";

            DataTable dt = new DataTable();
            dt.Columns.Add("ServiceDate", typeof(DateTime));
            dt.Columns.Add("ServiceType", typeof(string));
            dt.Columns.Add("Notes", typeof(string));
            dt.Columns.Add("PatientName", typeof(string));

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nid", _nurseId);
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DataRow row = dt.NewRow();
                row["ServiceDate"] = r["ServiceDate"];
                row["ServiceType"] = r["ServiceType"];
                row["Notes"] = r["Notes"];
                row["PatientName"] = r["PatientName"];
                dt.Rows.Add(row);
            }
            r.Close();

            dgvTasks.DataSource = dt;

            if (dt.Rows.Count == 0)
                lblStatus.Text = "No assigned services found.";
            else
                lblStatus.Text = $"Showing {dt.Rows.Count} service(s).";
        }
    }

    private void InitializeComponent()
    {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(46, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(249, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Assigned Services";
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(43, 86);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.RowTemplate.Height = 24;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(541, 217);
            this.dgvTasks.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(43, 347);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 38);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnLogout
            // 
            this.BtnLogout.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogout.Location = new System.Drawing.Point(199, 347);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(117, 38);
            this.BtnLogout.TabIndex = 3;
            this.BtnLogout.Text = "Logout";
            this.BtnLogout.UseVisualStyleBackColor = true;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(39, 321);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 23);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "label1";
            // 
            // NurseMainForm
            // 
            this.ClientSize = new System.Drawing.Size(647, 434);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.BtnLogout);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.lblTitle);
            this.Name = "NurseMainForm";
            this.Load += new System.EventHandler(this.NurseMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void NurseMainForm_Load(object sender, EventArgs e)
    {

    }
}
