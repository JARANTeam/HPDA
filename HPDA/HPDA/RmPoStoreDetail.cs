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
    public partial class RmPoStoreDetail : Form
    {

        /// <summary>
        /// 销售模块的数据架构集
        /// </summary>
        private RmDataSet rds = new RmDataSet();

        public RmPoStoreDetail(string cOrderNumber)
        {
            InitializeComponent();
            lblOrderNumber.Text = cOrderNumber;
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

            DataGridColumnStyle dgccVendor = new DataGridTextBoxColumn();
            dgccVendor.Width = 80;
            dgccVendor.MappingName = "cVendor";
            dgccVendor.HeaderText = "供应商";
            dgts.GridColumnStyles.Add(dgccVendor);


            DataGridColumnStyle dgccMemo = new DataGridTextBoxColumn();
            dgccMemo.Width = 80;
            dgccMemo.MappingName = "cMemo";
            dgccMemo.HeaderText = "备注";
            dgts.GridColumnStyles.Add(dgccMemo);



            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = rds.RmPo;

        }

        private void dGridMain_DoubleClick(object sender, EventArgs e)
        {

        }

        private void RefreshGrid()
        {
            rds.RmPo.Clear();
            var cmd = new SQLiteCommand("select * from RmPo where cOrderNumber=@cOrderNumber");
            cmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(cmd, rds.RmPo);
        }

        private void RmPoStoreDetail_Load(object sender, EventArgs e)
        {
            InitGrid();
            RefreshGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}