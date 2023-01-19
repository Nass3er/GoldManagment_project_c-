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

namespace POSDemo.Screens.SallsBill
{
    public partial class SallsBillForm : Form
    {
        POSTutEntities  db= new POSTutEntities();
        
        decimal tot = 0;
        List<POSDemo.DB.Product> products;
        POSDemo.DB.salesBill result;
        int idnewE;
        public SallsBillForm()
        {
            InitializeComponent();
            
           // imageList1.Images.Add( );
            lblUserName.Text = POSDemo.TheUsers.Name;
            comboBox1.DataSource= db.Customer.Where(x=>x.isActive==true).ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "Name";

            products = db.Product.ToList();   // TO DO GET ALL ELEMENTS FROM TABLE "Products"
            imageList1.ImageSize = new Size(80, 80);

            //DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            //button.HeaderText = "action";
            //button.Text = "تراجع";
            //button.UseColumnTextForButtonValue = true;
            //dataGridView1.Columns.Add(button);
        }
        void showProduct2() {
            for (int i = 0; i < products.Count(); i++)
            {
                if (products[i].Image != null)
                {

                    imageList1.Images.Add(Image.FromFile(products[i].Image));
                }
                else
                {
                    Bitmap btm = new Bitmap(80, 80);  //لعمل مربع فاضي مكان الصورة اذا كانت مش موجودة
                    imageList1.Images.Add(btm);
                }
                //listView1.View = View.Details;
                //listView1.Columns.Add("key");
                //listView1.Columns.Add("value");

                //ListViewItem lvi = new ListViewItem();
                //lvi.Text = "key";
                //lvi.SubItems.Add("value");
                //listView1.Items.Add(lvi);


                ListViewItem item = new ListViewItem();
                item.Text = products[i].Name;
                item.ImageIndex = i;
                item.SubItems.Add("1");
                item.UseItemStyleForSubItems = true;
                item.Tag = products[i];


                listView1.Items.Add(item);

            }
        }

        void showProduct() {   // this function for search  and show all product in listview 

            if (txtSearch.Text != "")
            {
                listView1.Clear();
                products = db.Product.Where(s => s.Name.Contains(txtSearch.Text)).ToList();
                showProduct2();

            }
            else {
                listView1.Clear();
                products = db.Product.ToList();
                showProduct2();
            }
            
        }

        private void SallsBillForm_Load(object sender, EventArgs e)
        {
            showProduct();
        }

        // function for calculate total
        void clculateTotal() {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
            // for remove row from datagridview 
            if(e.RowIndex==dataGridView1.NewRowIndex || e.RowIndex<0){
                return;}
                if (e.ColumnIndex == dataGridView1.Columns["ColumnBtn"].Index) {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
           //for get data by the click on the row are selected
                //var data = (Product)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            //data.id=.....;
            //data.Name=....; // this lines good running 
            //data.Price=....;
            //data.Quantity=...;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
                 result = new POSDemo.DB.salesBill();
               
                   result.date = (DateTime)dateTimePicker1.Value.Date;
                   if (txtDiscount.Text != "")
                   {
                       result.discount = decimal.Parse(txtDiscount.Text);
                       result.totalAfterDiscount = decimal.Parse(lbltotalAfterDesc2.Text);
                   }
                   else {
                       result.discount = 0;
                       result.totalAfterDiscount = decimal.Parse(lbltotal2.Text);
                   }
                  
                   result.total = decimal.Parse(lbltotal2.Text);
                   
                   result.notes = txtNotes.Text;
                   result.customerId = int.Parse(comboBox1.SelectedValue.ToString());
                  // result.userId = POSDemo.TheUsers.id;

                   db.salesBill.Add(result);
                   db.SaveChanges();
                    idnewE = result.id;
                     
                   salesBillDetails sbd=new salesBillDetails();
                 
                   for (int i = 0; i < dataGridView1.RowCount-1; i++)
                   {
                       decimal pr2=0;
                       sbd.productId = int.Parse(dataGridView1.Rows[i].Cells["id"].Value.ToString());
                       sbd.quantity = int.Parse(dataGridView1.Rows[i].Cells["quantity"].Value.ToString());
                       
                           decimal.TryParse(dataGridView1.Rows[i].Cells["price"].Value.ToString(), out pr2);
                           sbd.price = pr2;
                           sbd.totalPrice = pr2 * int.Parse(dataGridView1.Rows[i].Cells["quantity"].Value.ToString());
                       sbd.salesBillId = idnewE;

                       db.salesBillDetails.Add(sbd);
                       db.SaveChanges();
                       
                   }
                   MessageBox.Show("تم الحفظ.");

                   dataGridView1.Rows.Clear();
                   dataGridView1.Refresh();
            //List<salesBillDetails> list = new List<salesBillDetails>();

            // for (int i = 0; i < dataGridView1.RowCount;i++ ) {
                  
            //    list.Add(new salesBillDetails
            //    {
            //        productId=int.Parse(dataGridView1.Rows[i].Cells["id"].ToString()),
            //        quantity = int.Parse(dataGridView1.Rows[i].Cells["quantity"].ToString())
            //       , price=decimal.Parse(dataGridView1.Rows[i].Cells["price"].ToString()) 
            //       , totalPrice=int.Parse(dataGridView1.Rows[i].Cells["quantity"].ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["price"].ToString()) 
            //        ,salesBillId= idnewE
            //    });
            //}
             //list.ForEach(n => db.salesBillDetails.Add(n));
             //db.SaveChanges();


            //{
            //result.salesBillDetails = list;
            //db.salesBill.Add(result);
            //db.SaveChanges();
            //}
            //catch { }
           

            //db.salesBillDetails.Add(list);
            //db.SaveChanges();
             
        }

         

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //clculateTotal();
            decimal disc = decimal.Parse(txtDiscount.Text);
            lbltotalAfterDesc2.Text = (tot - disc).ToString();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
            //    e.Handled = true;
            //}
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') != null))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            showProduct();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                
                var prod = (POSDemo.DB.Product)listView1.SelectedItems[0].Tag;

                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == prod.id.ToString())
                    {                         //quantity
                       dataGridView1.Rows[i].Cells[3].Value =Convert.ToString(1+int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString())) ;
                       dataGridView1.Rows[i].Cells[5].Value = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * prod.Price;
                      
