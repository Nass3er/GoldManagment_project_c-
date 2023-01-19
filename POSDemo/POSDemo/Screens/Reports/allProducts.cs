using POSDemo.DB;
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
using System.Data;
using System.Data.Common;
namespace POSDemo.Screens.Reports
{
    
    public partial class allProducts : Form
    {
        POSTutEntities db = new POSTutEntities();
        
        POSDemo.DB.Product row;   // we define object from class products to get the data to it
        public allProducts()
        {
            InitializeComponent();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {// all product

            POSDemo.Screens.Products.product_report frm = new Products.product_report();
            // TODO: This line of code loads data into the 'pOSTutDataSet14.Product' table. You can move, or remove it, as needed.
           // this.productTableAdapter1.Fill(this.pOSTutDataSet14.Product);
            frm.showAllProduct(); // fpr show all product in the report
            frm.ShowDialog();
        }

        private void allProducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet14.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter1.Fill(this.pOSTutDataSet14.Product);
             
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productTableAdapter.FillBy(this.pOSTutDataSet9.Product);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            POSDemo.Screens.Products.product_report frm = new Products.product_report();
               
            int id =int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //frm.productTableAdapter = db.Product.SingleOrDefault(s => s.id == id);
            // da = new SqlDataAdapter( "select * from Product where id='" + id);
             
            using( var sqlcmd=db.Database.Connection.CreateCommand() ){
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = "select * from Product where id=" + id ;
                 
                    using (DbDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = sqlcmd;
                        da.Fill(frm.pOSTutDataSet8.Product);
                    }
                
            }
            //  frm.productTableAdapter.Fill(frm.pOSTutDataSet8.Product);
            frm.reportViewer1.RefreshReport();
            frm.ShowDialog();
        }
    }
}
