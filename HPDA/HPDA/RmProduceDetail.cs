using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SPDA
{
    public partial class RmProduceDetail : Form
    {

        /// <summary>
        /// 销售模块的数据架构集
        /// </summary>
        private RmDataSet rds = new RmDataSet();
        public RmProduceDetail(string cOrderNumber)
        {
            InitializeComponent();
            lblOrderNumber.Text = cOrderNumber;
        }

        /// <summary>
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = rds.RmProduce.TableName };


            DataGridColumnStyle dgAutoID = new DataGridTextBoxColumn();
            dgAutoID.Width = 40;
            dgAutoID.MappingName = "RowNo";
            dgAutoID.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgAutoID);

            DataGridColumnStyle dgccOrderNumber = new DataGridTextBoxColumn();
            dgccOrderNumber.Width = 120;
            dgccOrderNumber.MappingName = "cOrderNumber";
            dgccOrderNumber.HeaderText = "生产单号";
            dgts.GridColumnStyles.Add(dgccOrderNumber);


            DataGridColumnStyle dgccInvCode = new DataGridTextBoxColumn();
            dgccInvCode.Width = 60;
            dgccInvCode.MappingName = "cInvCode";
            dgccInvCode.HeaderText = "产品编码";
            dgts.GridColumnStyles.Add(dgccInvCode);

            DataGridColumnStyle dgccInvName = new DataGridTextBoxColumn();
            dgccInvName.Width = 80;
            dgccInvName.MappingName = "cInvName";
            dgccInvName.HeaderText = "产品名称";
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


            DataGridColumnStyle dgciScanQuantity = new DataGridTextBoxColumn();
            dgciScanQuantity.Width = 70;
            dgciScanQuantity.MappingName = "iScanQuantity";
            dgciScanQuantity.HeaderText = "已扫数量";
            dgts.GridColumnStyles.Add(dgciScanQuantity);



            DataGridColumnStyle dgccMemo = new DataGridTextBoxColumn();
            dgccMemo.Width = 80;
            dgccMemo.MappingName = "cMemo";
            dgccMemo.HeaderText = "备注";
            dgts.GridColumnStyles.Add(dgccMemo);



            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = rds.RmProduce;

        }

        private void SSDetail_Load(object sender, EventArgs e)
        {
            InitGrid();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            rds.RmProduce.Clear();
            var cmd = new SQLiteCommand("select id,cOrderNumber,cInvCode,cInvName,iQuantity,iScanQuantity,cMemo from RmProduce where cOrderNumber=@cOrderNumber");
            cmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(cmd, rds.RmProduce);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dGridMain_DoubleClick(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex <= -1) return;

            var cInvCode = rds.RmProduce.Rows[dGridMain.CurrentRowIndex]["cInvCode"].ToString();
            var cInvName = rds.RmProduce.Rows[dGridMain.CurrentRowIndex]["cInvName"].ToString();
            var ciQuantity = rds.RmProduce.Rows[dGridMain.CurrentRowIndex]["iQuantity"].ToString();
            var ciScanQuantity = rds.RmProduce.Rows[dGridMain.CurrentRowIndex]["iScanQuantity"].ToString();
            if (string.IsNullOrEmpty(ciScanQuantity))
            {
                ciScanQuantity = "0";
            }
            //判断是否能取得正确的数据
            decimal iQuantity, iScanQuantity;
            try
            {
                iQuantity = decimal.Parse(ciQuantity);
                iScanQuantity = decimal.Parse(ciScanQuantity);
            }
            catch (Exception)
            {
                MessageBox.Show("无法取得数量");
                return;
            }
            if (iScanQuantity >= iQuantity)
                return;


            if (MessageBox.Show(@"确定完成无批号领料?
" + cInvName, @"确定?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button3) != DialogResult.Yes) return;


            using (var pgq = new PdaGetQuantity(cInvCode, cInvName, "无批号", (iQuantity - iScanQuantity).ToString()))
            {
                if (pgq.ShowDialog() != DialogResult.Yes)
                    return;
                SaveScan("NoLot0000", cInvCode, cInvName, pgq.IQuantity, "");
            }
            
        }


        private void SaveScan(string cSerialNumber, string cInvCode, string cInvName, decimal iQuantity, string cLotNo)
        {
            var sqLiteCmd = new SQLiteCommand("insert into RmProduceDetail(cSerialNumber,cOrderNumber,cLotNo,cInvCode,cInvName,iQuantity,cUser) " +
                                              "values(@cSerialNumber,@cOrderNumber,@cLotNo,@cInvCode,@cInvName,@iQuantity,@cUser)");
            sqLiteCmd.Parameters.AddWithValue("@cSerialNumber", cSerialNumber);
            sqLiteCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            sqLiteCmd.Parameters.AddWithValue("@cLotNo", cLotNo);
            sqLiteCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            sqLiteCmd.Parameters.AddWithValue("@cInvName", cInvName);
            sqLiteCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
            sqLiteCmd.Parameters.AddWithValue("@cUser", PdaLogin.lUser);
            PDAFunction.ExecSqLite(sqLiteCmd);

            var PlusCmd = new SQLiteCommand("update RmProduce set iScanQuantity=ifnull(iScanQuantity,0)+@iQuantity where cOrderNumber=@cOrderNumber and cInvCode=@cInvCode ");
            PlusCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            PlusCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
            PlusCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            PDAFunction.ExecSqLite(PlusCmd);
            RefreshGrid();

        }
    }
}