using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class ImageLog : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        string imgLocation = "";
        public ImageLog()
        {
            InitializeComponent();
            LoadGridView();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ImageLog_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            byte[] pics = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            //to read
            BinaryReader br = new BinaryReader(stream);
            pics = br.ReadBytes((int)stream.Length);

            using (var con = new SqlConnection(conStr))
            {
                string file = imgLocation;
                string[] f = file.Split('\\');
                string fn = f[f.Length - 1];
                string dest = @"C:\Users\Hasanur Rahman\Desktop\1253570\images" + fn;
                File.Copy(file, dest, true);

                string query = "Insert INTO Images (ImageName, ImageUrl, Picture) VALUES ('" + fn + "','" + dest + "', @pics)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@pics", pics));

                con.Open();
                cmd.ExecuteNonQuery();
                LoadGridView();
            }
        }

        private void LoadGridView()
        {
            using (var con = new SqlConnection(conStr))
            {

                string query = "SELECT * FROM Images";
                SqlCommand cmd = new SqlCommand(query, con);


                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.RowTemplate.Height = 150;
                DataGridViewImageColumn imgcl = new DataGridViewImageColumn();
                imgcl = (DataGridViewImageColumn)dataGridView1.Columns[3];
                imgcl.ImageLayout = DataGridViewImageCellLayout.Stretch;
                sda.Dispose();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblid.Text);


            byte[] pics = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            //to read
            BinaryReader br = new BinaryReader(stream);
            pics = br.ReadBytes((int)stream.Length);

            using (var con = new SqlConnection(conStr))
            {
                string file = imgLocation;
                string[] f = file.Split('\\');
                string fn = f[f.Length - 1];
                string dest = @"C:\Users\Hasanur Rahman\Desktop\1253570\images" + fn;
                File.Copy(file, dest, true);

                string query = "Update Images SET ImageName = '" + fn + "', ImageUrl = '" + dest + "', Picture = @pics WHERE Id= '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@pics", pics));

                con.Open();
                cmd.ExecuteNonQuery();
                LoadGridView();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplierInfo SupplierInfo = new SupplierInfo();
            SupplierInfo.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            lblid.Text = id.ToString();
            byte[] data = (byte[])dataGridView1.SelectedRows[0].Cells[3].Value;

            MemoryStream ms = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(ms);
        }
    }
}
