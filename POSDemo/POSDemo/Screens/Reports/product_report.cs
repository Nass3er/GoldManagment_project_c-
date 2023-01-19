using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo.Screens.Products
{
    public partial class product_report : Form
    {
        public product_report()
        {
            InitializeComponent();
        }
        public void showAllProduct() {
            this.productTableAdapter.Fill(this.pOSTutDataSet8.Product);

            this.reportViewer1.RefreshReport();
        }
        private void product_report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet8.Product' table. You can move, or remove it, as needed.
            //this.productTableAdapter.Fill(this.pOSTutDataSet8.Product);

            //this.reportViewer1.RefreshReport();
        }
    }
}
