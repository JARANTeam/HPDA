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

        var prds = new ProDataSet();
        /// <summary> 
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = prds.ProDeliveryDetail.TableName };
            DataGridColumnStyle dgcsId = new DataGridTextBoxColumn();
            dgcsId.Width = 40;
            dgcsId.MappingName = prds.ProDeliveryDetail.Columns["RowNo"].ColumnName;
            dgcsId.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgcsId);

            DataGridColumnStyle dgcBoxNumber = new DataGridTextBoxColumn();
            dgcBoxNumber.Width = 80;
            dgcBoxNumber.MappingName = prds.ProDeliveryDetail.Columns["cBoxNumber"].ColumnName;
            dgcBoxNumber.HeaderText = "箱号";
            dgts.GridColumnStyles.Add(dgcBoxNumber);

            DataGridColumnStyle dgcCKbarcode = new DataGridTextBoxColumn();
            dgcCKbarcode.Width = 130;
            dgcCKbarcode.MappingName = prds.ProDeliveryDetail.Columns["cBarCode"].ColumnName;
            dgcCKbarcode.HeaderText = "条形码";
            dgts.GridColumnStyles.Add(dgcCKbarcode);

            DataGridColumnStyle dgccLotNo = new DataGridTextBoxColumn();
            dgccLotNo.Width = 60;
            dgccLotNo.MappingName = prds.ProDeliveryDetail.Columns["cLotNo"].ColumnName;
            dgccLotNo.HeaderText = "批号";
            dgts.GridColumnStyles.Add(dgccLotNo);

            DataGridColumnStyle dgcCKinvCode = new DataGridTextBoxColumn();
            dgcCKinvCode.Width = 60;
            dgcCKinvCode.MappingName = prds.ProDeliveryDetail.Columns["cInvCode"].ColumnName;
            dgcCKinvCode.HeaderText = "产品编码";
            dgts.GridColumnStyles.Add(dgcCKinvCode);


            DataGridColumnStyle dgcCKinvName = new DataGridTextBoxColumn();
            dgcCKinvName.Width = 60;
            dgcCKinvName.MappingName = prds.ProDeliveryDetail.Columns["cInvName"].ColumnName;
            dgcCKinvName.HeaderText = "产品名称";
            dgts.GridColumnStyles.Add(dgcCKinvName);

            DataGridColumnStyle dgciQuantity = new DataGridTextBoxColumn();
            dgciQuantity.Width = 60;
            dgciQuantity.MappingName = prds.ProDeliveryDetail.Columns["iQuantity"].ColumnName;
            dgciQuantity.HeaderText = "数量";
            dgts.GridColumnStyles.Add(dgciQuantity);

            DataGridColumnStyle dgcCKoperator = new DataGridTextBoxColumn();
            dgcCKoperator.Width = 40;
            dgcCKoperator.MappingName = prds.ProDeliveryDetail.Columns["cUser"].ColumnName;
            dgcCKoperator.HeaderText = "用户";
            dgts.GridColumnStyles.Add(dgcCKoperator);



            DataGridColumnStyle dgcCKdate = new DataGridTextBoxColumn();
            dgcCKdate.Width = 60;
            dgcCKdate.MappingName = prds.ProDeliveryDetail.Columns["dAddTime"].ColumnName;
            dgcCKdate.HeaderText = "日期";
            dgts.GridColumnStyles.Add(dgcCKdate);





            DataGridColumnStyle dgcCode = new DataGridTextBoxColumn();
            dgcCode.Width = 60;
            dgcCode.MappingName = prds.ProDeliveryDetail.Columns["FSPNumber"].ColumnName;
            dgcCode.HeaderText = "库位";
            dgts.GridColumnStyles.Add(dgcCode);

            dGridMain.Controls[1].Height = 25;
            dGridMain.Controls[1].Width = 25;

            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);

            dGridMain.DataSource = prds.ProDeliveryDetail;
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
            PDAFunction.GetSqLiteTable(cmd, prds.ProDeliveryDetail);
        }

        
    }
}