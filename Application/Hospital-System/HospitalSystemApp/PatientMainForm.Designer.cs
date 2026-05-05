namespace HospitalSystemApp
{
    partial class PatientMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.lblInsCompany = new System.Windows.Forms.Label();
            this.lblInsType = new System.Windows.Forms.Label();
            this.btnRequestService = new System.Windows.Forms.Button();
            this.btnShowDoctors = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEmptyState = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(8, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(92, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "label1";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(146, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(92, 32);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "label1";
            // 
            // dgvServices
            // 
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServices.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(50, 129);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.RowHeadersWidth = 51;
            this.dgvServices.RowTemplate.Height = 24;
            this.dgvServices.Size = new System.Drawing.Size(672, 173);
            this.dgvServices.TabIndex = 4;
            this.dgvServices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServices_CellContentClick);
            // 
            // lblInsCompany
            // 
            this.lblInsCompany.AutoSize = true;
            this.lblInsCompany.Location = new System.Drawing.Point(25, 30);
            this.lblInsCompany.Name = "lblInsCompany";
            this.lblInsCompany.Size = new System.Drawing.Size(44, 16);
            this.lblInsCompany.TabIndex = 5;
            this.lblInsCompany.Text = "label1";
            // 
            // lblInsType
            // 
            this.lblInsType.AutoSize = true;
            this.lblInsType.Location = new System.Drawing.Point(25, 66);
            this.lblInsType.Name = "lblInsType";
            this.lblInsType.Size = new System.Drawing.Size(44, 16);
            this.lblInsType.TabIndex = 6;
            this.lblInsType.Text = "label1";
            // 
            // btnRequestService
            // 
            this.btnRequestService.BackColor = System.Drawing.Color.Khaki;
            this.btnRequestService.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.btnRequestService.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnRequestService.Location = new System.Drawing.Point(590, 339);
            this.btnRequestService.Name = "btnRequestService";
            this.btnRequestService.Size = new System.Drawing.Size(132, 59);
            this.btnRequestService.TabIndex = 7;
            this.btnRequestService.Text = "Request a Service";
            this.btnRequestService.UseVisualStyleBackColor = false;
            this.btnRequestService.Click += new System.EventHandler(this.btnRequestService_Click);
            // 
            // btnShowDoctors
            // 
            this.btnShowDoctors.Location = new System.Drawing.Point(607, 308);
            this.btnShowDoctors.Name = "btnShowDoctors";
            this.btnShowDoctors.Size = new System.Drawing.Size(115, 23);
            this.btnShowDoctors.TabIndex = 8;
            this.btnShowDoctors.Text = "Show Doctors";
            this.btnShowDoctors.UseVisualStyleBackColor = true;
            this.btnShowDoctors.Click += new System.EventHandler(this.btnShowDoctors_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInsCompany);
            this.groupBox1.Controls.Add(this.lblInsType);
            this.groupBox1.Location = new System.Drawing.Point(50, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 114);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insurance Info:";
            // 
            // lblEmptyState
            // 
            this.lblEmptyState.AutoSize = true;
            this.lblEmptyState.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmptyState.ForeColor = System.Drawing.Color.IndianRed;
            this.lblEmptyState.Location = new System.Drawing.Point(215, 207);
            this.lblEmptyState.Name = "lblEmptyState";
            this.lblEmptyState.Size = new System.Drawing.Size(302, 29);
            this.lblEmptyState.TabIndex = 10;
            this.lblEmptyState.Text = "No medical history found";
            this.lblEmptyState.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Location = new System.Drawing.Point(50, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 46);
            this.panel1.TabIndex = 12;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Salmon;
            this.btnLogout.Location = new System.Drawing.Point(647, 405);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 37);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // PatientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 513);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblEmptyState);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnShowDoctors);
            this.Controls.Add(this.btnRequestService);
            this.Controls.Add(this.dgvServices);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "PatientMainForm";
            this.Text = "PatientMainForm";
            this.Load += new System.EventHandler(this.PatientMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Label lblInsCompany;
        private System.Windows.Forms.Label lblInsType;
        private System.Windows.Forms.Button btnRequestService;
        private System.Windows.Forms.Button btnShowDoctors;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEmptyState;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
    }
}