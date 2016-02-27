namespace HPDA
{
    partial class FrmMainPro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainPro));
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadDelivery = new System.Windows.Forms.Button();
            this.btnDeliverySelect = new System.Windows.Forms.Button();
            this.btnTransferSelect = new System.Windows.Forms.Button();
            this.btnTransferDownload = new System.Windows.Forms.Button();
            this.btnCheckSelect = new System.Windows.Forms.Button();
            this.btnCheckDownLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(266, 217);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(49, 49);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Desktop;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(29, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 30);
            this.button1.TabIndex = 56;
            this.button1.Text = "完工入库";
            // 
            // btnLoadDelivery
            // 
            this.btnLoadDelivery.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnLoadDelivery.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoadDelivery.ForeColor = System.Drawing.Color.White;
            this.btnLoadDelivery.Location = new System.Drawing.Point(29, 77);
            this.btnLoadDelivery.Name = "btnLoadDelivery";
            this.btnLoadDelivery.Size = new System.Drawing.Size(104, 26);
            this.btnLoadDelivery.TabIndex = 57;
            this.btnLoadDelivery.Text = "下载出库指令";
            this.btnLoadDelivery.Click += new System.EventHandler(this.btnLoadDelivery_Click);
            // 
            // btnDeliverySelect
            // 
            this.btnDeliverySelect.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnDeliverySelect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeliverySelect.ForeColor = System.Drawing.Color.White;
            this.btnDeliverySelect.Location = new System.Drawing.Point(157, 77);
            this.btnDeliverySelect.Name = "btnDeliverySelect";
            this.btnDeliverySelect.Size = new System.Drawing.Size(104, 26);
            this.btnDeliverySelect.TabIndex = 58;
            this.btnDeliverySelect.Text = "执行出库";
            this.btnDeliverySelect.Click += new System.EventHandler(this.btnDeliverySelect_Click);
            // 
            // btnTransferSelect
            // 
            this.btnTransferSelect.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnTransferSelect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnTransferSelect.ForeColor = System.Drawing.Color.White;
            this.btnTransferSelect.Location = new System.Drawing.Point(157, 121);
            this.btnTransferSelect.Name = "btnTransferSelect";
            this.btnTransferSelect.Size = new System.Drawing.Size(104, 26);
            this.btnTransferSelect.TabIndex = 60;
            this.btnTransferSelect.Text = "执行调拨";
            this.btnTransferSelect.Click += new System.EventHandler(this.btnTransferSelect_Click);
            // 
            // btnTransferDownload
            // 
            this.btnTransferDownload.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnTransferDownload.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnTransferDownload.ForeColor = System.Drawing.Color.White;
            this.btnTransferDownload.Location = new System.Drawing.Point(29, 121);
            this.btnTransferDownload.Name = "btnTransferDownload";
            this.btnTransferDownload.Size = new System.Drawing.Size(104, 26);
            this.btnTransferDownload.TabIndex = 59;
            this.btnTransferDownload.Text = "下载调拨单";
            this.btnTransferDownload.Click += new System.EventHandler(this.btnTransferDownload_Click);
            // 
            // btnCheckSelect
            // 
            this.btnCheckSelect.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnCheckSelect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckSelect.ForeColor = System.Drawing.Color.White;
            this.btnCheckSelect.Location = new System.Drawing.Point(157, 166);
            this.btnCheckSelect.Name = "btnCheckSelect";
            this.btnCheckSelect.Size = new System.Drawing.Size(104, 26);
            this.btnCheckSelect.TabIndex = 62;
            this.btnCheckSelect.Text = "执行盘点";
            this.btnCheckSelect.Click += new System.EventHandler(this.btnCheckSelect_Click);
            // 
            // btnCheckDownLoad
            // 
            this.btnCheckDownLoad.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnCheckDownLoad.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckDownLoad.ForeColor = System.Drawing.Color.White;
            this.btnCheckDownLoad.Location = new System.Drawing.Point(29, 166);
            this.btnCheckDownLoad.Name = "btnCheckDownLoad";
            this.btnCheckDownLoad.Size = new System.Drawing.Size(104, 26);
            this.btnCheckDownLoad.TabIndex = 61;
            this.btnCheckDownLoad.Text = "下载盘点单";
            this.btnCheckDownLoad.Click += new System.EventHandler(this.btnCheckDownLoad_Click);
            // 
            // FrmMainPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.btnCheckSelect);
            this.Controls.Add(this.btnCheckDownLoad);
            this.Controls.Add(this.btnTransferSelect);
            this.Controls.Add(this.btnTransferDownload);
            this.Controls.Add(this.btnDeliverySelect);
            this.Controls.Add(this.btnLoadDelivery);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbExit);
            this.Name = "FrmMainPro";
            this.Text = "产成品管理模块";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLoadDelivery;
        private System.Windows.Forms.Button btnDeliverySelect;
        private System.Windows.Forms.Button btnTransferSelect;
        private System.Windows.Forms.Button btnTransferDownload;
        private System.Windows.Forms.Button btnCheckSelect;
        private System.Windows.Forms.Button btnCheckDownLoad;
    }
}