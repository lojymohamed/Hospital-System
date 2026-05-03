using HospitalSystemApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HospitalSystemApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Sets a light gray hint inside the text box
            SendMessage(txtUsername.Handle, 0x1501, 0, "Enter your email");
            SendMessage(txtPassword.Handle, 0x1501, 0, "Enter password");
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.DodgerBlue; // Lighter shade
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.SteelBlue; // Original shade
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
  
            txtUsername.Clear();
            txtPassword.Clear();
      
            txtUsername.Focus();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthRepository auth = new AuthRepository();

            // txtPassword.Text will be used to enter the BirthDate (e.g., 1990-05-10)
            User currentUser = auth.Login(txtUsername.Text, txtPassword.Text);

            if (currentUser != null)
            {
                if (currentUser.Role == "Doctor")
                {
                    DoctorMainForm docForm = new DoctorMainForm();
                    docForm.Show();
                }
                else if (currentUser.Role == "Patient")
                {
                    PatientMainForm patForm = new PatientMainForm(currentUser);
                    patForm.Show();
                }
                else
                {
                    MessageBox.Show("User found, but no specific role assigned.");
                    return;
                }

                this.Hide(); // Close login window
            }
            else
            {
                MessageBox.Show("Invalid Email or Birth Date. Please try again.");
            }
        }
      

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
