namespace HPDA
{
    partial class RmPoStore
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
            this.lblOutAll = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnComplete.Text = "完成收货扫描";
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
            this.btnShowDetail.Text = "显示收货明细";
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
            this.label1.Text = "采购单号：";
            // 
            // RmPoStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.dGridMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnShowDetail);
            this.Name = "RmPoStore";
            this.Text = "采购收货扫描";
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
        private System.Windows.Forms.Label lblOutAll;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label1;
    }
}