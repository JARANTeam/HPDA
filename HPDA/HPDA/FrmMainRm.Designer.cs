namespace HPDA
{
    partial class FrmMainRm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainRm));
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.btnProduceSelect = new System.Windows.Forms.Button();
            this.btnProduceDownload = new System.Windows.Forms.Button();
            this.btnPoSelect = new System.Windows.Forms.Button();
            this.btnPoDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(253, 202);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(49, 49);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // btnProduceSelect
            // 
            this.btnProduceSelect.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnProduceSelect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnProduceSelect.ForeColor = System.Drawing.Color.White;
            this.btnProduceSelect.Location = new System.Drawing.Point(169, 129);
            this.btnProduceSelect.Name = "btnProduceSelect";
            this.btnProduceSelect.Size = new System.Drawing.Size(126, 42);
            this.btnProduceSelect.TabIndex = 69;
            this.btnProduceSelect.Text = "执行领料";
            this.btnProduceSelect.Click += new System.EventHandler(this.btnProduceSelect_Click);
            // 
            // btnProduceDownload
            // 
            this.btnProduceDownload.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnProduceDownload.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnProduceDownload.ForeColor = System.Drawing.Color.White;
            this.btnProduceDownload.Location = new System.Drawing.Point(19, 129);
            this.btnProduceDownload.Name = "btnProduceDownload";
            this.btnProduceDownload.Size = new System.Drawing.Size(126, 42);
            this.btnProduceDownload.TabIndex = 68;
            this.btnProduceDownload.Text = "下载班次领料单";
            this.btnProduceDownload.Click += new System.EventHandler(this.btnProduceDownload_Click);
            // 
            // btnPoSelect
            // 
            this.btnPoSelect.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnPoSelect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnPoSelect.ForeColor = System.Drawing.Color.White;
            this.btnPoSelect.Location = new System.Drawing.Point(169, 45);
            this.btnPoSelect.Name = "btnPoSelect";
            this.btnPoSelect.Size = new System.Drawing.Size(126, 42);
            this.btnPoSelect.TabIndex = 65;
            this.btnPoSelect.Text = "执行采购入库";
            this.btnPoSelect.Click += new System.EventHandler(this.btnPoSelect_Click);
            // 
            // btnPoDownload
            // 
            this.btnPoDownload.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnPoDownload.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnPoDownload.ForeColor = System.Drawing.Color.White;
            this.btnPoDownload.Location = new System.Drawing.Point(19, 45);
            this.btnPoDownload.Name = "btnPoDownload";
            this.btnPoDownload.Size = new System.Drawing.Size(126, 42);
            this.btnPoDownload.TabIndex = 64;
            this.btnPoDownload.Text = "下载采购单";
            this.btnPoDownload.Click += new System.EventHandler(this.btnPoDownload_Click);
            // 
            // FrmMainRm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.btnProduceSelect);
            this.Controls.Add(this.btnProduceDownload);
            this.Controls.Add(this.btnPoSelect);
            this.Controls.Add(this.btnPoDownload);
            this.Controls.Add(this.pbExit);
            this.Name = "FrmMainRm";
            this.Text = "原料管理模块";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Button btnProduceSelect;
        private System.Windows.Forms.Button btnProduceDownload;
        private System.Windows.Forms.Button btnPoSelect;
        private System.Windows.Forms.Button btnPoDownload;
    }
}