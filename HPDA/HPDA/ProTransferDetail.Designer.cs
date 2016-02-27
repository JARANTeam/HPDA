namespace HPDA
{
    partial class ProTransferDetail
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGridMain
            // 
            this.dGridMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dGridMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGridMain.Location = new System.Drawing.Point(0, 25);
            this.dGridMain.Name = "dGridMain";
            this.dGridMain.Size = new System.Drawing.Size(318, 203);
            this.dGridMain.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblOrderNumber);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(318, 25);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Location = new System.Drawing.Point(97, 2);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(193, 20);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.Text = "调拨单号：";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(233, 239);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 25);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "关闭";
            // 
            // ProTransferDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.dGridMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnExit);
            this.Name = "ProTransferDetail";
            this.Text = "调拨单明细";
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dGridMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}