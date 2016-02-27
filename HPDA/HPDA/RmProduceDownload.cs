using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using System.Data.SqlClient;
using Symbol.Barcode2;

namespace HPDA
{
    public partial class RmProduceDownLoad : Form
    {
        public RmProduceDownLoad()
        {
            InitializeComponent();
        }

        private RmDataSet rds = new RmDataSet();

        /// <summary>
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = rds.RmProduce.TableName};


            DataGridColumnStyle dgAutoID = new DataGridTextBoxColumn();
            dgAutoID.Width = 40;
            dgAutoID.MappingName = "RowNo";
            dgAutoID.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgAutoID);

            DataGridColumnStyle dgccOrderNumber = new DataGridTextBoxColumn();
            dgccOrderNumber.Width = 120;
            dgccOrderNumber.MappingName = "cOrderNumber";
            dgccOrderNumber.HeaderText = "生产订单号";
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



            DataGridColumnStyle dgcMemo = new DataGridTextBoxColumn();
            dgcMemo.Width = 70;
            dgcMemo.MappingName = "cMemo";
            dgcMemo.HeaderText = "备注";
            dgts.GridColumnStyles.Add(dgcMemo);


            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = rds.RmProduce;

        }

        private void SFDownLoad_Load(object sender, EventArgs e)
        {
            InitGrid();
            mBc2.EnableScanner = true;
        }

        /// <summary>
        /// 是不可以满足下载出库通知单的条件
        /// </summary>
        /// <returns></returns>
        private bool BoolCanOkDownLoad()
        {
            if (string.IsNullOrEmpty(txtBarCode.Text))
                return true;
            if (rds.RmProduce.Rows.Count > 0)
            {
                MessageBox.Show(@"请先保存上一个生产订单!", @"Warning");
                return true;
            }
            var bCmd = new SQLiteCommand("select * from RmProduce where cOrderNumber=@cOrderNumber");
            bCmd.Parameters.AddWithValue("@cOrderNumber", txtBarCode.Text.ToUpper());
            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, bCmd))
            {
                MessageBox.Show(@"该生产订单已经下载过!", @"Warning");
                
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
            txtBarCode.Text = DecodeText;
            if (BoolCanOkDownLoad()) return;
            //通过WebService获取系统数据
            //var js = new EasOrderService.EasOrder();
            //js.Url = frmLogin.EasUri;
            DataTable dtTemp = new DataTable("dtTemp");
            try
            {
                //dtTemp = js.GetProduceDetail(DecodeText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + DecodeText, @"Warning");
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
                MessageBox.Show(@"无此生产订单!", @"Warning");
                return;
            }

            lblSum.Text = dtTemp.Rows.Count.ToString(CultureInfo.CurrentCulture) + "行";

            //进行循环判断是否属于当前库区 
            for (var i = 0; i < dtTemp.Rows.Count; i++)
            {
                var dr=rds.RmProduce.NewRmProduceRow();
                dr.cOrderNumber=DecodeText;
                dr.cInvCode = dtTemp.Rows[i]["cInvCode"].ToString();
                dr.cInvName = dtTemp.Rows[i]["cInvName"].ToString();
                dr.iQuantity = dtTemp.Rows[i]["iQuantity"].ToString();
                dr.cMemo = dtTemp.Rows[i]["cMemo"].ToString();
                rds.RmProduce.Rows.Add(dr);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rds.RmProduce.Rows.Count <= 0)
                return;
            if (!PDAFunction.IsCanCon())
            {
                MessageBox.Show(@"无法连接到服务器", @"Warning");
                return;
            }
            for (var i = 0; i <= rds.RmProduce.Rows.Count - 1; i++)
            {
                var cmd = new SQLiteCommand
                {
                    CommandText = "insert into RmProduce(cOrderNumber,cInvCode,cInvName,cUnit,iQuantity,iScanQuantity,cMemo) values(@cOrderNumber,@cInvCode,@cInvName,@cUnit,@iQuantity,0,@cMemo)"
                };
                cmd.Parameters.AddWithValue("@cOrderNumber", rds.RmProduce.Rows[i]["cOrderNumber"]);
                cmd.Parameters.AddWithValue("@cInvCode", rds.RmProduce.Rows[i]["cInvCode"]);
                cmd.Parameters.AddWithValue("@cInvName", rds.RmProduce.Rows[i]["cInvName"]);
                cmd.Parameters.AddWithValue("@cUnit", "1");
                cmd.Parameters.AddWithValue("@iQuantity", rds.RmProduce.Rows[i]["iQuantity"]);
                cmd.Parameters.AddWithValue("@cMemo", rds.RmProduce.Rows[i]["cMemo"]);
                PDAFunction.ExecSqLite(cmd);
            }
            //写下载日志
            var logCmd = new SqlCommand("AddLogAction");
            logCmd.CommandType = CommandType.StoredProcedure;
            logCmd.Parameters.AddWithValue("@cFunction", "生产订单下载");
            logCmd.Parameters.AddWithValue("@cDescription", frmLogin.lUser + "下载生产订单：" + rds.RmProduce.Rows[0]["cOrderNumber"]);
            var ucon = new SqlConnection(frmLogin.WmsCon);
            PDAFunction.ExecSqL(ucon, logCmd);
            MessageBox.Show(@"成功保存", @"Success");
            rds.RmProduce.Rows.Clear();
            lblSum.Text = "";
            txtBarCode.Text = "";
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            scan_OnDecodeEvent(txtBarCode.Text);
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

        private void RmProduceDownLoad_Closing(object sender, CancelEventArgs e)
        {
            mBc2.EnableScanner = false;
        }

    }
}