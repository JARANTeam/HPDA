namespace HPDA
{
    partial class RmPoSelect
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
            this.btnShowDetail = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dGridMain = new System.Windows.Forms.DataGrid();
            this.SuspendLayout();
            // 
            // btnShowDetail
            // 
            this.btnShowDetail.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnShowDetail.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowDetail.ForeColor = System.Drawing.Color.White;
            this.btnShowDetail.Location = new System.Drawing.Point(191, 240);
            this.btnShowDetail.Name = "btnShowDetail";
            this.btnShowDetail.Size = new System.Drawing.Size(102, 25);
            this.btnShowDetail.TabIndex = 6;
            this.btnShowDetail.Text = "显示收货明细";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(26, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 25);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除";
            // 
            // dGridMain
            // 
            this.dGridMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dGridMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGridMain.Location = new System.Drawing.Point(0, 0);
            this.dGridMain.Name = "dGridMain";
            this.dGridMain.Size = new System.Drawing.Size(318, 217);
            this.dGridMain.TabIndex = 4;
            // 
            // RmPoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.btnShowDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dGridMain);
            this.Name = "RmPoSelect";
            this.Text = "选择采购订单";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGrid dGridMain;
    }
}