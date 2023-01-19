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

namespace POSDemo.Screens.Products
{
    public partial class ProductPrices : Form
    {
        POSTutEntities db = new POSTutEntities();

        public ProductPrices()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProductPrices_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void notificationOk() { 
        
        }
        private void button1_Click(object sender, EventArgs e)
        {// to save the updated prices
            decimal p24,p23,p21,p18 ;
            
           
            if (decimal.TryParse(textBox24.Text, out p24 ) && decimal.TryParse(textBox23.Text, out p23)
                && decimal.TryParse(textBox21.Text,out p21) && decimal.TryParse(textBox18.Text,out p18))
            {
                var changePrices24 = db.Categories.SingleOrDefault(n1 => n1.Name == "24");
                changePrices24.priceGram = p24;
                db.SaveChanges();

                var changePrices23 = db.Categories.SingleOrDefault(n2 => n2.Name == "23");
                changePrices23.priceGram =p23;
                db.SaveChanges();

                var changePrices21 = db.Categories.SingleOrDefault(n3 => n3.Name == "21");
                changePrices21.priceGram =  p21;
                db.SaveChanges();

                var changePrices18 = db.Categories.SingleOrDefault(n4 => n4.Name == "18");
                changePrices18.priceGram =p18;
                db.SaveChanges();

                MessageBox.Show("تم تحديث الاسعار بنجاااح");
                textBox24.Text = "";
                textBox23.Text = "";
                textBox21.Text = "";
                textBox18.Text = "";

            }
            else {
                MessageBox.Show("الرجاء ادخال ارقام فقط");
            }
            
           
           
            

            //db.SaveChanges();

            
        }
    }
}
