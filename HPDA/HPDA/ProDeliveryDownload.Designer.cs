namespace HPDA
{
    partial class ProDeliveryDownload
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mBc2 = new Symbol.Barcode2.Design.Barcode2();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.dGridMain = new System.Windows.Forms.DataGrid();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(56, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(207, 26);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            // 
            // lblSum
            // 
            this.lblSum.Location = new System.Drawing.Point(210, 211);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(97, 20);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(158, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.Text = "合计：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(4, 210);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(147, 23);
            this.txtBarCode.TabIndex = 9;
            // 
            // dGridMain
            // 
            this.dGridMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dGridMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGridMain.Location = new System.Drawing.Point(0, 0);
            this.dGridMain.Name = "dGridMain";
            this.dGridMain.Size = new System.Drawing.Size(318, 200);
            this.dGridMain.TabIndex = 8;
            // 
            // ProDeliveryDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.dGridMain);
            this.Name = "ProDeliveryDownload";
            this.Text = "出库单下载";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label label1;
        private Symbol.Barcode2.Design.Barcode2 mBc2;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.DataGrid dGridMain;
    }
}