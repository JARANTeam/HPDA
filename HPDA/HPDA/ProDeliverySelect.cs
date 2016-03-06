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
            dgccOrderNumber.MappingName = "cCode";
            dgccOrderNumber.HeaderText = "单号";
            dgts.GridColumnStyles.Add(dgccOrderNumber);


            DataGridColumnStyle dgccCusName = new DataGridTextBoxColumn();
            dgccCusName.Width = 120;
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
            dgts.GridColumnStyles.Add(dgccDepName);

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
            var sqLiteCmd = new SQLiteCommand("select AutoID,cCode,cCusName,cMaker,cDepName,cMemo,cVerifyState from ProDelivery ");
            prods.ProDelivery.Rows.Clear();
            PDAFunction.GetSqLiteTable(sqLiteCmd, prods.ProDelivery);
        }

        private void ProDeliverySelect_Load(object sender, EventArgs e)
        {
            InitGrid();
            try
            {
                LoaProDelivery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex < 0)
                return;
            if (MessageBox.Show(@"确定删除当前下载的采购订单?", @"确定删除?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;
            var cmd = new SQLiteCommand("select * from ProDeliveryDetail where cCode=@cCode");
            cmd.Parameters.AddWithValue("@cCode", prods.ProDelivery.Rows[dGridMain.CurrentRowIndex]["cCode"]);
            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, cmd))
            {
                MessageBox.Show(@"当前出库单已经进行过出库扫描,不允许删除!", @"Warning");
                return;
            }

            //if (!PDAFunction.IsCanCon())
            //{
            //    MessageBox.Show(@"无法连接到服务器", @"Warning");
            //    return;
            //}
            var dCmd = new SQLiteCommand("Delete from ProDelivery where cCode=@cCode");
            dCmd.Parameters.AddWithValue("@cCode", prods.ProDelivery.Rows[dGridMain.CurrentRowIndex]["cCode"]);
            PDAFunction.ExecSqLite(dCmd);


            MessageBox.Show(@"删除成功", @"Success");
            LoaProDelivery();
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
             if (dGridMain.CurrentRowIndex < 0)
                return;
             var rpd = new ProDeliveryDetail(prods.ProDelivery.Rows[dGridMain.CurrentRowIndex]["cCode"].ToString());
            rpd.ShowDialog();
        }

        private void dGridMain_DoubleClick(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex < 0)
                return;

            int iAutoID;
            try 
	        {	        
		        iAutoID=int.Parse(prods.ProDelivery.Rows[dGridMain.CurrentRowIndex]["AutoID"].ToString());
	        }
	        catch (Exception ex)
	        {
        		
		        MessageBox.Show(@"数据异常"+ex.Message, @"Warning");
                return;
	        }
            var outWareHouse = new ProDelivery(prods.ProDelivery.Rows[dGridMain.CurrentRowIndex]["cCode"].ToString(), iAutoID);
            outWareHouse.ShowDialog();
            Close();
        }

    }
}