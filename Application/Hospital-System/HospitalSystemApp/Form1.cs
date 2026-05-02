using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalSystemApp.Models;
using HospitalSystemApp.Repos;

namespace HospitalSystemApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Initialize the repository
                PersonRepository repo = new PersonRepository();

                // 2. Create a test person object
                Person p = new Person()
                {
                    PersonID = 100,
                    Fname = "Test",
                    Lname = "User",
                    Email = "test@gmail.com",
                    BirthDate = new DateTime(1990, 1, 1)
                };

                // 3. Call the method to add them to the database
                repo.AddPerson(p);

                // 4. Success message!
                MessageBox.Show("Person inserted successfully!");
            }
            catch (Exception ex)
            {
                // If something goes wrong (like a connection error), this will tell you why
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
