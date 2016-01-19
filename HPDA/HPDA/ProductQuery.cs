using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Symbol.Barcode2;

namespace HPDA
{
    public partial class ProductQuery : Form
    {
        public ProductQuery()
        {
            InitializeComponent();
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
            if (!cBarCode.StartsWith("SF"))
            {
                MessageBox.Show("无效条码", "Error");
                return;
            }
            //产品序列号
            var cSerialNumber = cBarCode.Substring(0, 16);
            var cmd = new SqlCommand("select * from View_ProductLabel where cBarCode=@cBarCode");
            cmd.Parameters.AddWithValue("@cBarCode", cSerialNumber);

            var con = new SqlConnection(frmLogin.WmsCon);
            var dtRaw = PDAFunction.GetSqlTable(con, cmd);

            if (dtRaw != null && dtRaw.Rows.Count > 0)
            {
                lblcSerialNumber.Text = dtRaw.Rows[0]["cSerialNumber"].ToString();
                lbldDate.Text = dtRaw.Rows[0]["dDate"].ToString();
                lblcInvCode.Text = dtRaw.Rows[0]["cInvCode"].ToString();
                lblcInvName.Text = dtRaw.Rows[0]["cInvName"].ToString();
                lblcLotNo.Text = dtRaw.Rows[0]["FBatchNo"].ToString();
                lblcOrderNumber.Text = dtRaw.Rows[0]["cOrderNumber"].ToString();
                lblcInvStd.Text = dtRaw.Rows[0]["cInvStd"].ToString();

            }
            else
            {
                lblcSerialNumber.Text = "";
                lbldDate.Text = "";
                lblcInvCode.Text = "";
                lblcInvName.Text = "";
                lblcLotNo.Text = "";
                lblcOrderNumber.Text = "";
                lblcInvStd.Text = "";


            }


        }


        private void ProductQuery_Load(object sender, EventArgs e)
        {
            mBc2.EnableScanner = true;
            mBc2.Config.ScanDataSize = 255;
        }

        private void ProductQuery_Closing(object sender, CancelEventArgs e)
        {
            mBc2.EnableScanner = false;
        }
    }
}