                        return;               //total total
                    }
                }


                                                                        //price     //totalprice
                dataGridView1.Rows.Add(prod.id, prod.Name, prod.weight,1,prod.Price,prod.Price );
                //clculateTotal();
                decimal pr;
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    try
                    {
                        if (!dataGridView1.Rows[j].Cells[5].Value.Equals(System.DBNull.Value))
                        {
                            decimal.TryParse(dataGridView1.Rows[j].Cells[5].Value.ToString(), out pr);
                            tot += pr;
                        }
                    }
                    catch { 
                    
                    }
                }
                lbltotal2.Text = tot.ToString();


            }
          

        }

        private void SallsBillForm_Click(object sender, EventArgs e)
        {
          
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            result = new POSDemo.DB.salesBill();

            result.date = (DateTime)dateTimePicker1.Value.Date;
           
            result.total = decimal.Parse(lbltotal2.Text);
            if (txtDiscount.Text != "")
            {
                result.discount = decimal.Parse(txtDiscount.Text);
                result.totalAfterDiscount = decimal.Parse(lbltotalAfterDesc2.Text);
            }
            else {
            result.totalAfterDiscount  =decimal.Parse(lbltotal2.Text);
            result.discount = decimal.Parse(lbltotal2.Text);
            }

           
            result.notes = txtNotes.Text;
            result.customerId = int.Parse(comboBox1.SelectedValue.ToString());
            // result.userId = POSDemo.TheUsers.id;

            db.salesBill.Add(result);
            db.SaveChanges();
            idnewE = result.id;

            salesBillDetails sbd = new salesBillDetails();

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                decimal pr2 = 0;
                sbd.productId = int.Parse(dataGridView1.Rows[i].Cells["id"].Value.ToString());
                sbd.quantity = int.Parse(dataGridView1.Rows[i].Cells["quantity"].Value.ToString());

                decimal.TryParse(dataGridView1.Rows[i].Cells["price"].Value.ToString(), out pr2);
                sbd.price = pr2;
                sbd.totalPrice = pr2 * int.Parse(dataGridView1.Rows[i].Cells["quantity"].Value.ToString());
                sbd.salesBillId = idnewE;

                db.salesBillDetails.Add(sbd);
                db.SaveChanges();

            }
           // MessageBox.Show("تم الحفظ.");

           




            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized; 
            // for show full the screen

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float margin=40;
            Font f = new Font("Areal",18,FontStyle.Bold);
            string strDate = "التاريخ :" + (DateTime)dateTimePicker1.Value.Date;
           string strN="ناصر محمد عبدالله";
           string userName = lblUserName.Text;


            SizeF fontsizeNo = e.Graphics.MeasureString( idnewE.ToString(),f);
            SizeF fontsizeDate = e.Graphics.MeasureString( strDate, f);
            SizeF fontsizeName = e.Graphics.MeasureString( strN, f);
            SizeF fontsizeUserName = e.Graphics.MeasureString(userName, f);
            
            e.Graphics.DrawImage(Properties.Resources.FB_IMG_1654446468409,5,5,200,200);
            e.Graphics.DrawString("#NO" +idnewE.ToString(),f,Brushes.Red,(e.PageBounds.Width - fontsizeDate.Width)/2 , margin);
            e.Graphics.DrawString(strDate, f, Brushes.Black, e.PageBounds.Width - fontsizeDate.Width - margin, margin + fontsizeNo.Height);
            e.Graphics.DrawString("مطلوب من السيد :" + strN, f, Brushes.Navy, e.PageBounds.Width - fontsizeName.Width - margin, margin + fontsizeDate.Height + fontsizeNo.Height);
                                  //combobox
            e.Graphics.DrawString("طبع بواسطة:"+userName, f, Brushes.Purple, e.PageBounds.Width - fontsizeName.Width - margin, margin + fontsizeDate.Height + fontsizeNo.Height+fontsizeUserName.Height);
            // draw rectangle 
             float preHight = margin + fontsizeNo.Height + fontsizeName.Height + fontsizeName.Height+fontsizeUserName.Height +50;
             e.Graphics.DrawRectangle(Pens.Black, margin, preHight, e.PageBounds.Width-margin*2,e.PageBounds.Height-margin-preHight);
                                                //left    top        //  width                          //heght
             float colHeigth = 60;

             float col1Width = 180;
             float col2Width = 120 + col1Width;
             float col3Width = 120 + col2Width;
             float col4Width = 120 + col3Width;

             e.Graphics.DrawLine(Pens.Black, margin, preHight + colHeigth, e.PageBounds.Width - margin, preHight + colHeigth);

             e.Graphics.DrawString("الإسم ", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col1Width, preHight);
             e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col1Width, preHight, e.PageBounds.Width - margin * 2 - col1Width, e.PageBounds.Height - margin);

             e.Graphics.DrawString("الوزن ", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col2Width, preHight);
             e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col2Width, preHight, e.PageBounds.Width - margin * 2 - col2Width, e.PageBounds.Height - margin);

             e.Graphics.DrawString("الكمية ", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col3Width, preHight);
             e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col3Width, preHight, e.PageBounds.Width - margin * 2 - col3Width, e.PageBounds.Height - margin);

             e.Graphics.DrawString("إجمالي", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col4Width, preHight);
              
             
            ////////// INVOICE CONTENT ///////

             float rowsHeight = 60;
             for (int x = 0; x < dataGridView1.RowCount; x += 1)
             {
                 e.Graphics.DrawString(dataGridView1.Rows[x].Cells[1].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col1Width, preHight + rowsHeight);
                // e.Graphics.DrawString(dataGridView1.Rows[x].Cells[2].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col2Width, preHight + rowsHeight);
                 e.Graphics.DrawString(dataGridView1.Rows[x].Cells[3].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col3Width, preHight + rowsHeight);
                 e.Graphics.DrawString(dataGridView1.Rows[x].Cells[5].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col4Width, preHight + rowsHeight);

                 e.Graphics.DrawLine(Pens.Black,margin,preHight+rowsHeight+colHeigth,e.PageBounds.Width-margin,preHight+rowsHeight + colHeigth);
                 rowsHeight += 60;

             }
             e.Graphics.DrawString( "المجموع ", f, Brushes.Red, e.PageBounds.Width - margin * 2 - col3Width, preHight + rowsHeight);
             if (lbltotalAfterDesc2.Text == "")
             {
                 e.Graphics.DrawString(lbltotal2.Text, f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col4Width, preHight + rowsHeight);
             }
             else {
                 e.Graphics.DrawString( lbltotalAfterDesc2.Text, f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col4Width, preHight + rowsHeight);
           
             }
             e.Graphics.DrawLine(Pens.Black, margin, preHight + rowsHeight + colHeigth, e.PageBounds.Width - margin, preHight + rowsHeight + colHeigth);

             dataGridView1.Rows.Clear();
             dataGridView1.Refresh();
        }

        private void lblTotalAfterDisc_Click(object sender, EventArgs e)
        {

        }
       
    }
}


 
