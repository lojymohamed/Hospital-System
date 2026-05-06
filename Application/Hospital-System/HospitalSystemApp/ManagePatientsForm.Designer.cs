namespace HospitalSystemApp
{
    partial class ManagePatientsForm
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
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtCoverage = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtBirth = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Lable4 = new System.Windows.Forms.Label();
            this.Lable3 = new System.Windows.Forms.Label();
            this.Lable2 = new System.Windows.Forms.Label();
            this.Lable1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPatients
            // 
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Location = new System.Drawing.Point(35, 116);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.RowHeadersWidth = 62;
            this.dgvPatients.RowTemplate.Height = 28;
            this.dgvPatients.Size = new System.Drawing.Size(998, 369);
            this.dgvPatients.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(68, 946);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 34);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add Patient";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 946);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(129, 34);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete Patient";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(362, 946);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(138, 34);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update Patient";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(533, 946);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 34);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(667, 946);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 34);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Lable4);
            this.groupBox1.Controls.Add(this.Lable3);
            this.groupBox1.Controls.Add(this.Lable2);
            this.groupBox1.Controls.Add(this.Lable1);
            this.groupBox1.Controls.Add(this.txtLName);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtBirth);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtCompany);
            this.groupBox1.Controls.Add(this.txtCoverage);
            this.groupBox1.Controls.Add(this.txtFName);
            this.groupBox1.Location = new System.Drawing.Point(35, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(998, 342);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(175, 63);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(236, 26);
            this.txtFName.TabIndex = 0;
            // 
            // txtCoverage
            // 
            this.txtCoverage.Location = new System.Drawing.Point(656, 189);
            this.txtCoverage.Name = "txtCoverage";
            this.txtCoverage.Size = new System.Drawing.Size(236, 26);
            this.txtCoverage.TabIndex = 1;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(656, 127);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(236, 26);
            this.txtCompany.TabIndex = 2;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(656, 63);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(236, 26);
            this.txtPhone.TabIndex = 3;
            // 
            // txtBirth
            // 
            this.txtBirth.Location = new System.Drawing.Point(175, 266);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(236, 26);
            this.txtBirth.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(175, 198);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(236, 26);
            this.txtEmail.TabIndex = 5;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(175, 127);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(236, 26);
            this.txtLName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(38, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 46);
            this.label1.TabIndex = 20;
            this.label1.Text = "Patient Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Coverage:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Insurance Company:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Phone Number:";
            this.label5.Click += new System.EventHandler(this.label4_Click);
            // 
            // Lable4
            // 
            this.Lable4.AutoSize = true;
            this.Lable4.Location = new System.Drawing.Point(53, 272);
            this.Lable4.Name = "Lable4";
            this.Lable4.Size = new System.Drawing.Size(71, 20);
            this.Lable4.TabIndex = 24;
            this.Lable4.Text = "Birthday:";
            // 
            // Lable3
            // 
            this.Lable3.AutoSize = true;
            this.Lable3.Location = new System.Drawing.Point(53, 204);
            this.Lable3.Name = "Lable3";
            this.Lable3.Size = new System.Drawing.Size(52, 20);
            this.Lable3.TabIndex = 25;
            this.Lable3.Text = "Email:";
            // 
            // Lable2
            // 
            this.Lable2.AutoSize = true;
            this.Lable2.Location = new System.Drawing.Point(53, 133);
            this.Lable2.Name = "Lable2";
            this.Lable2.Size = new System.Drawing.Size(90, 20);
            this.Lable2.TabIndex = 26;
            this.Lable2.Text = "Last Name:";
            // 
            // Lable1
            // 
            this.Lable1.AutoSize = true;
            this.Lable1.Location = new System.Drawing.Point(53, 63);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new System.Drawing.Size(90, 20);
            this.Lable1.TabIndex = 27;
            this.Lable1.Text = "First Name:";
            // 
            // ManagePatientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 1015);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvPatients);
            this.Name = "ManagePatientsForm";
            this.Text = "ManagePatientsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Lable4;
        private System.Windows.Forms.Label Lable3;
        private System.Windows.Forms.Label Lable2;
        private System.Windows.Forms.Label Lable1;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtBirth;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtCoverage;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label label1;
    }
}