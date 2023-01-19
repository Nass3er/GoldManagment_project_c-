using POSDemo.DB;
using POSDemo.Screens.All_Purchase;
using POSDemo.Screens.Customer;
using POSDemo.Screens.Products;
using POSDemo.Screens.SallsBill;
using POSDemo.Screens.Suppliers;
using POSDemo.Screens.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo
{
  
    public partial class MainForm : Form
    {
        POSTutEntities db = new POSTutEntities();

        public static MainForm  MainFRM;

        static void MainFRM_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainFRM = null;
        }

        public static MainForm MainFRM_getter
        {
            get
            {
                if (MainFRM == null)
                {
                    MainFRM = new MainForm();
                       MainFRM.FormClosed += FormClosedEventHandler(MainFRM_FormClosed);
                    // i think this for show form and close the old form
                    // نفس الفورم ولكن لها بعض الصلاحيات
                }

                return MainFRM;
            }
        }

        private static FormClosedEventHandler FormClosedEventHandler(Action<object, FormClosedEventArgs> MainFRM_FormClosed)
         {
             throw new NotImplementedException();
         }

        void acc() {
             this.المستخدمينtoolstripmenu.Visible = false;
             this.تقاريرToolStripMenuItem.Visible = false;
              this.الفاتورةToolStripMenuItem.Visible = false;
              this .المنتجاتToolStripMenuItem.Visible = false;
             this. العملاءToolStripMenuItem.Visible = false;
              this.الموردينToolStripMenuItem.Visible = false;
            

        }

        

         
        public MainForm()
        {
            InitializeComponent();
            if (MainFRM == null)
                MainFRM = this;

            acc();
            
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newUser frm = new newUser();
            frm.Show();


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // this.Close(); // to close all project
            acc();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.Show();
        }

        private void listProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList obj = new ProductList();
            obj.Show();
        }

        private void إضافةعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerManagment obj = new CustomerManagment();
            obj.Show();
        }

        private void إضافةموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierManagment obj = new SupplierManagment();
            obj.Show();
        }

        private void إضافةفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SallsBillForm obj = new SallsBillForm();
            obj.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void طباعةتقريربكلالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void طباعةتقريربكلالمنتجاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            POSDemo.Screens.Reports.allProducts frm = new POSDemo.Screens.Reports.allProducts();
            frm.ShowDialog();
        }

        private void تحديثالأسعارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductPrices propr = new ProductPrices();
            propr.ShowDialog();
        }

        private void المشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void المبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void إدارةالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersManagment usm = new UsersManagment();
            usm.ShowDialog();
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            this.menuStrip1.BackColor = Color.Red;
        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void fileToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            this.fileToolStripMenuItem.ForeColor = Color.Red;
        }

        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
           // this.menuStrip1.ForeColor = Color.Red;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
           // this.fileToolStripMenuItem.ForeColor = Color.Red;
        }
        private class renderer : ToolStripProfessionalRenderer {
            public renderer() : base(new cols()) { }
        }
        private class cols : ProfessionalColorTable {
            public override Color MenuItemSelected
            {
                get
                {
                    return Color.Blue;
                }    
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return  Color.Black;
                }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.White;
                }
            }
        }

        private void كلالمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            purchase purch = new purchase();
            purch.ShowDialog();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           // menuStrip1.BackColor = Color.Red;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            //menuStrip1.BackColor = Color.Maroon;

        }

        private void كلالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POSDemo.Screens.All_Sales.Salses sl = new POSDemo.Screens.All_Sales.Salses();
            sl.ShowDialog();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            menuStrip1.ForeColor = Color.Maroon;
        }
    }
   
}
