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
    public partial class RmProduceSelect : Form
    {


        /// <summary>
        /// 原料模块的数据架构集
        /// </summary>
        private RmDataSet rds = new RmDataSet();
        public RmProduceSelect()
        {
            InitializeComponent();
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


            DataGridColumnStyle dgcMemo = new DataGridTextBoxColumn();
            dgcMemo.Width = 70;
            dgcMemo.MappingName = "cMemo";
            dgcMemo.HeaderText = "备注";
            dgts.GridColumnStyles.Add(dgcMemo);

            DataGridColumnStyle dgcdLoadDate = new DataGridTextBoxColumn();
            dgcdLoadDate.Width = 100;
            dgcdLoadDate.MappingName = "dLoadDate";
            dgcdLoadDate.HeaderText = "下载时间";
            dgts.GridColumnStyles.Add(dgcdLoadDate);
            //dgccUnit.Width = 60;
            //dgccUnit.MappingName = "cUnit";
            //dgccUnit.HeaderText = "单位";
            //dgts.GridColumnStyles.Add(dgccUnit);

            DataGridColumnStyle dgciQuantity = new DataGridTextBoxColumn();
            dgciQuantity.Width = 70;
            dgciQuantity.MappingName = "iQuantity";
            dgciQuantity.HeaderText = "总数";
            dgts.GridColumnStyles.Add(dgciQuantity);


            


            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = rds.RmProduce;

        }

        private void SFSelect_Load(object sender, EventArgs e)
        {
            InitGrid();
            LoaRmProduce();
        }


        /// <summary>
        /// 获取波次单号
        /// </summary>
        private void LoaRmProduce()
        {
            var sqLiteCmd = new SQLiteCommand("select cOrderNumber,max(dLoadDate) dLoadDate,sum(iQuantity) iQuantity,max(cMemo) cMemo from RmProduce group by cOrderNumber");
            rds.RmProduce.Rows.Clear();
            PDAFunction.GetSqLiteTable(sqLiteCmd, rds.RmProduce);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex < 0)
                return;
            if (MessageBox.Show(@"确定删除当前下载的生产订单?", @"确定删除?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;
            var cmd = new SQLiteCommand("select * from RmProduceDetail where cOrderNumber=@cOrderNumber");
            cmd.Parameters.AddWithValue("@cOrderNumber", rds.RmProduce.Rows[dGridMain.CurrentRowIndex]["cOrderNumber"]);
            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, cmd))
            {
                MessageBox.Show(@"当前生产订单已经进行过领料,不允许删除!", @"Warning");
                return;
            }

            //if (!PDAFunction.IsCanCon())
            //{
            //    MessageBox.Show(@"无法连接到服务器", @"Warning");
            //    return;
            //}
            var dCmd = new SQLiteCommand("Delete from RmProduce where cOrderNumber=@cOrderNumber");
            dCmd.Parameters.AddWithValue("@cOrderNumber", rds.RmProduce.Rows[dGridMain.CurrentRowIndex]["cOrderNumber"]);
            PDAFunction.ExecSqLite(dCmd);


            MessageBox.Show(@"删除成功", @"Success");
            LoaRmProduce();
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex < 0)
                return;
            var rpd = new RmProduceDetail(rds.RmProduce.Rows[dGridMain.CurrentRowIndex]["cOrderNumber"].ToString());
            rpd.ShowDialog();
        }

        private void dGridMain_DoubleClick(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex < 0)
                return;
            var rps = new RmProduce(rds.RmProduce.Rows[dGridMain.CurrentRowIndex]["cOrderNumber"].ToString());
            rps.ShowDialog();
            Close();
        }

    }
}