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
using System.Data;
using System.Data.SqlClient;

namespace POSDemo.Screens.All_Sales
{
    public partial class Salses : Form
    {
        POSTutEntities db = new POSTutEntities();
        

        public Salses()
        {
            InitializeComponent();
            
            var context = new POSDemo.DB.POSTutEntities();

            var paramreturn = new SqlParameter
            {
                ParameterName = "ReturnValue",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
              


              // dataGridView1.DataSource = db.Database.ExecuteSqlCommand("EXEC purchasreProc") ;
              //MessageBox.Show(res);
            //using (var dbb = new POSTutEntities())
            //{
            //    var res = db.SalesProc();
                
            //}

            
            
          //  DbRowSqlquery<string> procreturn = db.Database.SqlQuery<string>("EXEC purchasreProc");
        }

        private void Salses_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet12.SalesProc' table. You can move, or remove it, as needed.
            this.salesProcTableAdapter.Fill(this.pOSTutDataSet12.SalesProc);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

    }
}
