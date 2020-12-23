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
    public partial class SupplierInfo : Form
    {
        string conStr1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public SupplierInfo()
        {
            InitializeComponent();
            LoadcmbSupplierType();
        }

        private void LoadcmbSupplierType()
        {
            using (var conn = new SqlConnection(conStr1))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Supplier";
                conn.Open();
                var dt = new DataTable();
                var rdr = cmd.ExecuteReader();
                dt.Load(rdr, LoadOption.Upsert);
                cmbSupplierType.ValueMember = "SupplierType";
                cmbSupplierType.DisplayMember = "SupplierType";
                cmbSupplierType.DataSource = dt;

            }
        }

        private void SupplierInfo_Load(object sender, EventArgs e)
        {
            LoadSupplierInfoDVG();
        }

        private void LoadSupplierInfoDVG()
        {
            using (var conn = new SqlConnection(conStr1))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Supplier";
                conn.Open();
                var dt = new DataTable();
                var rdr = cmd.ExecuteReader();
                dt.Load(rdr, LoadOption.Upsert);
                if (dt != null)
                {
                    dgvSupplierInfo.DataSource = dt;
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Supplier obj = new Supplier();
            try
            {
                obj.SupplierID = Convert.ToInt16(txtSupplierID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid SupplierID");
            }
            obj.SupplierName = txtSupplierName.Text;
            obj.SupplierType = cmbSupplierType.Text;
            obj.SupplierAddress = txtSupplierAddress.Text;
            obj.SupplyDate = Convert.ToDateTime(dtpSupplyDate.Text);
            obj.SupplierPrice = Convert.ToDecimal(txtSupplierPrice.Text);
            try
            {
                obj.GoodsID = Convert.ToInt16(txtGoodsID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid GoodsID");
            }
            using (var conn = new SqlConnection(conStr1))
            {
                int count = 0;
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Supplier(SupplierID,SupplierName,SupplierType,SupplierAddress,SupplyDate, SupplierPrice,GoodsID)Values('" + obj.SupplierID + "','" + obj.SupplierName + "','" + obj.SupplierType + "','" + obj.SupplierAddress + "','"+obj.SupplyDate+"','"+obj.SupplierPrice+"','" + obj.GoodsID + "')";
                conn.Open();
                count = cmd.ExecuteNonQuery();
                if (count>0)
                {
                    MessageBox.Show("Data inserted successfuly");
                }
                else
                {
                    MessageBox.Show("Error occured");
                }
                LoadSupplierInfoDVG();
                ClearAll();
            }
        }

        private void ClearAll()
        {
            txtSupplierID.Text = "";
            txtSupplierName.Text = "";
            cmbSupplierType.Text = "";
            txtSupplierAddress.Text = "";
            dtpSupplyDate.Text = "";
            txtSupplierPrice.Text = "";
            txtGoodsID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Supplier obj = new Supplier();
            try
            {
                obj.SupplierID = Convert.ToInt16(txtSupplierID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid SupplierID");
            }
            obj.SupplierName = txtSupplierName.Text;
            obj.SupplierType = cmbSupplierType.Text;
            obj.SupplierAddress = txtSupplierAddress.Text;
            obj.SupplyDate = Convert.ToDateTime(dtpSupplyDate.Text);
            obj.SupplierPrice = Convert.ToDecimal(txtSupplierPrice.Text);
            try
            {
                obj.GoodsID = Convert.ToInt16(txtGoodsID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid GoodsID");
            }
            using (var conn = new SqlConnection(conStr1))
            {
                int count = 0;
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Supplier set SupplierName='" + obj.SupplierName + "', SupplierType='" + obj.SupplierType + "',SupplierAddress='" + obj.SupplierAddress + "',SupplyDate='" + obj.SupplyDate + "',SupplierPrice=''"+obj.SupplierPrice+",GoodsID='" + obj.GoodsID + "' where SupplierID='" + obj.SupplierID + "'";
                conn.Open();
                count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Data inserted successfuly");
                }
                else
                {
                    MessageBox.Show("Error occured");
                }
                LoadSupplierInfoDVG();
                ClearAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Supplier obj = new Supplier();
            try
            {
                obj.SupplierID = Convert.ToInt16(txtSupplierID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid SupplierID");
            }
            obj.SupplierName = txtSupplierName.Text;
            obj.SupplierType = cmbSupplierType.Text;
            obj.SupplierAddress = txtSupplierAddress.Text;
            obj.SupplyDate = Convert.ToDateTime(dtpSupplyDate.Text);
            obj.SupplierPrice = Convert.ToDecimal(txtSupplierPrice.Text);
            try
            {
                obj.GoodsID = Convert.ToInt16(txtGoodsID.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid GoodsID");
            }
            using (var conn = new SqlConnection(conStr1))
            {
                int count = 0;
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Supplier where SupplierID='" + obj.SupplierID + "'";
                conn.Open();
                count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Data inserted successfuly");
                }
                else
                {
                    MessageBox.Show("Error occured");
                }
                LoadSupplierInfoDVG();
                ClearAll();
            }
        }

        private void dgvSupplierInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cellId = e.RowIndex;
            DataGridViewRow row = dgvSupplierInfo.Rows[cellId];
            int gdID = Convert.ToInt16(row.Cells[1].Value.ToString());
            txtSupplierID.Text = gdID.ToString();
            txtSupplierName.Text = row.Cells[2].Value.ToString();
            cmbSupplierType.Text = row.Cells[3].Value.ToString();
            txtSupplierAddress.Text = row.Cells[4].Value.ToString();
            dtpSupplyDate.Text = row.Cells[5].Value.ToString();
            txtSupplierPrice.Text = row.Cells[6].Value.ToString();
            txtGoodsID.Text = row.Cells[7].Value.ToString();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            ReprotFrom ReprotFrom = new ReprotFrom();
            ReprotFrom.Show();
            this.Hide();
        }
    }
}
