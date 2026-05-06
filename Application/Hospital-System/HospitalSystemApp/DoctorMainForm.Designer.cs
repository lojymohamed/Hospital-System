namespace HospitalSystemApp
{
    partial class DoctorMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnAssignNurse = new System.Windows.Forms.Button();
            this.cmbNurse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManagePatients = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNurseServiceType = new System.Windows.Forms.ComboBox();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnCompleted = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(55, 466);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 38);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnAssignNurse
            // 
            this.btnAssignNurse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAssignNurse.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignNurse.Location = new System.Drawing.Point(798, 399);
            this.btnAssignNurse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAssignNurse.Name = "btnAssignNurse";
            this.btnAssignNurse.Size = new System.Drawing.Size(144, 39);
            this.btnAssignNurse.TabIndex = 2;
            this.btnAssignNurse.Text = "Assign Nurse";
            this.btnAssignNurse.UseVisualStyleBackColor = false;
            this.btnAssignNurse.Click += new System.EventHandler(this.btnAssignNurse_Click);
            // 
            // cmbNurse
            // 
            this.cmbNurse.FormattingEnabled = true;
            this.cmbNurse.Location = new System.Drawing.Point(191, 408);
            this.cmbNurse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNurse.Name = "cmbNurse";
            this.cmbNurse.Size = new System.Drawing.Size(233, 24);
            this.cmbNurse.TabIndex = 5;
            this.cmbNurse.SelectedIndexChanged += new System.EventHandler(this.cmbNurse_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Assign Nurse:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnManagePatients
            // 
            this.btnManagePatients.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnManagePatients.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagePatients.Location = new System.Drawing.Point(349, 524);
            this.btnManagePatients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManagePatients.Name = "btnManagePatients";
            this.btnManagePatients.Size = new System.Drawing.Size(150, 42);
            this.btnManagePatients.TabIndex = 7;
            this.btnManagePatients.Text = "Manage Patients";
            this.btnManagePatients.UseVisualStyleBackColor = false;
            this.btnManagePatients.Click += new System.EventHandler(this.btnManagePatients_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(205, 524);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(101, 42);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(55, 524);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 42);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Service Type:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbNurseServiceType
            // 
            this.cmbNurseServiceType.FormattingEnabled = true;
            this.cmbNurseServiceType.Location = new System.Drawing.Point(543, 407);
            this.cmbNurseServiceType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNurseServiceType.Name = "cmbNurseServiceType";
            this.cmbNurseServiceType.Size = new System.Drawing.Size(233, 24);
            this.cmbNurseServiceType.TabIndex = 11;
            this.cmbNurseServiceType.SelectedIndexChanged += new System.EventHandler(this.cmbNurseServiceType_SelectedIndexChanged);
            // 
            // dgvRequests
            // 
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Location = new System.Drawing.Point(55, 80);
            this.dgvRequests.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.RowHeadersWidth = 62;
            this.dgvRequests.RowTemplate.Height = 28;
            this.dgvRequests.Size = new System.Drawing.Size(887, 295);
            this.dgvRequests.TabIndex = 12;
            this.dgvRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvRequests.SelectionChanged += new System.EventHandler(this.dgvRequests_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(439, 35);
            this.label3.TabIndex = 13;
            this.label3.Text = "Doctor Dashboard - Service Request";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Red;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(205, 466);
            this.btnReject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(101, 38);
            this.btnReject.TabIndex = 14;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnCompleted
            // 
            this.btnCompleted.BackColor = System.Drawing.Color.Gray;
            this.btnCompleted.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleted.ForeColor = System.Drawing.Color.Black;
            this.btnCompleted.Location = new System.Drawing.Point(349, 466);
            this.btnCompleted.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(113, 38);
            this.btnCompleted.TabIndex = 15;
            this.btnCompleted.Text = "Completed";
            this.btnCompleted.UseVisualStyleBackColor = false;
            this.btnCompleted.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // DoctorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 597);
            this.Controls.Add(this.btnCompleted);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.cmbNurseServiceType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManagePatients);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNurse);
            this.Controls.Add(this.btnAssignNurse);
            this.Controls.Add(this.btnAccept);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DoctorMainForm";
            this.Text = "Doctor Main Form";
            this.Load += new System.EventHandler(this.DoctorMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnAssignNurse;
        private System.Windows.Forms.ComboBox cmbNurse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManagePatients;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNurseServiceType;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnCompleted;
    }
}