using  POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo.Screens.All_Purchase
{
   
    public partial class purchase : Form
    {
        POSTutEntities db = new POSTutEntities(); 
        public purchase()
        {
            InitializeComponent();
          
        }

        private void purchase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet11.purchasreProc' table. You can move, or remove it, as needed.
            this.purchasreProcTableAdapter.Fill(this.pOSTutDataSet11.purchasreProc);

        }
    }
}
