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
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.btnProDelivery = new System.Windows.Forms.Button();
            this.pbProDelivery = new System.Windows.Forms.PictureBox();
            this.btnSync = new System.Windows.Forms.Button();
            this.pbWorkSync = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(198, 216);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 25);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(198, 167);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(49, 49);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // btnProDelivery
            // 
            this.btnProDelivery.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnProDelivery.Location = new System.Drawing.Point(198, 79);
            this.btnProDelivery.Name = "btnProDelivery";
            this.btnProDelivery.Size = new System.Drawing.Size(49, 25);
            this.btnProDelivery.TabIndex = 19;
            this.btnProDelivery.Text = "生产";
            this.btnProDelivery.Click += new System.EventHandler(this.btnProDelivery_Click);
            // 
            // pbProDelivery
            // 
            this.pbProDelivery.BackColor = System.Drawing.Color.Transparent;
            this.pbProDelivery.Image = ((System.Drawing.Image)(resources.GetObject("pbProDelivery.Image")));
            this.pbProDelivery.Location = new System.Drawing.Point(198, 29);
            this.pbProDelivery.Name = "pbProDelivery";
            this.pbProDelivery.Size = new System.Drawing.Size(49, 49);
            this.pbProDelivery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbProDelivery.Click += new System.EventHandler(this.btnProDelivery_Click);
            // 
            // btnSync
            // 
            this.btnSync.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSync.Location = new System.Drawing.Point(37, 79);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(49, 25);
            this.btnSync.TabIndex = 27;
            this.btnSync.Text = "原料";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // pbWorkSync
            // 
            this.pbWorkSync.BackColor = System.Drawing.Color.Transparent;
            this.pbWorkSync.Image = ((System.Drawing.Image)(resources.GetObject("pbWorkSync.Image")));
            this.pbWorkSync.Location = new System.Drawing.Point(37, 29);
            this.pbWorkSync.Name = "pbWorkSync";
            this.pbWorkSync.Size = new System.Drawing.Size(49, 49);
            this.pbWorkSync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWorkSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.pbWorkSync);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.btnProDelivery);
            this.Controls.Add(this.pbProDelivery);
            this.Name = "frmMain";
            this.Text = "主界面-华翔";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Button btnProDelivery;
        private System.Windows.Forms.PictureBox pbProDelivery;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.PictureBox pbWorkSync;
    }
}