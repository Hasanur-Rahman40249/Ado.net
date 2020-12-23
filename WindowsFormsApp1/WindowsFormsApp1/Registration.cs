using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Registration : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public Registration()
        {
            InitializeComponent();
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            LoadRegistration();
        }

        private void LoadRegistration()
        {
            using (var conn = new SqlConnection(constr))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From Registration";
                conn.Open();
                var dt = new DataTable();
                var rdr = cmd.ExecuteReader();
                dt.Load(rdr, LoadOption.Upsert);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LogIn h = new LogIn();
            h.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Registation obj = new Registation();
            obj.FirstName = textBox1.Text;
            obj.LastName = textBox2.Text;
            obj.Contact = textBox3.Text;
            obj.Address = textBox4.Text;
            obj.Username = textBox5.Text;
            obj.Password = textBox6.Text;
            var i = 7;
            var j = 11;
            if (textBox1.Text == "" || textBox6.Text == "")
                MessageBox.Show("Required field cannot be empty");
            else if (textBox6.Text != textBox7.Text)
                MessageBox.Show("Pasword does not match");
            else if (textBox6.Text.Length < i)
                MessageBox.Show("Password must be more than 6 characters long");
            else if (textBox3.Text.Length != j)
                MessageBox.Show("Phone number should contain 11 digits");
            else
            {
                using (var con = new SqlConnection(constr))
                {
                    int count = 0;
                    var cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Registration (FirstName, LastName, Contact, Address, Username, Password) " +
                    "VALUES('" + obj.FirstName + "','" + obj.LastName + "','" + obj.Contact + "','" + obj.Address + "','" + obj.Username + "','" + obj.Password + "')";
                    con.Open();
                    count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show(" Registration Completed successfully.");
                        this.Hide();
                        LogIn login = new LogIn();
                        login.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error occured.");
                    }
                    ClearAll();
                }
            }
        }

        private void ClearAll()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }


        private void txtRegistrationID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
