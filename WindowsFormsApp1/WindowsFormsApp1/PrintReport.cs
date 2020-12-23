using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PrintReport : Form
    {
        List<Supplier> _list;
        public PrintReport(List<Supplier>suppliers)
        {
            InitializeComponent();
            _list = suppliers;
        }

        private void PrintReport_Load(object sender, EventArgs e)
        {
            SupplierInfomation rpt = new SupplierInfomation();
            rpt.SetDataSource(_list);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
