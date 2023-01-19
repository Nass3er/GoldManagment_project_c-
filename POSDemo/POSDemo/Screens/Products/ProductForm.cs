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
using System.Data.SqlClient;


namespace POSDemo.Screens.Products
{
    public partial class ProductForm : Form
    {
        POSTutEntities db = new POSTutEntities();
        
        string imgPath="";  // not null
        public ProductForm()
        {
            InitializeComponent();

            //comboBox1.se
             //comboBox1.DataSource = db.Categories.ToList();
           // comboBox1.ValueMember = "id";
            //comboBox1.DisplayMember = "Name";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtProdutctName.Text == "" )
            {
                MessageBox.Show(" the first two textBox most be not empty!");
            }

            else{
                Product prod = new Product();
                prod.Code = txtCode.Text;
                prod.Name = txtProdutctName.Text;
                prod.Notes = txtNotes.Text;
                
                decimal weight;
                decimal.TryParse(txtWeight.Text, out weight);
                 prod.weight = weight;
              //  prod.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
               // prod.Price = Convert.ToDecimal(txtPrice.Text);
               // prod.Quantity = int.Parse(txtQuantity.Text);

                // this is the best way if the user input character in the textBox
                int qty;
                    /// int.TryParse(txtPrice.Text,out price);
                     int.TryParse(txtQuantity.Text,out qty);
                //prod.Price=price;
                prod.Quantity=qty;
                prod.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
                 
                //var param = new SqlParameter("@catId", prod.CategoryId);
                //var context = new POSDemo.DB.POSTutEntities();
                //var result2 = context.Database.SqlQuery<Categories>(@"getpriceGrame @catId", param).ToList();
                //var result2 = db.Categories.SqlQuery(@"getpriceGrame @catId", param).ToList();
             
               // MessageBox.Show(result2.ToString());

               
                var result = db.Categories.SingleOrDefault(n => n.id == prod.CategoryId);
                prod.Price = result.priceGram * prod.weight;
                 
                db.Product.Add(prod);
                db.SaveChanges();
                MessageBox.Show("تم الحفظ بنجاح"  );

                if (imgPath != "")
                {
                    string newpath = Environment.CurrentDirectory + "\\ImagesAdded\\products\\" + prod.id + ".jpg";
                    try
                    {
                        File.Copy(imgPath, newpath);
                    }
                    catch(Exception ex){
                        ex.GetBaseException();
                    }
                    prod.Image = imgPath;
                    db.SaveChanges();
                }

                // TO DO SAVE THIS DETAILSE OF PRODUCT AND SUPPLIER TO THE TABLE "product_supplier"
                prod_suppl prsup = new prod_suppl();
                prsup.productId = prod.id;
                prsup.supplierId = int.Parse(comboBox2.SelectedValue.ToString());
                db.prod_suppl.Add(prsup);
                db.SaveChanges();

                txtCode.Text = "";
                txtNotes.Text = "";
                txtPrice.Text = "";
                txtProdutctName.Text = "";
                txtQuantity.Text = "";
                txtWeight.Text = "";
                pictureProduct.ImageLocation = "";

            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureProduct_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductList frm = new ProductList();
            frm.Show();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOSTutDataSet10.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.pOSTutDataSet10.Supplier);
            // TODO: This line of code loads data into the 'pOSTutDataSet4.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.pOSTutDataSet4.Categories);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgPath = ofd.FileName;
                pictureProduct.ImageLocation = ofd.FileName;


            }
        }
    }
}
