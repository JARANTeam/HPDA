using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.Barcode2;
using System.Data.SqlClient;

namespace HPDA
{
    public partial class RawMaterial : Form
    {
        public RawMaterial()
        {
            InitializeComponent();
        }

        private void RawMaterial_Load(object sender, EventArgs e)
        {
            mBc2.EnableScanner = true;
            mBc2.Config.ScanDataSize = 255;

        }

        private void mBc2_OnScan(Symbol.Barcode2.ScanDataCollection scanDataCollection)
        {
            ScanData sData = scanDataCollection.GetFirst;
            var str = sData.Text;
            var sType = sData.Type.ToString();
            byte[] by = Encoding.Default.GetBytes(str);
            string sText = Encoding.GetEncoding(65001).GetString(by, 0, by.Length);

            scan_OnDecodeEvent(sText);
        }

        /// <summary>
        /// 扫描响应事件
        /// </summary>
        /// <param name="DecodeText">扫描到的条码内容</param>
        private void scan_OnDecodeEvent(string DecodeText)
        {
            var cBarCode = DecodeText;
            if ((!cBarCode.StartsWith("R*") || !cBarCode.Contains("*L*") || !cBarCode.Contains("*S*")))
            {
                MessageBox.Show("无效条码", "Error");
                return;
            }
            //产品序列号
            var cSerialNumber = cBarCode.Substring(cBarCode.IndexOf("*S*") + 3, 12);
            var cmd = new SqlCommand("select * from RmLabel where cSerialNumber=@cSerialNumber");
            cmd.Parameters.AddWithValue("@cSerialNumber", cSerialNumber);

            var con = new SqlConnection(frmLogin.WmsCon);
            var dtRaw = PDAFunction.GetSqlTable(con, cmd);

            if (dtRaw != null && dtRaw.Rows.Count > 0)
            {
                lblcDefine1.Text = dtRaw.Rows[0]["cDefine1"].ToString();
                lblcDefine2.Text = dtRaw.Rows[0]["cDefine2"].ToString();
                lblcInvCode.Text = dtRaw.Rows[0]["cInvCode"].ToString();
                lblcInvName.Text = dtRaw.Rows[0]["cInvName"].ToString();
                lblcLotNo.Text = dtRaw.Rows[0]["cLotNo"].ToString();
                lblcVendor.Text = dtRaw.Rows[0]["cVendor"].ToString();
                lbldDate.Text = dtRaw.Rows[0]["dDate"].ToString();

            }
            else
            {
                lblcDefine1.Text = "";
                lblcDefine2.Text = "";
                lblcInvCode.Text = "";
                lblcInvName.Text = "";
                lblcLotNo.Text = "";
                lblcVendor.Text = "";
                lbldDate.Text = "";


            }





        }

        private void RawMaterial_Closing(object sender, CancelEventArgs e)
        {
            mBc2.EnableScanner = false;
        }
    }
}