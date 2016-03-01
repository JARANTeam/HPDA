using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.Barcode2;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Globalization;

namespace HPDA
{
    public partial class ProDeliveryDownload : Form
    {


        /// <summary>
        /// 成品数据集
        /// </summary>
        private ProDataSet prods = new ProDataSet();

        /// <summary>
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = prods.ProDelivery.TableName };


            DataGridColumnStyle dgRowNo = new DataGridTextBoxColumn();
            dgRowNo.Width = 40;
            dgRowNo.MappingName = "RowNo";
            dgRowNo.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgRowNo);

            //DataGridColumnStyle dgAutoID = new DataGridTextBoxColumn();
            //dgAutoID.Width = 40;
            //dgAutoID.MappingName = "AutoID";
            //dgAutoID.HeaderText = "";
            //dgts.GridColumnStyles.Add(dgAutoID);

            DataGridColumnStyle dgccOrderNumber = new DataGridTextBoxColumn();
            dgccOrderNumber.Width = 120;
            dgccOrderNumber.MappingName = "cCode";
            dgccOrderNumber.HeaderText = "单号";
            dgts.GridColumnStyles.Add(dgccOrderNumber);


            DataGridColumnStyle dgccCusName = new DataGridTextBoxColumn();
            dgccCusName.Width = 70;
            dgccCusName.MappingName = "cCusName";
            dgccCusName.HeaderText = "客户";
            dgts.GridColumnStyles.Add(dgccCusName);

            DataGridColumnStyle dgccMaker = new DataGridTextBoxColumn();
            dgccMaker.Width = 70;
            dgccMaker.MappingName = "cMaker";
            dgccMaker.HeaderText = "制单人";
            dgts.GridColumnStyles.Add(dgccMaker);

            DataGridColumnStyle dgccDepName = new DataGridTextBoxColumn();
            dgccDepName.Width = 70;
            dgccDepName.MappingName = "cDepName";
            dgccDepName.HeaderText = "部门";
            dgts.GridColumnStyles.Add(dgccMaker);

            DataGridColumnStyle dgcMemo = new DataGridTextBoxColumn();
            dgcMemo.Width = 70;
            dgcMemo.MappingName = "cMemo";
            dgcMemo.HeaderText = "备注";
            dgts.GridColumnStyles.Add(dgcMemo);

            DataGridColumnStyle dgccVerifyState = new DataGridTextBoxColumn();
            dgccVerifyState.Width = 70;
            dgccVerifyState.MappingName = "cVerifyState";
            dgccVerifyState.HeaderText = "状态";
            dgts.GridColumnStyles.Add(dgccVerifyState);


            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = prods.ProDelivery;

        }

        public ProDeliveryDownload()
        {
            InitializeComponent();
        }

        private void ProDeliveryDownload_Load(object sender, EventArgs e)
        {
            InitGrid();
            mBc2.EnableScanner = true;
            mBc2.Config.ScanDataSize = 200;
        }

        private void ProDeliveryDownload_Closing(object sender, CancelEventArgs e)
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
        /// 是不可以满足下载出库通知单的条件
        /// </summary>
        /// <returns></returns>
        private bool BoolCanOkDownLoad()
        {
            if (string.IsNullOrEmpty(txtBarCode.Text))
                return true;
            if (prods.ProDelivery.Rows.Count > 0)
            {
                MessageBox.Show(@"请先保存上一个采购订单!", @"Warning");
                return true;
            }
            var bCmd = new SQLiteCommand("select * from ProDelivery where cOrderNumber=@cOrderNumber");
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

            txtBarCode.Text = DecodeText;
            var cOrderNumber = DecodeText;



            if (BoolCanOkDownLoad()) return;


            //下载采购订单
            var cmd = new SqlCommand(@"select * from ProDelivery where cCode=@cCode  ");

            cmd.Parameters.AddWithValue("@cCode", cOrderNumber);
            var con = new SqlConnection(frmLogin.WmsCon);
            DataTable dtTemp = new DataTable("dtTemp");
            try
            {

                dtTemp = PDAFunction.GetSqlTable(con, cmd);
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


            for (var i = 0; i < dtTemp.Rows.Count; i++)
            {
                var dr = prods.ProDelivery.NewProDeliveryRow();
                dr.cCode = cOrderNumber;
                dr.AutoID = dtTemp.Rows[i]["AutoID"].ToString();
                dr.cCusCode = dtTemp.Rows[i]["cCusCode"].ToString();
                dr.cCusName = dtTemp.Rows[i]["cCusName"].ToString();
                dr.cMaker = dtTemp.Rows[i]["cMaker"].ToString();
                dr.dMaketime = dtTemp.Rows[i]["dMaketime"].ToString();
                dr.cDepCode = dtTemp.Rows[i]["cDepCode"].ToString();
                dr.cDepName = dtTemp.Rows[i]["cDepName"].ToString();
                dr.cMemo = dtTemp.Rows[i]["cMemo"].ToString();
                dr.cVerifyState = dtTemp.Rows[i]["cVerifyState"].ToString();
                dr.cHandler = dtTemp.Rows[i]["cHandler"].ToString();
                dr.dVeriDate = dtTemp.Rows[i]["dVeriDate"].ToString();
                prods.ProDelivery.Rows.Add(dr);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (prods.ProDelivery.Rows.Count <= 0)
                return;
            if (!PDAFunction.IsCanCon())
            {
                MessageBox.Show(@"无法连接到服务器", @"Warning");
                return;
            }
            for (var i = 0; i <= prods.ProDelivery.Rows.Count - 1; i++)
            {
                var cmd = new SQLiteCommand
                {
                    CommandText = "insert into ProDelivery(AutoID,cCode,cCusCode,cCusName,cMaker,dMaketime,cDepCode,cDepName,cMemo,cVerifyState,dVeriDate) values(@AutoID,@cCode,@cCusCode,@cCusName,@cMaker,@dMaketime,@cDepCode,@cDepName,@cMemo,@cVerifyState,@dVeriDate)"
                };
                cmd.Parameters.AddWithValue("@AutoID", prods.ProDelivery.Rows[i]["AutoID"]);
                cmd.Parameters.AddWithValue("@cCode", prods.ProDelivery.Rows[i]["cCode"]);
                cmd.Parameters.AddWithValue("@cCusCode", prods.ProDelivery.Rows[i]["cCusCode"]);
                cmd.Parameters.AddWithValue("@cCusName", prods.ProDelivery.Rows[i]["cCusName"]);
                cmd.Parameters.AddWithValue("@cMaker", prods.ProDelivery.Rows[i]["cMaker"]);
                cmd.Parameters.AddWithValue("@dMaketime", prods.ProDelivery.Rows[i]["dMaketime"]);
                cmd.Parameters.AddWithValue("@cDepCode", prods.ProDelivery.Rows[i]["cDepCode"]);
                cmd.Parameters.AddWithValue("@cDepName", prods.ProDelivery.Rows[i]["cDepName"]);
                cmd.Parameters.AddWithValue("@cMemo", prods.ProDelivery.Rows[i]["cMemo"]);
                cmd.Parameters.AddWithValue("@cVerifyState", prods.ProDelivery.Rows[i]["cVerifyState"]);
                cmd.Parameters.AddWithValue("@dVeriDate", prods.ProDelivery.Rows[i]["dVeriDate"]);
                PDAFunction.ExecSqLite(cmd);
            }
            var ucmd = new SqlCommand("update ProDelivery set cVerifyState='拣货下载' where cCode=@cCode");
            ucmd.Parameters.AddWithValue("@cCode", prods.ProDelivery.Rows[0]["cCode"]);
            var ucon = new SqlConnection(frmLogin.WmsCon);
            PDAFunction.ExecSqL(ucon, ucmd);
            MessageBox.Show(@"成功保存", @"Success");
            prods.ProDelivery.Rows.Clear();
            lblSum.Text = "";
        }

    }
}