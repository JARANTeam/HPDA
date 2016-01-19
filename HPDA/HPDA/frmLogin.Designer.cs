namespace HPDA
{
    partial class frmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mMain;

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
            this.mMain = new System.Windows.Forms.MainMenu();
            this.miMain = new System.Windows.Forms.MenuItem();
            this.miSetting = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mMain
            // 
            this.mMain.MenuItems.Add(this.miMain);
            // 
            // miMain
            // 
            this.miMain.MenuItems.Add(this.miSetting);
            this.miMain.Text = "系统";
            // 
            // miSetting
            // 
            this.miSetting.Text = "连接配置";
            this.miSetting.Click += new System.EventHandler(this.miSetting_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(39, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 26);
            this.label1.Text = "华翔MES管理PDA端";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(181, 226);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(109, 25);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtPwd.Location = new System.Drawing.Point(118, 175);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(157, 26);
            this.txtPwd.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtName.Location = new System.Drawing.Point(118, 129);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 26);
            this.txtName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Desktop;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.Text = "密     码";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Desktop;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "用户名";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Menu = this.mMain;
            this.Name = "frmLogin";
            this.Text = "登录界面";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem miMain;
        private System.Windows.Forms.MenuItem miSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

