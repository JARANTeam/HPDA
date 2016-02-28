namespace HPDA
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnProMain = new System.Windows.Forms.Button();
            this.pbProDelivery = new System.Windows.Forms.PictureBox();
            this.btnRaw = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRmMain = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(259, 233);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 25);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnProMain
            // 
            this.btnProMain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnProMain.Location = new System.Drawing.Point(198, 184);
            this.btnProMain.Name = "btnProMain";
            this.btnProMain.Size = new System.Drawing.Size(99, 25);
            this.btnProMain.TabIndex = 19;
            this.btnProMain.Text = "生产";
            this.btnProMain.Click += new System.EventHandler(this.btnProMain_Click);
            // 
            // pbProDelivery
            // 
            this.pbProDelivery.BackColor = System.Drawing.Color.Transparent;
            this.pbProDelivery.Image = ((System.Drawing.Image)(resources.GetObject("pbProDelivery.Image")));
            this.pbProDelivery.Location = new System.Drawing.Point(223, 134);
            this.pbProDelivery.Name = "pbProDelivery";
            this.pbProDelivery.Size = new System.Drawing.Size(49, 49);
            this.pbProDelivery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // btnRaw
            // 
            this.btnRaw.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnRaw.Location = new System.Drawing.Point(37, 79);
            this.btnRaw.Name = "btnRaw";
            this.btnRaw.Size = new System.Drawing.Size(104, 25);
            this.btnRaw.TabIndex = 27;
            this.btnRaw.Text = "原料扫描";
            this.btnRaw.Click += new System.EventHandler(this.btnRaw_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(65, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnRmMain
            // 
            this.btnRmMain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnRmMain.Location = new System.Drawing.Point(37, 184);
            this.btnRmMain.Name = "btnRmMain";
            this.btnRmMain.Size = new System.Drawing.Size(104, 25);
            this.btnRmMain.TabIndex = 27;
            this.btnRmMain.Text = "原料";
            this.btnRmMain.Click += new System.EventHandler(this.btnRmMain_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnProduct.Location = new System.Drawing.Point(198, 79);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(99, 25);
            this.btnProduct.TabIndex = 27;
            this.btnProduct.Text = "成品扫描";
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(65, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(223, 29);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(49, 49);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.btnRmMain);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnRaw);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProMain);
            this.Controls.Add(this.pbProDelivery);
            this.Name = "frmMain";
            this.Text = "主界面-华翔";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnProMain;
        private System.Windows.Forms.PictureBox pbProDelivery;
        private System.Windows.Forms.Button btnRaw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRmMain;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}