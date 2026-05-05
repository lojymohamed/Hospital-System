using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

public partial class DoctorsListForm : Form
{
    public DoctorsListForm()
    {
        InitializeComponent();
        LoadDoctors();
    }

    private void BtnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void LoadDoctors()
    {
        using (SqlConnection conn = DB.GetConnection())
        {
            string sql = @"SELECT D.DoctorID, P.Fname + ' ' + P.Lname AS Name,
                           P.Email, D.Shift, Dept.Name AS Department, Dept.Location
                           FROM Doctor D
                           JOIN Person P ON D.DoctorID = P.PersonID
                           LEFT JOIN Department Dept ON D.DepartmentID = Dept.DepartmentID";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDoctors.DataSource = dt;
        }
    }

    private void InitializeComponent()
    {
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvDoctors = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(486, 314);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 38);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // dgvDoctors
            // 
            this.dgvDoctors.AllowUserToAddRows = false;
            this.dgvDoctors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctors.Location = new System.Drawing.Point(62, 72);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.RowHeadersWidth = 51;
            this.dgvDoctors.RowTemplate.Height = 24;
            this.dgvDoctors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctors.Size = new System.Drawing.Size(541, 217);
            this.dgvDoctors.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(65, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(247, 38);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Available Doctors";
            // 
            // DoctorsListForm
            // 
            this.ClientSize = new System.Drawing.Size(661, 392);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.lblTitle);
            this.Name = "DoctorsListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private Button btnClose;
    private DataGridView dgvDoctors;
    private Label lblTitle;
}
