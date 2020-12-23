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
    public partial class LogIn : Form
    {
        string constr1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            
        }
            private void btnNext_Click(object sender, EventArgs e)
            {
                Home logIn = new Home();
                logIn.Show();
                this.Hide();
            }


            private void btnRegister_Click(object sender, EventArgs e)
            {
                Registration R = new Registration();
                R.Show();
                this.Hide();
            }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(constr1))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string UserName = txtUserName.Text;
                string Password = txtPassword.Text;
                cmd.CommandText = "Select * From login2 where UserName='" + UserName + "' And Password='" + Password + "'";
                conn.Open();
                try
                {
                    var dt = new DataTable();
                    var rdr = cmd.ExecuteReader();
                    dt.Load(rdr, LoadOption.Upsert);
                    if (dt.Rows.Count > 0)
                    {
                        Home h = new Home();
                        h.Show();
                        this.Hide();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Password");

                }

            }
        }
    } 
}
