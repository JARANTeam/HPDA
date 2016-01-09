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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Desktop;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(29, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 26);
            this.button2.TabIndex = 57;
            this.button2.Text = "下载出库指令";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Desktop;
            this.button3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(157, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 26);
            this.button3.TabIndex = 58;
            this.button3.Text = "执行出库";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Desktop;
            this.button4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(157, 121);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 26);
            this.button4.TabIndex = 60;
            this.button4.Text = "执行调拨";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Desktop;
            this.button5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(29, 121);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 26);
            this.button5.TabIndex = 59;
            this.button5.Text = "下载调拨单";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Desktop;
            this.button6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(157, 166);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 26);
            this.button6.TabIndex = 62;
            this.button6.Text = "执行盘点";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Desktop;
            this.button7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(29, 166);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(104, 26);
            this.button7.TabIndex = 61;
            this.button7.Text = "下载盘点单";
            // 
            // FrmMainPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbExit);
            this.Name = "FrmMainPro";
            this.Text = "产成品管理模块";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}