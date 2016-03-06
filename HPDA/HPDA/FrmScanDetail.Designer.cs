namespace HPDA
{
    partial class FrmScanDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblcInvName = new System.Windows.Forms.Label();
            this.lblcInvCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mBc2 = new Symbol.Barcode2.Design.Barcode2();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGridMain
            // 
            this.dGridMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dGridMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGridMain.Location = new System.Drawing.Point(0, 59);
            this.dGridMain.Name = "dGridMain";
            this.dGridMain.Size = new System.Drawing.Size(318, 173);
            this.dGridMain.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblcInvName);
            this.panel1.Controls.Add(this.lblcInvCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 59);
            // 
            // lblcInvName
            // 
            this.lblcInvName.Location = new System.Drawing.Point(71, 35);
            this.lblcInvName.Name = "lblcInvName";
            this.lblcInvName.Size = new System.Drawing.Size(225, 20);
            // 
            // lblcInvCode
            // 
            this.lblcInvCode.Location = new System.Drawing.Point(71, 4);
            this.lblcInvCode.Name = "lblcInvCode";
            this.lblcInvCode.Size = new System.Drawing.Size(225, 20);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.Text = "名称";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.Text = "编码";
            // 
            // mBc2
            // 
            this.mBc2.Config.DecoderParameters.CODABAR = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.CODABARParams.ClsiEditing = false;
            this.mBc2.Config.DecoderParameters.CODABARParams.NotisEditing = false;
            this.mBc2.Config.DecoderParameters.CODABARParams.Redundancy = true;
            this.mBc2.Config.DecoderParameters.CODE128 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.CODE128Params.EAN128 = true;
            this.mBc2.Config.DecoderParameters.CODE128Params.ISBT128 = true;
            this.mBc2.Config.DecoderParameters.CODE128Params.Other128 = true;
            this.mBc2.Config.DecoderParameters.CODE128Params.Redundancy = false;
            this.mBc2.Config.DecoderParameters.CODE39 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.CODE39Params.Code32Prefix = false;
            this.mBc2.Config.DecoderParameters.CODE39Params.Concatenation = false;
            this.mBc2.Config.DecoderParameters.CODE39Params.ConvertToCode32 = false;
            this.mBc2.Config.DecoderParameters.CODE39Params.FullAscii = false;
            this.mBc2.Config.DecoderParameters.CODE39Params.Redundancy = false;
            this.mBc2.Config.DecoderParameters.CODE39Params.ReportCheckDigit = false;
            this.mBc2.Config.DecoderParameters.CODE39Params.VerifyCheckDigit = false;
            this.mBc2.Config.DecoderParameters.CODE93 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.CODE93Params.Redundancy = false;
            this.mBc2.Config.DecoderParameters.D2OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.D2OF5Params.Redundancy = true;
            this.mBc2.Config.DecoderParameters.EAN13 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.EAN8 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.EAN8Params.ConvertToEAN13 = false;
            this.mBc2.Config.DecoderParameters.I2OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.I2OF5Params.ConvertToEAN13 = false;
            this.mBc2.Config.DecoderParameters.I2OF5Params.Redundancy = true;
            this.mBc2.Config.DecoderParameters.I2OF5Params.ReportCheckDigit = false;
            this.mBc2.Config.DecoderParameters.I2OF5Params.VerifyCheckDigit = Symbol.Barcode2.Design.I2OF5.CheckDigitSchemes.Default;
            this.mBc2.Config.DecoderParameters.KOREAN_3OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.KOREAN_3OF5Params.Redundancy = true;
            this.mBc2.Config.DecoderParameters.MSI = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.MSIParams.CheckDigitCount = Symbol.Barcode2.Design.CheckDigitCounts.Default;
            this.mBc2.Config.DecoderParameters.MSIParams.CheckDigitScheme = Symbol.Barcode2.Design.CheckDigitSchemes.Default;
            this.mBc2.Config.DecoderParameters.MSIParams.Redundancy = true;
            this.mBc2.Config.DecoderParameters.MSIParams.ReportCheckDigit = false;
            this.mBc2.Config.DecoderParameters.UPCA = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.UPCAParams.Preamble = Symbol.Barcode2.Design.Preambles.Default;
            this.mBc2.Config.DecoderParameters.UPCAParams.ReportCheckDigit = true;
            this.mBc2.Config.DecoderParameters.UPCE0 = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.DecoderParameters.UPCE0Params.ConvertToUPCA = false;
            this.mBc2.Config.DecoderParameters.UPCE0Params.Preamble = Symbol.Barcode2.Design.Preambles.Default;
            this.mBc2.Config.DecoderParameters.UPCE0Params.ReportCheckDigit = false;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimDuration = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.BeamTimer = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.DPMMode = Symbol.Barcode2.Design.DPM_MODE.DPM_MODE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusMode = Symbol.Barcode2.Design.FOCUS_MODE.FOCUS_MODE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusPosition = Symbol.Barcode2.Design.FOCUS_POSITION.FOCUS_POSITION_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.IlluminationMode = Symbol.Barcode2.Design.ILLUMINATION_MODE.ILLUMINATION_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCaptureTimeout = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCompressionTimeout = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.Inverse1DMode = Symbol.Barcode2.Design.INVERSE1D_MODE.INVERSE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistMode = Symbol.Barcode2.Design.PICKLIST_MODE.PICKLIST_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PointerTimer = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PoorQuality1DMode = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedback = Symbol.Barcode2.Design.VIEWFINDER_FEEDBACK.VIEWFINDER_FEEDBACK_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedbackTime = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFMode = Symbol.Barcode2.Design.VIEWFINDER_MODE.VIEWFINDER_MODE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Bottom = 0;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Left = 0;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Right = 0;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Top = 0;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimDuration = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamTimer = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamWidth = Symbol.Barcode2.Design.BEAM_WIDTH.DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BidirRedundancy = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ControlScanLed = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.DBPMode = Symbol.Barcode2.Design.DBP_MODE.DBP_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.KlasseEinsEnable = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.PointerTimer = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterHeight = -1;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterMode = Symbol.Barcode2.Design.RASTER_MODE.RASTER_MODE_DEFAULT;
            this.mBc2.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ScanLedLogicLevel = Symbol.Barcode2.Design.DisabledEnabled.Default;
            this.mBc2.Config.ScanParameters.BeepFrequency = 2670;
            this.mBc2.Config.ScanParameters.BeepTime = 200;
            this.mBc2.Config.ScanParameters.CodeIdType = Symbol.Barcode2.Design.CodeIdTypes.Default;
            this.mBc2.Config.ScanParameters.LedTime = 3000;
            this.mBc2.Config.ScanParameters.ScanType = Symbol.Barcode2.Design.SCANTYPES.Default;
            this.mBc2.Config.ScanParameters.WaveFile = "";
            this.mBc2.DeviceType = Symbol.Barcode2.DEVICETYPES.FIRSTAVAILABLE;
            this.mBc2.EnableScanner = false;
            this.mBc2.OnScan += new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler(this.mBc2_OnScan);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(98, 235);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(187, 20);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.Text = "总库存";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmScanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 269);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dGridMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmScanDetail";
            this.Text = "现存量查询";
            this.Load += new System.EventHandler(this.FrmScanDetail_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmScanDetail_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dGridMain;
        private System.Windows.Forms.Panel panel1;
        private Symbol.Barcode2.Design.Barcode2 mBc2;
        private System.Windows.Forms.Label lblcInvName;
        private System.Windows.Forms.Label lblcInvCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label label8;
    }
}