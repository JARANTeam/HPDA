namespace HPDA
{
    partial class ProductStore
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnComplete = new System.Windows.Forms.Button();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnShowDetail = new System.Windows.Forms.Button();
            this.mBc2 = new Symbol.Barcode2.Design.Barcode2();
            this.dGridMain = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblStockPlaceID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnComplete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(211, 239);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(102, 25);
            this.btnComplete.TabIndex = 19;
            this.btnComplete.Text = "完成入库扫描";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(3, 210);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(310, 23);
            this.txtBarCode.TabIndex = 18;
            // 
            // lblSum
            // 
            this.lblSum.Location = new System.Drawing.Point(81, 186);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(101, 20);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.Text = "已扫数量：";
            // 
            // btnShowDetail
            // 
            this.btnShowDetail.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnShowDetail.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowDetail.ForeColor = System.Drawing.Color.White;
            this.btnShowDetail.Location = new System.Drawing.Point(211, 181);
            this.btnShowDetail.Name = "btnShowDetail";
            this.btnShowDetail.Size = new System.Drawing.Size(102, 25);
            this.btnShowDetail.TabIndex = 17;
            this.btnShowDetail.Text = "显示扫描明细";
            // 
            // mBc2
            // 
            this.mBc2.OnScan += new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler(this.mBc2_OnScan);
            // 
            // dGridMain
            // 
            this.dGridMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dGridMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGridMain.Location = new System.Drawing.Point(0, 33);
            this.dGridMain.Name = "dGridMain";
            this.dGridMain.Size = new System.Drawing.Size(318, 136);
            this.dGridMain.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblOrderNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 33);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Location = new System.Drawing.Point(17, 7);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(153, 20);
            // 
            // lblStockPlaceID
            // 
            this.lblStockPlaceID.Location = new System.Drawing.Point(6, 240);
            this.lblStockPlaceID.Name = "lblStockPlaceID";
            this.lblStockPlaceID.Size = new System.Drawing.Size(198, 20);
            // 
            // ProductStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.lblStockPlaceID);
            this.Controls.Add(this.dGridMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnShowDetail);
            this.Name = "ProductStore";
            this.Text = "完工入库扫描";
            this.Load += new System.EventHandler(this.ProductStore_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ProductStore_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnShowDetail;
        private Symbol.Barcode2.Design.Barcode2 mBc2;
        private System.Windows.Forms.DataGrid dGridMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblStockPlaceID;
    }
}