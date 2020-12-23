using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierType { get; set; }
        public string SupplierAddress { get; set; }
        public DateTime SupplyDate { get; set; }
        public decimal SupplierPrice { get; set; }
        public int GoodsID { get; set; }
    }
}
