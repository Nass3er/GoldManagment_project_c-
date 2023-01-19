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

namespace POSDemo.Screens.Users
{
    public partial class newUser : Form
    {
        POSTutEntities db = new POSTutEntities();
        
        string imgpath="";
        
        public newUser()

        {
            InitializeComponent();
            //MessageBox.Show(Environment.CurrentDirectory);// for explain only
            //var x = db.Product.Where(z => z.Name == "ff");
         
        }
        POSDemo.DB.Users ob = new POSDemo.DB.Users();
         
        private void button1_Click(object sender, EventArgs e)
        {

            POSDemo.DB.Users obj = new POSDemo.DB.Users
            {
             UserName = txtUser.Text,
             Password = txtPassword.Text,
             Image=imgpath
            };
            
             
            db.Users.Add(obj);
            db.SaveChanges();// this is important method for save
           

            if (imgpath != "")
            {
                string newpath = Environment.CurrentDirectory + "\\ImagesAdded\\Users\\" + obj.id + ".jpg";

                File.Copy(imgpath, newpath);

                obj.Image = imgpath;
                db.SaveChanges();
            }

            MessageBox.Show( " تم الحفظ بنجاح");

        }

         
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK){
                imgpath = ofd.FileName;
                pictureBox1.ImageLocation = ofd.FileName;
                
  
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgpath = ofd.FileName;
                pictureBox1.ImageLocation = ofd.FileName;


            }
        }
    }
}
