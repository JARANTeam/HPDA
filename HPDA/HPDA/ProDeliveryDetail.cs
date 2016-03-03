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
    public partial class ProDeliveryDetail : Form
    {

        ProDataSet prods = new ProDataSet();

        /// <summary> 
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = prods.ProDeliveryDetail.TableName };
            DataGridColumnStyle dgcsId = new DataGridTextBoxColumn();
            dgcsId.Width = 40;
            dgcsId.MappingName = prods.ProDeliveryDetail.Columns["RowNo"].ColumnName;
            dgcsId.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgcsId);

            DataGridColumnStyle dgcCKbarcode = new DataGridTextBoxColumn();
            dgcCKbarcode.Width = 130;
            dgcCKbarcode.MappingName = prods.ProDeliveryDetail.Columns["cBarCode"].ColumnName;
            dgcCKbarcode.HeaderText = "条形码";
            dgts.GridColumnStyles.Add(dgcCKbarcode);

            DataGridColumnStyle dgccLotNo = new DataGridTextBoxColumn();
            dgccLotNo.Width = 60;
            dgccLotNo.MappingName = prods.ProDeliveryDetail.Columns["cLotNo"].ColumnName;
            dgccLotNo.HeaderText = "批号";
            dgts.GridColumnStyles.Add(dgccLotNo);

            DataGridColumnStyle dgcCKinvCode = new DataGridTextBoxColumn();
            dgcCKinvCode.Width = 60;
            dgcCKinvCode.MappingName = prods.ProDeliveryDetail.Columns["cInvCode"].ColumnName;
            dgcCKinvCode.HeaderText = "产品编码";
            dgts.GridColumnStyles.Add(dgcCKinvCode);


            DataGridColumnStyle dgcCKinvName = new DataGridTextBoxColumn();
            dgcCKinvName.Width = 60;
            dgcCKinvName.MappingName = prods.ProDeliveryDetail.Columns["cInvName"].ColumnName;
            dgcCKinvName.HeaderText = "产品名称";
            dgts.GridColumnStyles.Add(dgcCKinvName);

            DataGridColumnStyle dgciQuantity = new DataGridTextBoxColumn();
            dgciQuantity.Width = 60;
            dgciQuantity.MappingName = prods.ProDeliveryDetail.Columns["iQuantity"].ColumnName;
            dgciQuantity.HeaderText = "数量";
            dgts.GridColumnStyles.Add(dgciQuantity);

            DataGridColumnStyle dgcCKoperator = new DataGridTextBoxColumn();
            dgcCKoperator.Width = 40;
            dgcCKoperator.MappingName = prods.ProDeliveryDetail.Columns["cUser"].ColumnName;
            dgcCKoperator.HeaderText = "用户";
            dgts.GridColumnStyles.Add(dgcCKoperator);



            DataGridColumnStyle dgcCKdate = new DataGridTextBoxColumn();
            dgcCKdate.Width = 60;
            dgcCKdate.MappingName = prods.ProDeliveryDetail.Columns["dAddTime"].ColumnName;
            dgcCKdate.HeaderText = "日期";
            dgts.GridColumnStyles.Add(dgcCKdate);





            DataGridColumnStyle dgcFspNumber = new DataGridTextBoxColumn();
            dgcFspNumber.Width = 60;
            dgcFspNumber.MappingName = prods.ProDeliveryDetail.Columns["FSPNumber"].ColumnName;
            dgcFspNumber.HeaderText = "库位";
            dgts.GridColumnStyles.Add(dgcFspNumber);

            dGridMain.Controls[1].Height = 25;
            dGridMain.Controls[1].Width = 25;

            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);

            dGridMain.DataSource = prods.ProDeliveryDetail;
        }

        public ProDeliveryDetail(string strOrderNumber)
        {
            InitializeComponent();
            lblOrderNumber.Text = strOrderNumber;
        }

        private void ProDeliveryDetail_Load(object sender, EventArgs e)
        {
            InitGrid();
            var cmd = new SQLiteCommand("select * from ProDeliveryDetail where cCode=@cCode");
            cmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(cmd, prods.ProDeliveryDetail);
        }

        
    }
}