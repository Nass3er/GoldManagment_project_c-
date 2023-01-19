using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo.Screens.Customer
{
    public partial class CustomerManagment : Form
    {
        POSTutEntities db = new POSTutEntities();
        string imgpath = "";

        int id;
        POSDemo.DB.Customer  row; // we define object from class Customer 

        public CustomerManagment()
        {
            InitializeComponent();
            
            dataGridView1.DataSource = db.Customer.ToList(); // show all data of customer in dataGridview
            checkBox1.Checked = false; // becoase it is allow null in database 
        }

        private void CustomerManagment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet2.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.pOSTutDataSet2.Customer);

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customer.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "")
                dataGridView1.DataSource = db.Customer.Where(c => c.Phone == txtSearchPhone.Text).ToList();
            else
                dataGridView1.DataSource = db.Customer.Where(c => c.Phone == txtSearchName.Text || c.Name.Contains(txtSearchPhone.Text)).ToList();
           
        }

        // to update the data of customer
        private void button4_Click(object sender, EventArgs e)
        {
             var res = MessageBox.Show("تعديل بانات عميل ","هل تريد حفظ التعديل",MessageBoxButtons.YesNo);

             if (res == DialogResult.Yes)
             {
                 row = db.Customer.SingleOrDefault(c => c.id == id);

                 row.Name = txtCusFormName.Text;
                 row.address = txtAddress.Text;
                 row.Phone = txtPhone.Text;
                 row.Company = txtCompany.Text;
                 row.email = txtEmail.Text;
                 row.Notes = txtNotes.Text;
                 row.isActive = checkBox1.Checked;

                 if (imgpath != "")
                 {
                     string newpath = Environment.CurrentDirectory + "\\ImagesAdded\\products\\" + row.id + ".jpg";
                     try
                     {
                         File.Copy(imgpath, newpath, true);
                     }
                     catch (Exception ex)
                     {
                         ex.GetBaseException();
                     }

                     row.Image = pictureCustomer.ImageLocation;
                 }
                 db.SaveChanges();
                 dataGridView1.DataSource = db.Customer.ToList();
                 MessageBox.Show("تم تعديل بيانات العميل ");
             }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("إضافة عميل جديد","هل انت متأكد من إضافة هذا العميل كعميل جديد",MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                if (txtCusFormName.Text == "" || txtPhone.Text == "")
                {
                    MessageBox.Show("الرجاء إكمال البيانات المطلوبة اولا أولا");
                }
                else
                {
                    POSDemo.DB.Customer cust = new POSDemo.DB.Customer();
                    cust.Name = txtCusFormName.Text;
                    cust.address = txtAddress.Text;
                    cust.Phone = txtPhone.Text;
                    cust.Company = txtCompany.Text;
                    cust.email = txtEmail.Text;
                    cust.isActive = checkBox1.Checked;
                    cust.Notes = txtNotes.Text;
                    cust.Image = imgpath;

                    db.Customer.Add(cust);
                    db.SaveChanges();

                    if (imgpath != "")
                    {
                        string newpath = Environment.CurrentDirectory + "\\ImagesAdded\\Customers\\" + cust.id + ".jpg";
                        try
                        {
                            File.Copy(imgpath, newpath);
                        }
                        catch (Exception ex)
                        {
                            ex.GetBaseException();
                        }
                        cust.Image = imgpath;
                        db.SaveChanges();
                    }
                    dataGridView1.DataSource = db.Customer.ToList();
                    MessageBox.Show("تم الحفظ بنجاح");
                }
            }
        }

        private void pictureCustomer_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureCustomer.ImageLocation = ofd.FileName;
                imgpath = ofd.FileName;

            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                  id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                  row = db.Customer.SingleOrDefault(c => c.id == id);


                txtCusFormName.Text = row.Name;
                txtAddress.Text = row.address;
                txtPhone.Text = row.Phone;
                txtCompany.Text = row.Company;
                txtEmail.Text = row.email;
                txtNotes.Text = row.Notes;
                checkBox1.Checked = (bool)row.isActive;
                pictureCustomer.ImageLocation = row.Image;
            }
            catch{
            
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            var res = MessageBox.Show("حذف عميل ","هل انت متأكد من الحذف",MessageBoxButtons.YesNo);
            
            if( res==DialogResult.Yes){
              var delete = db.Customer.Find(id);
              db.Customer.Remove(delete);

              db.SaveChanges();

              dataGridView1.DataSource = db.Customer.ToList();

              MessageBox.Show("تم حذفالعميل ");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureCustomer.ImageLocation = ofd.FileName;
                imgpath = ofd.FileName;

            }

        }
    }
}
