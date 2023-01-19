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

namespace POSDemo.Screens.Users
{
    public partial class UsersManagment : Form
    {
        POSTutEntities db = new POSTutEntities();
        public UsersManagment()
        {
            InitializeComponent();

           
            
        }

        private void UsersManagment_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.Users.ToList();
            
           // TODO: This line of code loads data into the 'pOSTutDataSet13.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.pOSTutDataSet13.Users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idd;
             
            bool r1,r2,r3,r4,r5,r6,r7,r8;
            for (int i = 0; i < dataGridView1.RowCount-1 ; i++ ) {
                idd = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                
                var row = db.Users.SingleOrDefault(x => x.id == idd);
                row.UserName = dataGridView1.Rows[i].Cells[1].Value.ToString();
                row.Password = dataGridView1.Rows[i].Cells[2].Value.ToString(); 
                
                row.Image = dataGridView1.Rows[i].Cells[3].Value.ToString();
 
                bool.TryParse(dataGridView1.Rows[i].Cells[4].Value.ToString(),out r1);
                row.control_users = r1;
                bool.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out r2);
                row.add_product = r2;
                bool.TryParse(dataGridView1.Rows[i].Cells[6].Value.ToString(),out r3);
                row.add_supplier = r3;
                bool.TryParse(dataGridView1.Rows[i].Cells[7].Value.ToString(),out r4);
                row.add_customer = r4;
                bool.TryParse(dataGridView1.Rows[i].Cells[8].Value.ToString(),out r5);
                row.add_invoice = r5;
                bool.TryParse(dataGridView1.Rows[i].Cells[9].Value.ToString(),out r6);
                row.add_report = r6;
                bool.TryParse(dataGridView1.Rows[i].Cells[10].Value.ToString(),out r7);
                row.edit_price = r7;
                bool.TryParse(dataGridView1.Rows[i].Cells[11].Value.ToString(),out r8);
                row.show_product = r8;

                db.SaveChanges();
            }
            MessageBox.Show("تم حفظ التعديلات الجديدة");
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}
