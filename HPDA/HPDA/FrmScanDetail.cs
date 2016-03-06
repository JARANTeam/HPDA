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
    public partial class FrmScanDetail : Form
    {
        ProDataSet prods = new ProDataSet();

        string FitemID=string.Empty;
        public FrmScanDetail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = prods.StockDetail.TableName };


            DataGridColumnStyle dgRowNo = new DataGridTextBoxColumn();
            dgRowNo.Width = 40;
            dgRowNo.MappingName = "RowNo";
            dgRowNo.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgRowNo);

            DataGridColumnStyle dgAutoID = new DataGridTextBoxColumn();
            dgAutoID.Width = 90;
            dgAutoID.MappingName = "FBatchNo";
            dgAutoID.HeaderText = "批号";
            dgts.GridColumnStyles.Add(dgAutoID);

            DataGridColumnStyle dgccOrderNumber = new DataGridTextBoxColumn();
            dgccOrderNumber.Width = 90;
            dgccOrderNumber.MappingName = "FQty";
            dgccOrderNumber.HeaderText = "数量";
            dgts.GridColumnStyles.Add(dgccOrderNumber);


            DataGridColumnStyle dgccInvCode = new DataGridTextBoxColumn();
            dgccInvCode.Width = 60;
            dgccInvCode.MappingName = "FStockName";
            dgccInvCode.HeaderText = "仓库";
            dgts.GridColumnStyles.Add(dgccInvCode);

            DataGridColumnStyle dgccInvName = new DataGridTextBoxColumn();
            dgccInvName.Width = 80;
            dgccInvName.MappingName = "FStockPlaceNumber";
            dgccInvName.HeaderText = "仓位编码";
            dgts.GridColumnStyles.Add(dgccInvName);

            //DataGridColumnStyle dgccUnit = new DataGridTextBoxColumn();
            //dgccUnit.Width = 60;
            //dgccUnit.MappingName = "cUnit";
            //dgccUnit.HeaderText = "单位";
            //dgts.GridColumnStyles.Add(dgccUnit);

            DataGridColumnStyle dgciQuantity = new DataGridTextBoxColumn();
            dgciQuantity.Width = 70;
            dgciQuantity.MappingName = "FStockPlaceName";
            dgciQuantity.HeaderText = "仓位";
            dgts.GridColumnStyles.Add(dgciQuantity);




            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = prods.StockDetail;

        }



        private void FrmScanDetail_Load(object sender, EventArgs e)
        {
            InitGrid();
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
                if ((!cBarCode.StartsWith("P*") || !cBarCode.Contains("*L*") || !cBarCode.Contains("*S*")))
                {
                    MessageBox.Show("无效条码", "Error");
                    return;
                }
                //产品序列号
                var cSerialNumber = cBarCode.Substring(cBarCode.IndexOf("*S*") + 3, 16);
                var cmd = new SqlCommand("select * from View_ProductLabel where cBarCode=@cBarCode");
                cmd.Parameters.AddWithValue("@cBarCode", cSerialNumber);

                var con = new SqlConnection(frmLogin.WmsCon);
                var dtRaw = PDAFunction.GetSqlTable(con, cmd);

                if (dtRaw != null && dtRaw.Rows.Count > 0)
                {
                    
                    lblcInvCode.Text = dtRaw.Rows[0]["cInvCode"].ToString();
                    lblcInvName.Text = dtRaw.Rows[0]["cInvName"].ToString();
                    FitemID = dtRaw.Rows[0]["cFitemID"].ToString();

                }
                else
                {
                   
                    lblcInvCode.Text = "";
                    lblcInvName.Text = "";
                    lblQuantity.Text = "";
                    FitemID = "";

                }

            }
            else
            {
                //产品序列号
                var cSerialNumber = cBarCode.Substring(cBarCode.IndexOf("*S*") + 3, 12);
                var cmd = new SqlCommand("select * from RmLabel where cSerialNumber=@cSerialNumber");
                cmd.Parameters.AddWithValue("@cSerialNumber", cSerialNumber);

                var con = new SqlConnection(frmLogin.WmsCon);
                var dtRaw = PDAFunction.GetSqlTable(con, cmd);

                if (dtRaw != null && dtRaw.Rows.Count > 0)
                {

                   
                    lblcInvCode.Text = dtRaw.Rows[0]["cInvCode"].ToString();
                    lblcInvName.Text = dtRaw.Rows[0]["cInvName"].ToString();
                    FitemID = dtRaw.Rows[0]["FitemID"].ToString();
                }
                else
                {
                    
                    lblcInvCode.Text = "";
                    lblcInvName.Text = "";

                    lblQuantity.Text = "";
                    FitemID = "";

                }

            }

            if (string.IsNullOrEmpty(FitemID))
                return;

            var cmdAll = new SqlCommand("select sum(FQty) from ICInventory where FitemID=@FitemID");
            cmdAll.Parameters.AddWithValue("@FitemID", FitemID);
            var conAll = new SqlConnection(frmLogin.KisCon);
            lblQuantity.Text = PDAFunction.GetSqlSingle(conAll, cmdAll);


            var cmdDetail = new SqlCommand(@"select a.FBatchNo,FQty,c.FName FStockName,d.FNumber FStockPlaceNumber,d.FName FStockPlaceName
from ICInventory a inner join t_ICItem b on a.FItemID=b.FItemID 
inner join t_Stock c on a.FStockID=c.FItemID inner join t_StockPlace d on a.FStockPlaceID=d.FSPID
where a.FQty>0 and a.FItemID =@FItemID  order by a.FItemID,a.FBatchNo,a.FStockID,a.FStockPlaceID");
            cmdDetail.Parameters.AddWithValue("@FitemID", FitemID);
            var conDetail = new SqlConnection(frmLogin.KisCon);
            var dtTemp = PDAFunction.GetSqlTable(conDetail, cmdDetail);

            if (dtTemp == null)
                return;

            prods.StockDetail.Rows.Clear();
            for (var i = 0; i < dtTemp.Rows.Count; i++)
            {
                var dr = prods.StockDetail.NewStockDetailRow();
                dr.FBatchNo = dtTemp.Rows[i]["FBatchNo"].ToString();
                dr.FQty = dtTemp.Rows[i]["FQty"].ToString();
                dr.FStockName = dtTemp.Rows[i]["FStockName"].ToString();
                dr.FStockPlaceNumber = dtTemp.Rows[i]["FStockPlaceNumber"].ToString();
                dr.FStockPlaceName = dtTemp.Rows[i]["FStockPlaceName"].ToString();
                prods.StockDetail.Rows.Add(dr);

            }



        }

        private void FrmScanDetail_Closing(object sender, CancelEventArgs e)
        {
            mBc2.EnableScanner = false;
        }

    }
}