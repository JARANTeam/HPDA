namespace HPDA
{
    partial class PdaGetQuantity
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
            this.lblcLotNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtiNum = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblcInvCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblcInvName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblcLotNo
            // 
            this.lblcLotNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblcLotNo.Location = new System.Drawing.Point(59, 137);
            this.lblcLotNo.Name = "lblcLotNo";
            this.lblcLotNo.Size = new System.Drawing.Size(165, 20);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.Text = "批号";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 23);
            this.label1.Text = "数量";
            // 
            // txtiNum
            // 
            this.txtiNum.Location = new System.Drawing.Point(59, 173);
            this.txtiNum.Name = "txtiNum";
            this.txtiNum.Size = new System.Drawing.Size(107, 23);
            this.txtiNum.TabIndex = 5;
            this.txtiNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtiNum_KeyDown);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnSubmit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(165, 172);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(72, 25);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblcInvCode
            // 
            this.lblcInvCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblcInvCode.Location = new System.Drawing.Point(59, 21);
            this.lblcInvCode.Name = "lblcInvCode";
            this.lblcInvCode.Size = new System.Drawing.Size(158, 20);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(18, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.Text = "编码";
            // 
            // lblcInvName
            // 
            this.lblcInvName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblcInvName.Location = new System.Drawing.Point(59, 49);
            this.lblcInvName.Name = "lblcInvName";
            this.lblcInvName.Size = new System.Drawing.Size(158, 74);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(18, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.Text = "名称";
            // 
            // PdaGetQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(254, 225);
            this.Controls.Add(this.lblcInvName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblcInvCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblcLotNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtiNum);
            this.Controls.Add(this.btnSubmit);
            this.Name = "PdaGetQuantity";
            this.Text = "请输入数量";
            this.Load += new System.EventHandler(this.PdaGetQuantity_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblcLotNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtiNum;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblcInvCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblcInvName;
        private System.Windows.Forms.Label label6;
    }
}