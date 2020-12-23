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
  
    public partial class ReprotFrom : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public ReprotFrom()
        {
            InitializeComponent();
        }
        public List<Supplier> supplier { get; private set; }
        private void ReprotFrom_Load(object sender, EventArgs e)
        {
            using (var conn1 = new SqlConnection(conStr))
            {
                var cmd = conn1.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From Supplier";
                conn1.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //var rdr = cmd.ExecuteReader(); 
                //dt.Load(rdr, LoadOption.Upsert);
                List<Supplier> orders = new List<Supplier>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Supplier obj = new Supplier();
                    obj.SupplierID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                    obj.GoodsID = Convert.ToInt32(dt.Rows[i]["GoodsID"].ToString());
                    obj.SupplyDate = Convert.ToDateTime(dt.Rows[i]["SupplyDate"].ToString());

                    obj.SupplierPrice = Convert.ToInt32(dt.Rows[i]["SupplierPrice"].ToString());
                    obj.SupplierName = dt.Rows[i]["SupplierName"].ToString();
                    obj.SupplierType = dt.Rows[i]["SupplierType"].ToString();
                    obj.SupplierAddress = dt.Rows[i]["SupplierAddress"].ToString();
                    orders.Add(obj);
                }

                using (PrintReport prForm = new PrintReport(orders))
                {
                    prForm.ShowDialog();
                }

            }
        }

        private void ReprotFrom_Load_1(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            using (var conn1 = new SqlConnection(conStr))
            {
                var cmd = conn1.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From Supplier";
                conn1.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //var rdr = cmd.ExecuteReader(); 
                //dt.Load(rdr, LoadOption.Upsert);
                List<Supplier> suppliers = new List<Supplier>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Supplier obj = new Supplier();
                    obj.SupplierID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                    obj.SupplierName = dt.Rows[i]["SupplierName"].ToString();
                    obj.SupplierType = dt.Rows[i]["SupplierType"].ToString();
                   obj.SupplierAddress = dt.Rows[i]["SupplierAddress"].ToString();
                    obj.SupplyDate = Convert.ToDateTime(dt.Rows[i]["SupplyDate"].ToString());
                    obj.SupplierPrice = Convert.ToDecimal(dt.Rows[i]["SupplierPrice"].ToString());
                     obj.GoodsID = Convert.ToInt32(dt.Rows[i]["GoodsID"].ToString());
                    suppliers.Add(obj);
                }

                using (PrintReport prForm = new PrintReport(suppliers))
                {
                    prForm.ShowDialog();
                }

            }
        }
    }
}
