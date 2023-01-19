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

namespace POSDemo.Screens.Suppliers
{
   
    public partial class SupplierManagment : Form
    {
        POSTutEntities db = new POSTutEntities();
        string imgpath = "";
        
        int id;
        POSDemo.DB.Supplier row; // we define object from class Supplier 

        public SupplierManagment()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.Supplier.ToList(); // show all data of customer in dataGridview
            checkBox1.Checked = false; // becoase it is allow null in database 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SupplierManagment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet3.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.pOSTutDataSet3.Supplier);

        }

        private void txtSearchName_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void txtSearchPhone_MouseLeave(object sender, EventArgs e)
        {
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("إضافة مورد جديد", "هل انت متأكد من إضافة هذا المورد كمورد جديد", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                if (txtSuppFormName.Text == "" || txtPhone.Text == "")
                {
                    MessageBox.Show("الرجاء إكمال البيانات المطلوبة أولا");
                }
                else
                {
                    POSDemo.DB.Supplier Supp = new POSDemo.DB.Supplier();
                    Supp.Name = txtSuppFormName.Text;
                    Supp.address = txtAddress.Text;
                    Supp.Phone = txtPhone.Text;
                    Supp.Company = txtCompany.Text;
                    Supp.email = txtEmail.Text;
                    Supp.isActive = checkBox1.Checked;
                    Supp.Notes = txtNotes.Text;
                    Supp.Image = imgpath;

                    db.Supplier.Add(Supp);
                    db.SaveChanges();

                    if (imgpath != "")
                    {
                        string newpath = Environment.CurrentDirectory + "\\ImagesAdded\\Suppliers\\" + Supp.id + ".jpg";
                        try
                        {
                            File.Copy(imgpath, newpath);
                        }
                        catch (Exception ex)
                        {
                            ex.GetBaseException();
                        }
                        Supp.Image = imgpath;
                        db.SaveChanges();
                    }
                    dataGridView1.DataSource = db.Supplier.ToList();
                    MessageBox.Show("تم الحفظ بنجاح");
                    txtSuppFormName.Text="";
                    txtAddress.Text="";
                    txtPhone.Text="";
                    txtCompany.Text="";
                    txtEmail.Text="";
                   txtNotes .Text="";
                   checkBox1.Checked=false;
                     pictureCustomer.ImageLocation="";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("تعديل بانات  مورد ", "هل تريد حفظ التعديل", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                row = db.Supplier.SingleOrDefault(s => s.id == id);

                row.Name = txtSuppFormName.Text;
                row.address = txtAddress.Text;
                row.Phone = txtPhone.Text;
                row.Company = txtCompany.Text;
                row.email = txtEmail.Text;
                row.Notes = txtNotes.Text;
                row.isActive = checkBox1.Checked;

                if (imgpath != "")
                {
                    string newpath = Environment.CurrentDirectory + "\\ImagesAdded\\Suppliers\\" + row.id + ".jpg";
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
                dataGridView1.DataSource = db.Supplier.ToList();
                MessageBox.Show("تم تعديل بيانات المورد ");
            }
        }

        private void pictureCustomer_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("حذف مورد ", "هل انت متأكد من الحذف", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                var delete = db.Supplier.Find(id);
                db.Supplier.Remove(delete);

                db.SaveChanges();

                dataGridView1.DataSource = db.Supplier.ToList();

                MessageBox.Show(" تم حذف المورد ");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                row = db.Supplier.SingleOrDefault(s => s.id == id);


                txtSuppFormName.Text = row.Name;
                txtAddress.Text = row.address;
                txtPhone.Text = row.Phone;
                txtCompany.Text = row.Company;
                txtEmail.Text = row.email;
                txtNotes.Text = row.Notes;
                checkBox1.Checked = (bool)row.isActive;
                pictureCustomer.ImageLocation = row.Image;
            }
            catch
            {

            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Supplier.Where(s => s.Name.Contains(txtSearchName.Text)).ToList();
          
        }

        private void txtSearchName_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
          
        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Supplier.Where(s => s.Phone.Contains(txtSearchPhone.Text)).ToList();
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
    