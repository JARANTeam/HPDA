namespace HPDA
{
    partial class RmProduceDownLoad
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
            this.dGridMain = new System.Windows.Forms.DataGrid();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.mBc2 = new Symbol.Barcode2.Design.Barcode2();
            this.SuspendLayout();
            // 
            // dGridMain
            // 
            this.dGridMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dGridMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGridMain.Location = new System.Drawing.Point(0, 0);
            this.dGridMain.Name = "dGridMain";
            this.dGridMain.Size = new System.Drawing.Size(318, 200);
            this.dGridMain.TabIndex = 0;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(4, 207);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(147, 23);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(158, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.Text = "合计：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSum
            // 
            this.lblSum.Location = new System.Drawing.Point(210, 208);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(97, 20);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(56, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(207, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mBc2
            // 
            this.mBc2.OnScan += new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler(this.mBc2_OnScan);
            // 
            // RmProduceDownLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 268);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.dGridMain);
            this.Name = "RmProduceDownLoad";
            this.Text = "下载班次制令单";
            this.Load += new System.EventHandler(this.SFDownLoad_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.RmProduceDownLoad_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dGridMain;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Button btnSave;
        private Symbol.Barcode2.Design.Barcode2 mBc2;
    }
}