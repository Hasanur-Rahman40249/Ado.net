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
    public partial class Home : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadGoodsInfoDGV();
        }

        private void LoadGoodsInfoDGV()
        {
            using (var conn = new SqlConnection(conStr))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Goods";
                conn.Open();
                var dt = new DataTable();
                var rdr = cmd.ExecuteReader();
                dt.Load(rdr, LoadOption.Upsert);
                if (dt != null)
                {
                    dgvGoodsInfo.DataSource = dt;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Goods obj = new Goods();
            try
            {
                obj.GoodsID = Convert.ToInt16(txtGoodsID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid GoodsID");
            }
            obj.GoodsName = txtGoodsName.Text;
            obj.GoodsPrice = Convert.ToDecimal(txtGoodsQuantity.Text);
            try
            {
                obj.GoodsQuantity = Convert.ToInt16(txtGoodsQuantity.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invaild GoodsQuantity");
            }
            using (var conn = new SqlConnection(conStr))
            {
                int count = 0;
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Goods(GoodsID,GoodsName,GoodsQuantity,GoodsPrice) Values('" + obj.GoodsID + "','" + obj.GoodsName + "','" + obj.GoodsQuantity + "','" + obj.GoodsPrice + "')";
                conn.Open();
                count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Data inserted successfull");
                }
                else
                {
                    MessageBox.Show("Error occured");
                }
                LoadGoodsInfoDGV();
                ClearAll();
            }
        }

        private void ClearAll()
        {
            txtGoodsID.Text = "";
            txtGoodsName.Text = "";
            txtGoodsQuantity.Text = "";
            txtGoodsPrice.Text = "";
        }

        private void dgvGoodsInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cellId = e.RowIndex;
            DataGridViewRow row = dgvGoodsInfo.Rows[cellId];
            int gdID = Convert.ToInt16(row.Cells[1].Value.ToString());
            txtGoodsID.Text = gdID.ToString();
            txtGoodsName.Text = row.Cells[2].Value.ToString();
            txtGoodsQuantity.Text = row.Cells[3].Value.ToString();
            txtGoodsPrice.Text = row.Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Goods obj = new Goods();
            try
            {
                obj.GoodsID = Convert.ToInt16(txtGoodsID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid GoodsID");
            }
            obj.GoodsName = txtGoodsName.Text;
            obj.GoodsPrice = Convert.ToDecimal(txtGoodsQuantity.Text);
            try
            {
                obj.GoodsQuantity = Convert.ToInt16(txtGoodsQuantity.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invaild GoodsQuantity");
            }
            using (var conn = new SqlConnection(conStr))
            {
                int count = 0;
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Goods set GoodsName='" + obj.GoodsName + "', GoodsQuantity='" + obj.GoodsQuantity + "',GoodsPrice='" + obj.GoodsPrice + "' Where GoodsID='" + obj.GoodsID + "'";
                conn.Open();
                count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Data inserted successfull");
                }
                else
                {
                    MessageBox.Show("Error occured");
                }
                LoadGoodsInfoDGV();
                ClearAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Goods obj = new Goods();
            try
            {
                obj.GoodsID = Convert.ToInt16(txtGoodsID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid GoodsID");
            }
            obj.GoodsName = txtGoodsName.Text;
            obj.GoodsPrice = Convert.ToDecimal(txtGoodsPrice.Text);
            try
            {
                obj.GoodsQuantity = Convert.ToInt16(txtGoodsQuantity.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invaild GoodsQuantity");
            }


            using (var conn = new SqlConnection(conStr))
            {
                int count = 0;
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Goods where GoodsID='" + obj.GoodsID + "'";
                conn.Open();
                count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Data inserted successfull");
                }
                else
                {
                    MessageBox.Show("Error occured");
                }
                LoadGoodsInfoDGV();
                ClearAll();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ImageLog ImageLog = new ImageLog();
            ImageLog.Show();
            this.Hide();
        }
    }
}
