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

namespace POSDemo.Screens.Products
{
    public partial class ProductList : Form
    {
        POSTutEntities db = new POSTutEntities();
         
        string imgpath="";
        int id;
        Product Result;
        public ProductList()
        {
            InitializeComponent();

           dataGridView1.DataSource= db.Product.ToList(); 
            // for show all the products after component
            // show it in the dataGridView



        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet5.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter1.Fill(this.pOSTutDataSet5.Product);
            // TODO: This line of code loads data into the 'pOSTutDataSet.Product' table. You can move, or remove it, as needed.
            //this.productTableAdapter.Fill(this.pOSTutDataSet.Product);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtProdName.Text=="")
           dataGridView1.DataSource= db.Product.Where(p => p.Code == txtCode.Text ).ToList();
            else
                dataGridView1.DataSource = db.Product.Where(p => p.Code == txtCode.Text || p.Name.Contains(txtProdName.Text)).ToList();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Product.ToList();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
          
              Result = db.Product.SingleOrDefault(n => n.id == id);
             
              Result.Name = txtProdFormName.Text;
             Result.Code = txtFormCode.Text;
             Result.Price = decimal.Parse( txtPrice.Text);
             Result.Quantity = int.Parse(txtQuantity.Text);
             Result.Notes = txtNotes.Text;
             //Result.Image = pictureProduct.ImageLocation;

              db.SaveChanges();// this is important for save updating 

              if (imgpath != "")
              {
                  string newpath = Environment.CurrentDirectory + "\\ImagesAdded\\products\\" + Result.id + ".jpg";

                  try
                  {
                      File.Copy(imgpath, newpath,true);
                  }
                  catch (Exception ex)
                  {
                      ex.GetBaseException();
                  }

                  Result.Image = imgpath;
                  db.SaveChanges();
              }
              
            MessageBox.Show("تم تعديل البيانات بنجاح  ");
            dataGridView1.DataSource = db.Product.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
             id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            var Result = db.Product.SingleOrDefault(n=>n.id==id);

            txtProdFormName.Text = Result.Name;
            txtFormCode.Text = Result.Code;
            txtPrice.Text = Result.Price.ToString();
            txtQuantity.Text = Result.Quantity.ToString();
            txtNotes.Text = Result.Notes;
            pictureProduct.ImageLocation = Result.Image;
        }

        private void TRUE(object sender, EventArgs e)
        {

        }

        private void pictureProduct_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          var res=  MessageBox.Show(" هل تريد الحذف","تأكيد الحذف",MessageBoxButtons.YesNo);
          if (res == DialogResult.Yes)
          {
              try
              {
                  var delete = db.Product.Find(id);
                  db.Product.Remove(delete);
                  db.SaveChanges();
                  dataGridView1.DataSource = db.Product.ToList();
                  MessageBox.Show("تم الحذف بنجاح");
              }catch(UpdateException ex){
                  MessageBox.Show(ex.Message);
              }
                
              

          }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgpath = ofd.FileName;
                pictureProduct.ImageLocation = ofd.FileName;

            }
            // pictureProduct.ImageLocation=
        }
    }
}
