using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace HPDA
{
    public partial class ProDeliverySelect : Form
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


            DataGridColumnStyle dgAutoID = new DataGridTextBoxColumn();
            dgAutoID.Width = 40;
            dgAutoID.MappingName = "RowNo";
            dgAutoID.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgAutoID);

            DataGridColumnStyle dgccOrderNumber = new DataGridTextBoxColumn();
            dgccOrderNumber.Width = 120;
            dgccOrderNumber.MappingName = "cOrderNumber";
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

        public ProDeliverySelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取波次单号
        /// </summary>
        private void LoaProDelivery()
        {
            var sqLiteCmd = new SQLiteCommand("select * from ProDelivery ");
            prods.ProDelivery.Rows.Clear();
            PDAFunction.GetSqLiteTable(sqLiteCmd, prods.ProDelivery);
        }

        private void ProDeliverySelect_Load(object sender, EventArgs e)
        {
            InitGrid();
            LoaProDelivery();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex < 0)
                return;
            if (MessageBox.Show(@"确定删除当前下载的采购订单?", @"确定删除?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;
            var cmd = new SQLiteCommand("select * from RmStoreDetail where cOrderNumber=@cOrderNumber");
            cmd.Parameters.AddWithValue("@cOrderNumber", prods.ProDelivery.Rows[dGridMain.CurrentRowIndex]["cOrderNumber"]);
            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, cmd))
            {
                MessageBox.Show(@"当前采购订单已经进行过入库,不允许删除!", @"Warning");
                return;
            }

            //if (!PDAFunction.IsCanCon())
            //{
            //    MessageBox.Show(@"无法连接到服务器", @"Warning");
            //    return;
            //}
            var dCmd = new SQLiteCommand("Delete from ProDelivery where cOrderNumber=@cOrderNumber");
            dCmd.Parameters.AddWithValue("@cOrderNumber", prods.ProDelivery.Rows[dGridMain.CurrentRowIndex]["cOrderNumber"]);
            PDAFunction.ExecSqLite(dCmd);


            MessageBox.Show(@"删除成功", @"Success");
            LoaProDelivery();
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
             if (dGridMain.CurrentRowIndex < 0)
                return;
            var rpd = new RmPoStoreDetail(rds.RmPo.Rows[dGridMain.CurrentRowIndex]["cOrderNumber"].ToString());
            rpd.ShowDialog();
        }

    }
}