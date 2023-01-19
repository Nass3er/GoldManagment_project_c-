namespace POSDemo.Screens.Products
{
    partial class product_report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pOSTutDataSet8 = new POSDemo.POSTutDataSet8();
            this.productTableAdapter = new POSDemo.POSTutDataSet8TableAdapters.ProductTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSTutDataSet8)).BeginInit();
            this.SuspendLayout();
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.pOSTutDataSet8;
            // 
            // pOSTutDataSet8
            // 
            this.pOSTutDataSet8.DataSetName = "POSTutDataSet8";
            this.pOSTutDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.AutoScroll = true;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.productBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POSDemo.Images.Screens.Products.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(880, 466);
            this.reportViewer1.TabIndex = 0;
            // 
            // product_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 468);
            this.Controls.Add(this.reportViewer1);
            this.Name = "product_report";
            this.Text = "product_report";
            this.Load += new System.EventHandler(this.product_report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSTutDataSet8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public POSTutDataSet8 pOSTutDataSet8;
        public POSTutDataSet8TableAdapters.ProductTableAdapter productTableAdapter;
        public System.Windows.Forms.BindingSource productBindingSource;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}