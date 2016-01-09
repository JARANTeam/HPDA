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
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Desktop;
            this.button6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(169, 129);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 47);
            this.button6.TabIndex = 69;
            this.button6.Text = "执行领料";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Desktop;
            this.button7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(19, 129);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 47);
            this.button7.TabIndex = 68;
            this.button7.Text = "下载班次领料单";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Desktop;
            this.button3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(169, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 42);
            this.button3.TabIndex = 65;
            this.button3.Text = "执行采购入库";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Desktop;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(19, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 42);
            this.button2.TabIndex = 64;
            this.button2.Text = "下载采购单";
            // 
            // FrmMainRm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pbExit);
            this.Name = "FrmMainRm";
            this.Text = "原料管理模块";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}