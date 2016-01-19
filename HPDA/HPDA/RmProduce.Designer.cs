namespace SPDA
{
    partial class RmProduce
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOutAll = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dGridMain = new System.Windows.Forms.DataGrid();
            this.btnShowDetail = new System.Windows.Forms.Button();
            this.lblSum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.btnComplete = new System.Windows.Forms.Button();
            this.mBc2 = new Symbol.Barcode2.Design.Barcode2();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblOutAll);
            this.panel1.Controls.Add(this.lblOrderNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 33);
            // 
            // lblOutAll
            // 
            this.lblOutAll.ForeColor = System.Drawing.Color.Red;
            this.lblOutAll.Location = new System.Drawing.Point(253, 7);
            this.lblOutAll.Name = "lblOutAll";
            this.lblOutAll.Size = new System.Drawing.Size(62, 20);
            this.lblOutAll.Text = "未完成";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Location = new System.Drawing.Point(94, 7);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(153, 20);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.Text = "生产单号：";
            // 
            // dGridMain
            // 
            this.dGridMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dGridMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGridMain.Location = new System.Drawing.Point(0, 33);
            this.dGridMain.Name = "dGridMain";
            this.dGridMain.Size = new System.Drawing.Size(318, 136);
            this.dGridMain.TabIndex = 1;
            this.dGridMain.DoubleClick += new System.EventHandler(this.dGridMain_DoubleClick);
            // 
            // btnShowDetail
            // 
            this.btnShowDetail.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnShowDetail.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowDetail.ForeColor = System.Drawing.Color.White;
            this.btnShowDetail.Location = new System.Drawing.Point(211, 176);
            this.btnShowDetail.Name = "btnShowDetail";
            this.btnShowDetail.Size = new System.Drawing.Size(102, 25);
            this.btnShowDetail.TabIndex = 4;
            this.btnShowDetail.Text = "显示领料明细";
            this.btnShowDetail.Click += new System.EventHandler(this.btnShowDetail_Click);
            // 
            // lblSum
            // 
            this.lblSum.Location = new System.Drawing.Point(81, 181);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(101, 20);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.Text = "已扫数量：";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(3, 205);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(310, 23);
            this.txtBarCode.TabIndex = 9;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnComplete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(211, 234);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(102, 25);
            this.btnComplete.TabIndex = 10;
            this.btnComplete.Text = "完成领料扫描";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // mBc2
            // 
            this.mBc2.OnScan += new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler(this.mBc2_OnScan);
            // 
            // RmProduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 268);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnShowDetail);
            this.Controls.Add(this.dGridMain);
            this.Controls.Add(this.panel1);
            this.Name = "RmProduce";
            this.Text = "生产领料扫描";
            this.Load += new System.EventHandler(this.RmPoStore_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.RmPoStore_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOutAll;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dGridMain;
        private System.Windows.Forms.Button btnShowDetail;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Button btnComplete;
        private Symbol.Barcode2.Design.Barcode2 mBc2;
    }
}