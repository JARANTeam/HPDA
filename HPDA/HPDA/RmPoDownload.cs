using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.Barcode2;
using System.Globalization;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace HPDA
{
    public partial class RmPoDownload : Form
    {
        public RmPoDownload()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 成品数据集
        /// </summary>
        private RmDataSet rds = new RmDataSet();


        private void RmPoDownload_Load(object sender, EventArgs e)
        {
            InitGrid();
            mBc2.EnableScanner = true;
            mBc2.Config.ScanDataSize = 200;
        }

        private void RmPoDownload_Closing(object sender, CancelEventArgs e)
        {
            mBc2.EnableScanner = false;
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
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = rds.RmPo.TableName };


            DataGridColumnStyle dgAutoID = new DataGridTextBoxColumn();
            dgAutoID.Width = 40;
            dgAutoID.MappingName = "RowNo";
            dgAutoID.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgAutoID);

            DataGridColumnStyle dgccOrderNumber = new DataGridTextBoxColumn();
            dgccOrderNumber.Width = 120;
            dgccOrderNumber.MappingName = "cOrderNumber";
            dgccOrderNumber.HeaderText = "采购单号";
            dgts.GridColumnStyles.Add(dgccOrderNumber);


            DataGridColumnStyle dgccInvCode = new DataGridTextBoxColumn();
            dgccInvCode.Width = 60;
            dgccInvCode.MappingName = "cInvCode";
            dgccInvCode.HeaderText = "原料编码";
            dgts.GridColumnStyles.Add(dgccInvCode);

            DataGridColumnStyle dgccInvName = new DataGridTextBoxColumn();
            dgccInvName.Width = 80;
            dgccInvName.MappingName = "cInvName";
            dgccInvName.HeaderText = "原料名称";
            dgts.GridColumnStyles.Add(dgccInvName);

            //DataGridColumnStyle dgccUnit = new DataGridTextBoxColumn();
            //dgccUnit.Width = 60;
            //dgccUnit.MappingName = "cUnit";
            //dgccUnit.HeaderText = "单位";
            //dgts.GridColumnStyles.Add(dgccUnit);

            DataGridColumnStyle dgciQuantity = new DataGridTextBoxColumn();
            dgciQuantity.Width = 70;
            dgciQuantity.MappingName = "iQuantity";
            dgciQuantity.HeaderText = "数量";
            dgts.GridColumnStyles.Add(dgciQuantity);


            DataGridColumnStyle dgccVendor = new DataGridTextBoxColumn();
            dgccVendor.Width = 70;
            dgccVendor.MappingName = "cVendor";
            dgccVendor.HeaderText = "供应商";
            dgts.GridColumnStyles.Add(dgccVendor);

            DataGridColumnStyle dgcMemo = new DataGridTextBoxColumn();
            dgcMemo.Width = 70;
            dgcMemo.MappingName = "cMemo";
            dgcMemo.HeaderText = "备注";
            dgts.GridColumnStyles.Add(dgcMemo);


            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = rds.RmPo;

        }


        /// <summary>
        /// 是不可以满足下载出库通知单的条件
        /// </summary>
        /// <returns></returns>
        private bool BoolCanOkDownLoad()
        {
            if (string.IsNullOrEmpty(txtBarCode.Text))
                return true;
            if (rds.RmPo.Rows.Count > 0)
            {
                MessageBox.Show(@"请先保存上一个采购订单!", @"Warning");
                return true;
            }
            var bCmd = new SQLiteCommand("select * from RmPo where cOrderNumber=@cOrderNumber");
            bCmd.Parameters.AddWithValue("@cOrderNumber", txtBarCode.Text.ToUpper());
            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, bCmd))
            {
                MessageBox.Show(@"该采购订单已经下载过!", @"Warning");

                txtBarCode.Text = "";
                return true;
            }
            return false;
        }

        /// <summary>
        /// 处理条码扫描事件
        /// </summary>
        /// <param name="DecodeText"></param>
        private void scan_OnDecodeEvent(String DecodeText)
        {
            
            if(!DecodeText.Contains(";"))
            {
                MessageBox.Show(@"无效条码", @"Warning");
                return;
            }
            var cOrder=DecodeText.Split(';');


            txtBarCode.Text = cOrder[0];
            var cOrderNumber = cOrder[0];



            if (BoolCanOkDownLoad()) return;


            //下载采购订单
            var cmd = new SqlCommand(@"select POInstock.FBillNo,t_Supplier.FName cVendor,POInstockEntry.FItemID,POInstockEntry.FEntryID,t_ICItem.FShortNumber cInvCode,
t_ICItem.FNumber,FModel,t_ICItem.FName cInvName,FQty 
from POInstock inner join POInstockEntry on POInstock.FInterID=POInstockEntry.FInterID  
inner join t_ICItem on POInstockEntry.FItemID=t_ICItem.FItemID 
inner join t_Supplier on POInstock.FSupplyID=t_Supplier.FItemID  
where POInstock.FInterID=@FinterID ");

           cmd.Parameters.AddWithValue("@FinterID", cOrder[1]);
           var con = new SqlConnection(frmLogin.KisCon);
           DataTable dtTemp = new DataTable("dtTemp");
            try
            {

                dtTemp = PDAFunction.GetSqlTable(con,cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + cOrderNumber, @"Warning");
                return;
            }

            if (!PDAFunction.IsCanCon())
            {
                MessageBox.Show(@"无法连接到服务器", @"Warning");
                return;
            }

            if (dtTemp == null)
            {
                MessageBox.Show(@"下载出错,请联系管理员", @"Warning");
                return;
            }


            if (dtTemp.Rows.Count < 1)
            {
                MessageBox.Show(@"无此采购单号!", @"Warning");
                return;
            }

            lblSum.Text = dtTemp.Rows.Count.ToString(CultureInfo.CurrentCulture) + "行";

            //进行循环判断是否属于当前库区 
            for (var i = 0; i < dtTemp.Rows.Count; i++)
            {
                var dr = rds.RmPo.NewRmPoRow();
                dr.cOrderNumber = cOrderNumber;
                dr.FItemID = dtTemp.Rows[i]["FItemID"].ToString();
                dr.FEntryID = dtTemp.Rows[i]["FEntryID"].ToString();
                dr.cInvCode = dtTemp.Rows[i]["cInvCode"].ToString();
                dr.cInvName = dtTemp.Rows[i]["cInvName"].ToString();
                dr.iQuantity = dtTemp.Rows[i]["FQty"].ToString();
                dr.cVendor = dtTemp.Rows[i]["cVendor"].ToString();
                dr.cMemo = "";
                rds.RmPo.Rows.Add(dr);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rds.RmPo.Rows.Count <= 0)
                return;
            if (!PDAFunction.IsCanCon())
            {
                MessageBox.Show(@"无法连接到服务器", @"Warning");
                return;
            }
            for (var i = 0; i <= rds.RmPo.Rows.Count - 1; i++)
            {
                var cmd = new SQLiteCommand
                {
                    CommandText = "insert into RmPo(cOrderNumber,FitemID,FEntryID,cInvCode,cInvName,cUnit,iQuantity,iScanQuantity,cVendor,cMemo) values(@cOrderNumber,@FitemID,@FEntryID,@cInvCode,@cInvName,@cUnit,@iQuantity,0,@cVendor,@cMemo)"
                };
                cmd.Parameters.AddWithValue("@cOrderNumber", rds.RmPo.Rows[i]["cOrderNumber"]);
                cmd.Parameters.AddWithValue("@FitemID", rds.RmPo.Rows[i]["FItemID"]);
                cmd.Parameters.AddWithValue("@FEntryID", rds.RmPo.Rows[i]["FEntryID"]);
                cmd.Parameters.AddWithValue("@cInvCode", rds.RmPo.Rows[i]["cInvCode"]);
                cmd.Parameters.AddWithValue("@cInvName", rds.RmPo.Rows[i]["cInvName"]);
                cmd.Parameters.AddWithValue("@cUnit", "1");
                cmd.Parameters.AddWithValue("@iQuantity", rds.RmPo.Rows[i]["iQuantity"]);
                cmd.Parameters.AddWithValue("@cVendor", rds.RmPo.Rows[i]["cVendor"]);
                cmd.Parameters.AddWithValue("@cMemo", rds.RmPo.Rows[i]["cMemo"]);
                PDAFunction.ExecSqLite(cmd);
            }
            //写下载日志
            var logCmd = new SqlCommand("AddLogAction");
            logCmd.CommandType = CommandType.StoredProcedure;
            logCmd.Parameters.AddWithValue("@cFunction", "采购订单下载");
            logCmd.Parameters.AddWithValue("@cDescription", frmLogin.lUser + "下载采购订单：" + rds.RmPo.Rows[0]["cOrderNumber"]);
            var ucon = new SqlConnection(frmLogin.WmsCon);
            PDAFunction.ExecSqL(ucon, logCmd);
            MessageBox.Show(@"成功保存", @"Success");
            rds.RmPo.Rows.Clear();
            lblSum.Text = "";
            txtBarCode.Text = "";
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            scan_OnDecodeEvent(txtBarCode.Text);
        }

       
    }
}