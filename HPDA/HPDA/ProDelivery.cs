using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using Symbol.Barcode2;
using System.Data.SqlClient;

namespace HPDA
{
    public partial class ProDelivery : Form
    {

        ProDataSet prods = new ProDataSet();

        int _AutoID;

        /// <summary>
        /// 上传异常记录
        /// </summary>
        private int _sumException;

        /// <summary>
        /// 取得存货名称
        /// </summary>
        private string cInvName;


        /// <summary>
        /// 存货编码
        /// </summary>
        private string _cInvCode;


        public ProDelivery(string strOrderNumber, int AutoID)
        {
            InitializeComponent();
            lblOrderNumber.Text = strOrderNumber;
            _AutoID = AutoID;
        }


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





            DataGridColumnStyle dgcCode = new DataGridTextBoxColumn();
            dgcCode.Width = 60;
            dgcCode.MappingName = prods.ProDeliveryDetail.Columns["FSPNumber"].ColumnName;
            dgcCode.HeaderText = "库位";
            dgts.GridColumnStyles.Add(dgcCode);

            dGridMain.Controls[1].Height = 25;
            dGridMain.Controls[1].Width = 25;

            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);

            dGridMain.DataSource = prods.ProDeliveryDetail;
        }

        private void ProDelivery_Load(object sender, EventArgs e)
        {
            mBc2.EnableScanner = true;
            mBc2.Config.ScanDataSize = 200;
            InitGrid();
            RefreshGrid();
        }

        private void ProDelivery_Closing(object sender, CancelEventArgs e)
        {
            mBc2.EnableScanner = false;
        }


        private void RefreshGrid()
        {
            //重新取出所有的数据
            prods.ProDeliveryDetail.Rows.Clear();
            prods.ProDeliveryDetail.Columns.Remove("RowNo");
            DataColumn cAutoID = new DataColumn("RowNo", typeof(Int32));
            cAutoID.AutoIncrement = true;
            cAutoID.AutoIncrementSeed = 1;
            cAutoID.AutoIncrementStep = 1;
            prods.ProDeliveryDetail.Columns.Add(cAutoID);


            var cmd = new SQLiteCommand("select * from ProDeliveryDetail where cCode=@cCode");
            cmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(cmd, prods.ProDeliveryDetail);
        }

        private void mBc2_OnScan(Symbol.Barcode2.ScanDataCollection scanDataCollection)
        {
            ScanData sData = scanDataCollection.GetFirst;
            var str = sData.Text;
            var sType = sData.Type.ToString();
            byte[] by = Encoding.Default.GetBytes(str);
            string sText = Encoding.GetEncoding(65001).GetString(by, 0, by.Length);

            try
            {
                scan_OnDecodeEvent(sText);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// 扫描响应事件
        /// </summary>
        /// <param name="DecodeText">扫描到的条码内容</param>
        private void scan_OnDecodeEvent(string DecodeText)
        {

            var cBarCode = DecodeText;
            if (string.IsNullOrEmpty(lblStockPlaceID.Text))
            {
                var cmd = new SqlCommand("select * from t_StockPlace where FNumber=@FNumber");
                cmd.Parameters.AddWithValue("@FNumber", cBarCode);

                if (PDAFunction.ExistSqlKis(cmd))
                {
                    lblStockPlaceID.Text = cBarCode;
                }
                else
                {
                    MessageBox.Show("请先扫描库位", "Error");
                }
                return;
            }

            if ((!cBarCode.StartsWith("P*") || !cBarCode.Contains("*L*") || !cBarCode.Contains("*S*")))
            {
                MessageBox.Show("无效条码", "Error");
                return;
            }

            cBarCode = cBarCode.Substring(cBarCode.IndexOf("*S*") + 3, 16);
            if (!JudgeBarCode(cBarCode))
                return;


            //if (!cBarCode.StartsWith("R*") || !cBarCode.Contains("*L*") || !cBarCode.Contains("*S*"))
            //{
            //    MessageBox.Show("无效条码", "Error");
            //    return;
            //}
            ////物料编码
            //var FitemID = cBarCode.Substring(2, cBarCode.IndexOf("*L*") - 2);
            ////产品序列号
            //var cLotNo = cBarCode.Substring(cBarCode.IndexOf("*L*") + 3, cBarCode.IndexOf("*S*") - cBarCode.IndexOf("*L*") - 3);

            ////产品批号
            //var cSerialNumber = cBarCode.Substring(cBarCode.IndexOf("*S*") + 3, cBarCode.Length - cBarCode.IndexOf("*S*") - 3);


            var cmdGetQuantity = new SqlCommand("select * from View_ProductLabel where cBarCode=@cBarCode");
            cmdGetQuantity.Parameters.AddWithValue("@cBarCode", cBarCode);

            decimal iQuantity = 0;
            string cLotNo = "";
            int FitemID = 1;
            var dtTemp = PDAFunction.GetSqlTable(cmdGetQuantity);
            if (dtTemp == null || dtTemp.Rows.Count < 1)
            {
                MessageBox.Show("无效条码，无打印记录", "Error");
                return;
            }
            try
            {
                iQuantity = decimal.Parse(dtTemp.Rows[0]["iQuantity"].ToString());
                cLotNo = dtTemp.Rows[0]["FBatchNo"].ToString();
                FitemID = int.Parse(dtTemp.Rows[0]["cFitemID"].ToString());
                _cInvCode = dtTemp.Rows[0]["cInvCode"].ToString();
                cInvName = dtTemp.Rows[0]["cInvName"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据异常，" + ex.Message, "Error");
                return;
            }

            SaveOutWareHouse(cBarCode, _cInvCode, cInvName, iQuantity, cLotNo, FitemID);




        }

        /// <summary>
        /// 判断出库的条码是否已经出库
        /// </summary>
        /// <param name="cInvCode"></param>
        /// <returns></returns>
        private bool JudgeBarCode(string cBarCode)
        {
            var bOutAllCmd = new SQLiteCommand("select * from ProDeliveryDetail where cBarCode=@cBarCode");
            bOutAllCmd.Parameters.AddWithValue("@cBarCode", cBarCode);
            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, bOutAllCmd))
            {
                MessageBox.Show(@"该包产品已经出库！");
                return false;
            }
            return true;
        }


        /// <summary>
        /// 保存出库扫描,并重新进入出库单号的扫描获取
        /// </summary>
        private void SaveOutWareHouse(string cBarCode, string cInvCode, string cInvName, decimal iQuantity, string cLotNo, int FitemID)
        {


            var sqLiteCmd = new SQLiteCommand("insert into ProDeliveryDetail(AutoID,cCode,cBarCode,cLotNo,FItemID,cInvCode,cInvName,iQuantity,cUser,cBoxNumber,FSPNumber) " +
                                      "values(@AutoID,@cCode,@cBarCode,@cLotNo,@FItemID,@cInvCode,@cInvName,@iQuantity,@cUser,@cBoxNumber,@FSPNumber)");
            sqLiteCmd.Parameters.AddWithValue("@AutoID", _AutoID);
            sqLiteCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            sqLiteCmd.Parameters.AddWithValue("@cBarCode", cBarCode);

            sqLiteCmd.Parameters.AddWithValue("@cLotNo", cLotNo);
            sqLiteCmd.Parameters.AddWithValue("@FitemID", FitemID);
            sqLiteCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            sqLiteCmd.Parameters.AddWithValue("@cInvName", cInvName);
            sqLiteCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
            sqLiteCmd.Parameters.AddWithValue("@cUser", frmLogin.lUser);
            sqLiteCmd.Parameters.AddWithValue("@cBoxNumber", "");

            sqLiteCmd.Parameters.AddWithValue("@FSPNumber", lblStockPlaceID.Text);

            PDAFunction.ExecSqLite(sqLiteCmd);

            txtBarCode.Text = "";
            txtBarCode.Focus();
            RefreshGrid();

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            _sumException = 0;
            if (!PDAFunction.IsCanCon())
            {
                MessageBox.Show(@"无法连接到SQL服务器,无法上传", @"Warning");
                return;
            }

            if (prods.ProDeliveryDetail.Rows.Count <= 0)
            {
                MessageBox.Show(@"无任何数据!", @"Warning");
                return;
            }
            btnComplete.Enabled = false;

            var cGuid = Guid.NewGuid().ToString();

            if (!UpLoadDetail(cGuid))
            {
                MessageBox.Show(@"无法连接到SQL服务器,请重试!", @"Warning");
                RefreshGrid();
                btnComplete.Enabled = true;
                return;
                //成功后,删除离线出库通知单数据
            }

            if (_sumException == 0)
            {
                MessageBox.Show(@"全部上传成功!", @"Success");
                var dCmd = new SQLiteCommand("Delete from ProDelivery where cCode=@cCode");
                dCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
                PDAFunction.ExecSqLite(dCmd);
                Close();
                return;
            }
            else
            {
                MessageBox.Show(@"上传成功,但是有" + _sumException + @"条记录异常,请检查异常日志!", @"Success");
            }
            RefreshGrid();
        }


        /// <summary>
        /// 执行导入SQL服务器操作
        /// </summary>
        /// <param name="iRowId">把当前行行入库</param>
        /// <param name="cGuid">当前Guid</param>
        private bool UpLoadDetail(string cGuid)
        {
            using (var con = new SqlConnection(frmLogin.WmsCon))
            {
                con.Open();
                var tran = con.BeginTransaction();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Upload_ProDeliveryDetail";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;
                    for (var i = 0; i <= prods.ProDeliveryDetail.Rows.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();
                        dGridMain.CurrentRowIndex = i;
                        cmd.Parameters.AddWithValue("@cGuid", cGuid);
                        cmd.Parameters.AddWithValue("@ID", prods.ProDeliveryDetail.Rows[i]["AutoID"]);
                        cmd.Parameters.AddWithValue("@FItemID", prods.ProDeliveryDetail.Rows[i]["FItemID"]);
                        cmd.Parameters.AddWithValue("@cBarCode", prods.ProDeliveryDetail.Rows[i]["cBarCode"]);
                        cmd.Parameters.AddWithValue("@cCode", prods.ProDeliveryDetail.Rows[i]["cCode"]);
                        cmd.Parameters.AddWithValue("@cLotNo", prods.ProDeliveryDetail.Rows[i]["cLotNo"]);
                        cmd.Parameters.AddWithValue("@cInvCode", prods.ProDeliveryDetail.Rows[i]["cInvCode"]);
                        cmd.Parameters.AddWithValue("@cInvName", prods.ProDeliveryDetail.Rows[i]["cInvName"]);
                        cmd.Parameters.AddWithValue("@iQuantity", prods.ProDeliveryDetail.Rows[i]["iQuantity"]);
                        cmd.Parameters.AddWithValue("@FSPNumber", prods.ProDeliveryDetail.Rows[i]["FSPNumber"]);
                        cmd.Parameters.AddWithValue("@dScanTime", prods.ProDeliveryDetail.Rows[i]["dAddTime"]);
                        cmd.Parameters.AddWithValue("@cBoxNumber", prods.ProDeliveryDetail.Rows[i]["cBoxNumber"]);
                        cmd.Parameters.AddWithValue("@cOperator", prods.ProDeliveryDetail.Rows[i]["cUser"]);
                        cmd.Parameters.AddWithValue("@cMemo", "");

                        try
                        {

                            var iTem = cmd.ExecuteNonQuery();


                        }

                        catch (Exception ex)
                        {
                            _sumException += 1;
                            tran.Rollback();
                            MessageBox.Show(@"无法连接到SQL服务器,请重试!
" + ex.Message, @"Warning");
                            return false;
                        }
                    }
                    try
                    {
                        cmd.CommandText = "AddMidOrder";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@cGuid", cGuid);
                        cmd.Parameters.AddWithValue("@cType", "销售出库");
                        cmd.Parameters.AddWithValue("@cTable", "ProDeliveryDetail");
                        cmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
                        cmd.ExecuteNonQuery();

                        tran.Commit();
                        
                        var dSqliteCmd = new SQLiteCommand("Delete from ProDeliveryDetail where cCode=@cCode");
                        //成功后,删除离线出库数据中的表
                        dSqliteCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
                        PDAFunction.ExecSqLite(dSqliteCmd);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"无法连接到SQL服务器,请重试!
" + ex.Message, @"Warning");
                        return false;
                    }
                }
            }
        }

        private void dGridMain_DoubleClick(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex <= -1) return;
            //if (!PDAFunction.IsCanCon())
            //{
            //    MessageBox.Show("无法连接到服务器");
            //}
            if (MessageBox.Show(@"确定删除当前行?", @"确定删除?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button3) != DialogResult.Yes) return;
            var sqLiteCmd = new SQLiteCommand("Delete From ProDeliveryDetail where id=@id");
            sqLiteCmd.Parameters.AddWithValue("@id", prods.ProDeliveryDetail.Rows[dGridMain.CurrentRowIndex]["id"]);
            //执行删除
            PDAFunction.ExecSqLite(sqLiteCmd);

            RefreshGrid();
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            if (dGridMain.CurrentRowIndex < 0)
                return;
            var rpd = new ProDeliveryDetail(lblOrderNumber.Text);
            rpd.ShowDialog();
        }


    }
}