using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace POSDemo
{
    public partial class Form1 : Form
    {
        POSTutEntities db = new POSTutEntities();
        void login_func() {
            if (txtUser.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {

                 //var res = db.Users.Where(x => x.UserName == txtUser.Text && x.Password == txtPassword.Text);
                //DataTable res = new DataTable();

              var  res = db.Users.FirstOrDefault(x => x.UserName == txtUser.Text && x.Password == txtPassword.Text) ;
                    
                if (res != null)
                   
                {
                   // MessageBox.Show(res.control_users.ToString());
                    MainForm.MainFRM_getter.المستخدمينtoolstripmenu.Visible = Convert.ToBoolean(res.control_users);
                    MainForm.MainFRM_getter.الفاتورةToolStripMenuItem.Visible = Convert.ToBoolean(res.add_invoice);
                    MainForm.MainFRM_getter.تقاريرToolStripMenuItem.Visible = Convert.ToBoolean(res.add_report);
                    MainForm.MainFRM_getter.المنتجاتToolStripMenuItem.Visible = Convert.ToBoolean(res.add_product);
                    MainForm.MainFRM_getter.العملاءToolStripMenuItem.Visible = Convert.ToBoolean(res.add_customer);
                    MainForm.MainFRM_getter.الموردينToolStripMenuItem .Visible = Convert.ToBoolean(res.add_supplier);
                     
                    this.Close(); // to close this form and open another form
                   
                   // Thread th = new Thread(openForm);
                   // th.SetApartmentState(ApartmentState.STA);
                   //th.Start();

                   TheUsers.Name = res.UserName;
                   TheUsers.id = res.id;
                }
                else
                {
                    MessageBox.Show("the user name or password is wrong!!!");
                }
            }
            else {
                if (txtUser.Text.Trim() == "")
                    errorProvider1.SetError(txtUser,"enter username !!");
                if (txtPassword.Text.Trim() == "")
                    errorProvider2.SetError(txtUser, "enter password !!");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login_func();
        }

        void openForm() {// i create this function
            Application.Run(new MainForm());
        }

       

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Down)
                txtPassword.Focus();
            if (e.KeyData == Keys.Enter)
                 login_func();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
             if(e.KeyData==Keys.Up)
                txtUser.Focus();
             if (e.KeyData == Keys.Enter)
                 login_func();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() != "" && txtPassword.Text.Trim() != "")
                btnLogin.Enabled = true;

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() != "" && txtPassword.Text.Trim() != "")
                btnLogin.Enabled = true;

        }
    }
    static class TheUsers
    {
        static public string Name { get; set; }
        static public int id { get; set; }
    }
}
