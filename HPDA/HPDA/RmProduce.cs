using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using Symbol.Barcode2;

namespace HPDA
{
    public partial class RmProduce : Form
    {
        /// <summary>
        /// 销售模块的数据架构集
        /// </summary>
        private RmDataSet rds = new RmDataSet();

        /// <summary>
        /// 上传异常记录
        /// </summary>
        private int _sumException;

        /// <summary>
        /// 取得存货名称
        /// </summary>
        private string cInvName;

        private string ShiftID;

        /// <summary>
        /// 存货编码
        /// </summary>
        private string _cInvCode;


        public RmProduce(string cCode)
        {
            InitializeComponent();
            lblOrderNumber.Text = cCode;
        }
        /// <summary>
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = rds.RmProduceDetail.TableName };


            DataGridColumnStyle dgAutoID = new DataGridTextBoxColumn();
            dgAutoID.Width = 40;
            dgAutoID.MappingName = "RowNo";
            dgAutoID.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgAutoID);

            DataGridColumnStyle dgccCode = new DataGridTextBoxColumn();
            dgccCode.Width = 120;
            dgccCode.MappingName = "cLotNo";
            dgccCode.HeaderText = "批号";
            dgts.GridColumnStyles.Add(dgccCode);


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

            DataGridColumnStyle dgcCode = new DataGridTextBoxColumn();
            dgcCode.Width = 60;
            dgcCode.MappingName = "FSPNumber";
            dgcCode.HeaderText = "库位";
            dgts.GridColumnStyles.Add(dgcCode);


            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = rds.RmProduceDetail;

        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            var rpd = new RmProduceDetail(lblOrderNumber.Text);
            rpd.ShowDialog();
            RefreshGrid();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            scan_OnDecodeEvent(txtBarCode.Text);
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


            if (!cBarCode.StartsWith("R*") || !cBarCode.Contains("*L*") || !cBarCode.Contains("*S*"))
            {
                MessageBox.Show("无效条码", "Error");
                return;
            }
            //物料编码
            var FItemID = cBarCode.Substring(2, cBarCode.IndexOf("*L*") - 2);
            //产品序列号
            var cLotNo = cBarCode.Substring(cBarCode.IndexOf("*L*") + 3, cBarCode.IndexOf("*S*") - cBarCode.IndexOf("*L*") - 3);

            //产品批号
            var cSerialNumber = cBarCode.Substring(cBarCode.IndexOf("*S*") + 3, cBarCode.Length - cBarCode.IndexOf("*S*") - 3);

            ////判断该产品序列号是否已经被扫描
            //if (!JudgeBarCode(cSerialNumber))
            //    return;

            //判断波次订单中是否存在此出库要求产品
            if (!JudgeInvCode(FItemID))
                return;

            //判断要拣货的产品是否已经全部拣完
            if (!OutAll(FItemID))
                return;

            using (var pgq = new PdaGetQuantity(_cInvCode, cInvName, cLotNo))
            {
                if (pgq.ShowDialog() != DialogResult.Yes)
                    return;
                //通过校验后进
                SaveOutWareHouse(cSerialNumber, _cInvCode, cInvName, pgq.IQuantity, cLotNo, FItemID);
            }
            lblStockPlaceID.Text = "";

            
        }


        /// <summary>
        /// 保存出库扫描,并重新进入出库单号的扫描获取
        /// </summary>
        private void SaveOutWareHouse(string cSerialNumber, string cInvCode, string cInvName, decimal iQuantity, string cLotNo, string FItemID)
        {
            var sqLiteCmd = new SQLiteCommand("insert into RmProduceDetail(cBarCode,cCode,cLotNo,cInvCode,cInvName,iQuantity,cUser,FItemID,FSPNumber,AutoID) " +
                                              "values(@cBarCode,@cCode,@cLotNo,@cInvCode,@cInvName,@iQuantity,@cUser,@FItemID,@FSPNumber,@AutoID)");
            sqLiteCmd.Parameters.AddWithValue("@cBarCode", cSerialNumber);
            sqLiteCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            sqLiteCmd.Parameters.AddWithValue("@cLotNo", cLotNo);
            sqLiteCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            sqLiteCmd.Parameters.AddWithValue("@cInvName", cInvName);
            sqLiteCmd.Parameters.AddWithValue("@iQuantity", iQuantity);

            sqLiteCmd.Parameters.AddWithValue("@cUser", frmLogin.lUser);

            sqLiteCmd.Parameters.AddWithValue("@FItemID", FItemID);
            sqLiteCmd.Parameters.AddWithValue("@FSPNumber", lblStockPlaceID.Text);
            sqLiteCmd.Parameters.AddWithValue("@AutoID", ShiftID);
            PDAFunction.ExecSqLite(sqLiteCmd);

            var PlusCmd = new SQLiteCommand("update RmProduce set iScanQuantity=ifnull(iScanQuantity,0)+@iQuantity where cCode=@cCode and FItemID=@FItemID ");
            PlusCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            PlusCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
            PlusCmd.Parameters.AddWithValue("@FItemID", FItemID);
            PDAFunction.ExecSqLite(PlusCmd);
            txtBarCode.Text = "";
            txtBarCode.Focus();
            RefreshGrid();

        }


        private void RefreshGrid()
        {
            //重新取出所有的数据
            rds.RmProduceDetail.Rows.Clear();
            rds.RmProduceDetail.Columns.Remove("RowNo");
            DataColumn cAutoID = new DataColumn("RowNo", typeof(Int32));
            cAutoID.AutoIncrement = true;
            cAutoID.AutoIncrementSeed = 1;
            cAutoID.AutoIncrementStep = 1;
            rds.RmProduceDetail.Columns.Add(cAutoID);


            var selectCmd = new SQLiteCommand("select * from RmProduceDetail where cCode=@cCode order by id desc");
            selectCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(selectCmd, rds.RmProduceDetail);

            if (rds.RmProduceDetail.Rows.Count >= 1)
                dGridMain.CurrentRowIndex = 0;

            var selectSumCmd = new SQLiteCommand("select sum(iQuantity) from RmProduceDetail where cCode=@cCode");
            selectSumCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            lblSum.Text = PDAFunction.GetScalreExecSqLite(selectSumCmd);

            var bOutAllCmd = new SQLiteCommand("select * from RmProduce where cCode=@cCode and ifnull(iScanQuantity,0)<ifnull(iQuantity,0)");
            bOutAllCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);

            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, bOutAllCmd))

            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, bOutAllCmd))

            {
                lblOutAll.Text = "未完成";
            }
            else
            {
                lblOutAll.Text = "完成";
            }
        }

        ///// <summary>
        ///// 判断出库产品的序列号是否已经出库
        ///// </summary>
        ///// <param name="cInvCode"></param>
        ///// <returns></returns>
        //private bool JudgeBarCode(string cSerialNumber)
        //{
        //    var bDeliveryCmd = new SQLiteCommand("select * from RmProduceDetail where cSerialNumber=@cSerialNumber");
        //    bDeliveryCmd.Parameters.AddWithValue("@cSerialNumber", cSerialNumber);
        //    if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, bDeliveryCmd))
        //    if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, bDeliveryCmd))
        //    {
        //        MessageBox.Show(@"该产品已经扫描！");
        //        return false;
        //    }
        //    return true;
        //}



        /// <summary>
        /// 判断出库的产品是否包含在出库单中
        /// </summary>
        /// <param name="cInvCode"></param>
        /// <returns></returns>
        private bool JudgeInvCode(string FItemID)
        {
            var bOutAllCmd = new SQLiteCommand("select AutoID,cInvCode,cInvName from RmProduce where cCode=@cCode and FItemID=@FItemID");
            bOutAllCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            bOutAllCmd.Parameters.AddWithValue("@FItemID", FItemID);
            var dt=PDAFunction.GetSqLiteTable(bOutAllCmd);
            if (dt==null||dt.Rows.Count<1)
            {
                MessageBox.Show(@"该生产订单不包含此产品！");
                return false;

            }
            cInvName = dt.Rows[0]["cInvName"].ToString();
            _cInvCode = dt.Rows[0]["cInvCode"].ToString();
            ShiftID = dt.Rows[0]["AutoID"].ToString();
            return true;
        }


        /// <summary>
        /// 判断该产品的批号是否全部出完
        /// </summary>
        /// <param name="cInvCode"></param>
        /// <returns></returns>
        private bool OutAll(string FItemID)
        {
            var bOutAllCmd = new SQLiteCommand("select * from RmProduce where FItemID=@FItemID and iScanQuantity<iQuantity and cCode=@cCode");
            bOutAllCmd.Parameters.AddWithValue("@FItemID", FItemID);
            bOutAllCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);

            if (!PDAFunction.ExistSqlite(frmLogin.SqliteCon, bOutAllCmd))

            if (!PDAFunction.ExistSqlite(frmLogin.SqliteCon, bOutAllCmd))

            {
                MessageBox.Show(@"该产品已经领料完成");
                return false;

            }
            return true;
        }


        private void RmPo_Load(object sender, EventArgs e)
        {
            InitGrid();
            
        }

        private void RmPo_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show(@"确定关闭?", @"是/否?", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) !=
                            DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }


        private void btnComplete_Click(object sender, EventArgs e)
        {
            _sumException=0;
            if (!PDAFunction.IsCanCon())
            {
                MessageBox.Show(@"无法连接到SQL服务器,无法上传", @"Warning");
                return;
            }

            if (rds.RmProduceDetail.Rows.Count <= 0)
            {
                MessageBox.Show(@"无任何数据!", @"Warning");
                return;
            }

            if (lblOutAll.Text.Equals("未完成"))
            {
                if (MessageBox.Show("领料未完成，是否确定要上传", "是否", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    return;
                }
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
                var dCmd = new SQLiteCommand("Delete from RmProduce where cCode=@cCode");
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
                    cmd.CommandText = "Upload_RmProduceDetail";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tran;
                    for (var i = 0; i <= rds.RmProduceDetail.Rows.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();
                        dGridMain.CurrentRowIndex = i;
                        cmd.Parameters.AddWithValue("@cGuid", cGuid);
                        cmd.Parameters.AddWithValue("@ID", rds.RmProduceDetail.Rows[i]["AutoID"]);
                        cmd.Parameters.AddWithValue("@FItemID", rds.RmProduceDetail.Rows[i]["FItemID"]);
                        cmd.Parameters.AddWithValue("@cBarCode", rds.RmProduceDetail.Rows[i]["cBarCode"]);
                        cmd.Parameters.AddWithValue("@cCode", rds.RmProduceDetail.Rows[i]["cCode"]);
                        cmd.Parameters.AddWithValue("@cLotNo", rds.RmProduceDetail.Rows[i]["cLotNo"]);
                        cmd.Parameters.AddWithValue("@cInvCode", rds.RmProduceDetail.Rows[i]["cInvCode"]);
                        cmd.Parameters.AddWithValue("@cInvName", rds.RmProduceDetail.Rows[i]["cInvName"]);
                        cmd.Parameters.AddWithValue("@iQuantity", rds.RmProduceDetail.Rows[i]["iQuantity"]);
                        cmd.Parameters.AddWithValue("@FSPNumber", rds.RmProduceDetail.Rows[i]["FSPNumber"]);
                        cmd.Parameters.AddWithValue("@dScanTime", rds.RmProduceDetail.Rows[i]["dAddTime"]);
                        cmd.Parameters.AddWithValue("@cBoxNumber", rds.RmProduceDetail.Rows[i]["cBoxNumber"]);
                        cmd.Parameters.AddWithValue("@cOperator", rds.RmProduceDetail.Rows[i]["cUser"]);
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
                        cmd.Parameters.AddWithValue("@cType", "领料出库");
                        cmd.Parameters.AddWithValue("@cTable", "Rm_ProduceDetail");
                        cmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
                        cmd.ExecuteNonQuery();

                        tran.Commit();

                        var dSqliteCmd = new SQLiteCommand("Delete from RmProduceDetail where cCode=@cCode");
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
            var sqLiteCmd = new SQLiteCommand("Delete From RmProduceDetail where id=@id");
            sqLiteCmd.Parameters.AddWithValue("@id", rds.RmProduceDetail.Rows[dGridMain.CurrentRowIndex]["id"]);
            //执行删除
            PDAFunction.ExecSqLite(sqLiteCmd);


            var MinusCmd = new SQLiteCommand("update RmProduce set iScanQuantity=iScanQuantity-@iQuantity where cCode=@cCode and cInvCode=@cInvCode");
            MinusCmd.Parameters.AddWithValue("@cCode", lblOrderNumber.Text);
            MinusCmd.Parameters.AddWithValue("@cInvCode", rds.RmProduceDetail.Rows[dGridMain.CurrentRowIndex]["cInvCode"]);
            MinusCmd.Parameters.AddWithValue("@iQuantity", rds.RmProduceDetail.Rows[dGridMain.CurrentRowIndex]["iQuantity"]);
            PDAFunction.ExecSqLite(MinusCmd);

            rds.RmProduceDetail.Rows.RemoveAt(dGridMain.CurrentRowIndex);
            RefreshGrid();
            if (rds.RmProduceDetail.Rows.Count > 0)
                dGridMain.CurrentRowIndex = 0;
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

        private void RmPoStore_Closing(object sender, CancelEventArgs e)
        {
            mBc2.EnableScanner = false;
        }

        private void RmPoStore_Load(object sender, EventArgs e)
        {
            InitGrid();
            mBc2.Config.ScanDataSize = 255;
            mBc2.EnableScanner = true;

            RefreshGrid();
        }


    }
}