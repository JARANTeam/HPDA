namespace HPDA
{
    partial class RmProduceDetail
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
            this.btnExit = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();


            this.label2 = new System.Windows.Forms.Label();

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
            this.dGridMain.TabIndex = 1;
            this.dGridMain.DoubleClick += new System.EventHandler(this.dGridMain_DoubleClick);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(233, 234);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 25);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "关闭";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.label1.Text = "生产单号：";
            // 


            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(18, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 20);
            this.label2.Text = "无批号领料，可双击点选完成";
            // 

            // RmProduceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 268);


            this.Controls.Add(this.label2);

            this.Controls.Add(this.dGridMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnExit);
            this.Name = "RmProduceDetail";
            this.Text = "生产领料明细";
            this.Load += new System.EventHandler(this.SSDetail_Load);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dGridMain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}