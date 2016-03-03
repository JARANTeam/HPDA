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
    public partial class RmPoStore : Form
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


        /// <summary>
        /// 存货编码
        /// </summary>
        private string _cInvCode;

        


        public RmPoStore(string cOrderNumber)
        {
            InitializeComponent();
            lblOrderNumber.Text = cOrderNumber;
        }

        /// <summary>
        /// 初始化表格控件
        /// </summary>
        private void InitGrid()
        {
            var dgts = new DataGridTableStyle { MappingName = rds.RmStoreDetail.TableName };


            DataGridColumnStyle dgAutoID = new DataGridTextBoxColumn();
            dgAutoID.Width = 40;
            dgAutoID.MappingName = "RowNo";
            dgAutoID.HeaderText = "序号";
            dgts.GridColumnStyles.Add(dgAutoID);

            DataGridColumnStyle dgccOrderNumber = new DataGridTextBoxColumn();
            dgccOrderNumber.Width = 120;
            dgccOrderNumber.MappingName = "cLotNo";
            dgccOrderNumber.HeaderText = "批号";
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




            dGridMain.TableStyles.Clear();
            dGridMain.TableStyles.Add(dgts);
            dGridMain.DataSource = rds.RmStoreDetail;

        }

        private void RmPoStore_Load(object sender, EventArgs e)
        {
            mBc2.EnableScanner = true;
            mBc2.Config.ScanDataSize = 200;
            InitGrid();
            RefreshGrid();
        }


        private void RmPoStore_Closing(object sender, CancelEventArgs e)
        {
            mBc2.EnableScanner = false;
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
            var FitemID = cBarCode.Substring(2, cBarCode.IndexOf("*L*") -2);
            //产品序列号
            var cLotNo = cBarCode.Substring(cBarCode.IndexOf("*L*") + 3, cBarCode.IndexOf("*S*") - cBarCode.IndexOf("*L*") - 3);

            //产品批号
            var  cSerialNumber= cBarCode.Substring(cBarCode.IndexOf("*S*") + 3, cBarCode.Length - cBarCode.IndexOf("*S*") - 3);

            ////判断该产品序列号是否已经被扫描
            //if (!JudgeBarCode(cSerialNumber))
            //    return;

            //判断波次订单中是否存在此出库要求产品
            if (!JudgeInvCode(FitemID))
                return;

            //判断要拣货的产品是否已经全部拣完
            if (!OutAll(_cInvCode))
                return;

            using (var pgq = new PdaGetQuantity(_cInvCode, cInvName, cLotNo))
            {
                if (pgq.ShowDialog() != DialogResult.Yes)
                    return;
                //通过校验后进
                SaveOutWareHouse(cSerialNumber, _cInvCode, cInvName, pgq.IQuantity, cLotNo, FitemID);
            }



        }


        /// <summary>
        /// 保存出库扫描,并重新进入出库单号的扫描获取
        /// </summary>
        private void SaveOutWareHouse(string cSerialNumber, string cInvCode, string cInvName, decimal iQuantity, string cLotNo,string FitemID)
        {
            var bInv = new SQLiteCommand("select iScanQuantity,iQuantity,FitemID,FEntryID from RmPo where cInvCode=@cInvCode  and cOrderNumber=@cOrderNumber");
            bInv.Parameters.AddWithValue("@cInvCode", cInvCode);
            bInv.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            var dt = PDAFunction.GetSqLiteTable(bInv);
            if (dt == null || dt.Rows.Count < 1)
            {
                MessageBox.Show(@"获取数据出错！");
                return;
            }

           

            //var PlusCmd = new SQLiteCommand("update RmPo set iScanQuantity=ifnull(iScanQuantity,0)+@iQuantity where cOrderNumber=@cOrderNumber and cInvCode=@cInvCode ");
            //PlusCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            //PlusCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
            //PlusCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            //PDAFunction.ExecSqLite(PlusCmd);

            decimal iFSQty = 0, iFQty = 0;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    iFSQty = decimal.Parse(dt.Rows[i]["iScanQuantity"].ToString());
                    iFQty = decimal.Parse(dt.Rows[i]["iQuantity"].ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("无法取得通知单内原料批号的数量");
                    return;
                }
                if ((iFSQty + iQuantity) <= iFQty)
                {

                    var sqLiteCmd = new SQLiteCommand("insert into RmStoreDetail(cSerialNumber,cOrderNumber,cLotNo,cInvCode,cInvName,iQuantity,cUser,FEntryID,FitemID,FSPNumber) " +
                                              "values(@cSerialNumber,@cOrderNumber,@cLotNo,@cInvCode,@cInvName,@iQuantity,@cUser,@FEntryID,@FitemID,@FSPNumber)");
                    sqLiteCmd.Parameters.AddWithValue("@cSerialNumber", cSerialNumber);
                    sqLiteCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
                    sqLiteCmd.Parameters.AddWithValue("@cLotNo", cLotNo);
                    sqLiteCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
                    sqLiteCmd.Parameters.AddWithValue("@cInvName", cInvName);
                    sqLiteCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
                    sqLiteCmd.Parameters.AddWithValue("@cUser", frmLogin.lUser);
                    sqLiteCmd.Parameters.AddWithValue("@FEntryID", dt.Rows[i]["FEntryID"].ToString());
                    sqLiteCmd.Parameters.AddWithValue("@FitemID", FitemID);
                    sqLiteCmd.Parameters.AddWithValue("@FSPNumber", lblStockPlaceID.Text);

                    PDAFunction.ExecSqLite(sqLiteCmd);

                    var PlusCmd = new SQLiteCommand("update RmPo set iScanQuantity=ifnull(iScanQuantity,0)+@iQuantity where cOrderNumber=@cOrderNumber and cInvCode=@cInvCode and FEntryID=@FEntryID");
                    PlusCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
                    PlusCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
                    PlusCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
                    PlusCmd.Parameters.AddWithValue("@FEntryID", dt.Rows[i]["FEntryID"].ToString());
                    PDAFunction.ExecSqLite(PlusCmd);
                    txtBarCode.Text = "";
                    txtBarCode.Focus();
                    RefreshGrid();
                    return;
                }
                else
                {


                    var sqLiteCmd = new SQLiteCommand("insert into RmStoreDetail(cSerialNumber,cOrderNumber,cLotNo,cInvCode,cInvName,iQuantity,cUser,FEntryID,FitemID,FSPNumber) " +
                                              "values(@cSerialNumber,@cOrderNumber,@cLotNo,@cInvCode,@cInvName,@iQuantity,@cUser,@FEntryID,@FitemID,@FSPNumber)");
                    sqLiteCmd.Parameters.AddWithValue("@cSerialNumber", cSerialNumber);
                    sqLiteCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
                    sqLiteCmd.Parameters.AddWithValue("@cLotNo", cLotNo);
                    sqLiteCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
                    sqLiteCmd.Parameters.AddWithValue("@cInvName", cInvName);
                    sqLiteCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
                    sqLiteCmd.Parameters.AddWithValue("@cUser", frmLogin.lUser);
                    sqLiteCmd.Parameters.AddWithValue("@FEntryID", dt.Rows[i]["FEntryID"].ToString());
                    sqLiteCmd.Parameters.AddWithValue("@FitemID", FitemID);
                    sqLiteCmd.Parameters.AddWithValue("@FSPNumber", lblStockPlaceID.Text);

                    PDAFunction.ExecSqLite(sqLiteCmd);
                    var PlusCmd = new SQLiteCommand("update RmPo set iScanQuantity=ifnull(iScanQuantity,0)+@iQuantity where cOrderNumber=@cOrderNumber and cInvCode=@cInvCode and FEntryID=@FEntryID");
                    PlusCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
                    PlusCmd.Parameters.AddWithValue("@iQuantity", iQuantity);
                    PlusCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
                    PlusCmd.Parameters.AddWithValue("@FEntryID", dt.Rows[i]["FEntryID"].ToString());
                    PDAFunction.ExecSqLite(PlusCmd);
                    iQuantity = iQuantity + iFSQty - iFQty;

                }
            }
            txtBarCode.Text = "";
            txtBarCode.Focus();
            RefreshGrid();

        }


        private void RefreshGrid()
        {
            //重新取出所有的数据
            rds.RmStoreDetail.Rows.Clear();
            rds.RmStoreDetail.Columns.Remove("RowNo");
            DataColumn cAutoID = new DataColumn("RowNo", typeof(Int32));
            cAutoID.AutoIncrement = true;
            cAutoID.AutoIncrementSeed = 1;
            cAutoID.AutoIncrementStep = 1;
            rds.RmStoreDetail.Columns.Add(cAutoID);


            var selectCmd = new SQLiteCommand("select id,cSerialNumber,cOrderNumber,cLotNo,cInvCode,cInvName,cUnit,iQuantity,dScanTime,cUser,FEntryID,FitemID,FSPNumber from RmStoreDetail where cOrderNumber=@cOrderNumber order by id desc");
            selectCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(selectCmd, rds.RmStoreDetail);

            if (rds.RmStoreDetail.Rows.Count >= 1)
                dGridMain.CurrentRowIndex = 0;

            var selectSumCmd = new SQLiteCommand("select sum(iQuantity) from RmStoreDetail where cOrderNumber=@cOrderNumber");
            selectSumCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            lblSum.Text = PDAFunction.GetScalreExecSqLite(selectSumCmd);

            var bOutAllCmd = new SQLiteCommand("select * from RmPo where cOrderNumber=@cOrderNumber and ifnull(iScanQuantity,0)<ifnull(iQuantity,0)");
            bOutAllCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            if (PDAFunction.ExistSqlite(frmLogin.SqliteCon, bOutAllCmd))
            {
                lblOutAll.Text = "未完成";
            }
            else
            {
                lblOutAll.Text = "完成";
            }
        }


        /// <summary>
        /// 判断出库的产品是否包含在出库单中
        /// </summary>
        /// <param name="cInvCode"></param>
        /// <returns></returns>
        private bool JudgeInvCode(string FitemID)
        {
            var bOutAllCmd = new SQLiteCommand("select * from RmPo where FitemID=@FitemID and cOrderNumber=@cOrderNumber");
            bOutAllCmd.Parameters.AddWithValue("@FitemID", FitemID);
            bOutAllCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            var dt = PDAFunction.GetSqLiteTable(bOutAllCmd);
            if (dt == null || dt.Rows.Count < 1)
            {
                MessageBox.Show(@"该采购订单不包含此产品！");
                return false;

            }
            cInvName = dt.Rows[0]["cInvName"].ToString();
            _cInvCode = dt.Rows[0]["cInvCode"].ToString();
            return true;
        }


        /// <summary>
        /// 判断该产品的批号是否全部出完
        /// </summary>
        /// <param name="cInvCode"></param>
        /// <returns></returns>
        private bool OutAll(string cInvCode)
        {
            var bOutAllCmd = new SQLiteCommand("select * from RmPo where cInvCode=@cInvCode and ifnull(iScanQuantity,0)<iQuantity and cOrderNumber=@cOrderNumber");
            bOutAllCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            bOutAllCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            if (!PDAFunction.ExistSqlite(frmLogin.SqliteCon, bOutAllCmd))
            {
                MessageBox.Show(@"该产品已经全部扫描完成");
                return false;

            }
            return true;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            _sumException = 0;
            if (!PDAFunction.IsCanCon())
            {
                MessageBox.Show(@"无法连接到SQL服务器,无法上传", @"Warning");
                return;
            }

            if (rds.RmStoreDetail.Rows.Count <= 0)
            {
                MessageBox.Show(@"无任何数据!", @"Warning");
                return;
            }

            if (lblOutAll.Text.Equals("未完成"))
            {
                if (MessageBox.Show("采购未完成，是否确定要上传", "是否", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    return;
                }
            }
            btnComplete.Enabled = false;

            var cGuid = Guid.NewGuid().ToString();

            for (var i = 0; i <= rds.RmStoreDetail.Rows.Count - 1; i++)
            {
                dGridMain.CurrentRowIndex = i;
                //当有一行记录异常后,将跳出
                if (UpLoaRmStoreDetail(i, cGuid)) continue;
                RefreshGrid();
                btnComplete.Enabled = true;
                return;
                //成功后,删除离线出库通知单数据

            }

            if (_sumException == 0)
            {
                UpLoadMain(cGuid);
                MessageBox.Show(@"全部上传成功!", @"Success");
                var dCmd = new SQLiteCommand("Delete from RmPo where cOrderNumber=@cOrderNumber");
                dCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
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
        private bool UpLoaRmStoreDetail(int iRowId, string cGuid)
        {
            using (var con = new SqlConnection(frmLogin.WmsCon))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Upload_RmStoreDetail";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cSerialNumber", rds.RmStoreDetail.Rows[iRowId]["cSerialNumber"]);
                    cmd.Parameters.AddWithValue("@cOrderNumber", rds.RmStoreDetail.Rows[iRowId]["cOrderNumber"]);
                    cmd.Parameters.AddWithValue("@cLotNo", rds.RmStoreDetail.Rows[iRowId]["cLotNo"]);
                    cmd.Parameters.AddWithValue("@cInvCode", rds.RmStoreDetail.Rows[iRowId]["cInvCode"]);
                    cmd.Parameters.AddWithValue("@cInvName", rds.RmStoreDetail.Rows[iRowId]["cInvName"]);
                    cmd.Parameters.AddWithValue("@cUnit", rds.RmStoreDetail.Rows[iRowId]["cUnit"]);
                    cmd.Parameters.AddWithValue("@iQuantity", rds.RmStoreDetail.Rows[iRowId]["iQuantity"]);
                    cmd.Parameters.AddWithValue("@dScanTime", rds.RmStoreDetail.Rows[iRowId]["dScanTime"]);
                    cmd.Parameters.AddWithValue("@cUser", rds.RmStoreDetail.Rows[iRowId]["cUser"]);
                    cmd.Parameters.AddWithValue("@cGuid", cGuid);
                    cmd.Parameters.AddWithValue("@FEntryID", rds.RmStoreDetail.Rows[iRowId]["FEntryID"]);
                    cmd.Parameters.AddWithValue("@FitemID", rds.RmStoreDetail.Rows[iRowId]["FitemID"]);
                    cmd.Parameters.AddWithValue("@FSPNumber", rds.RmStoreDetail.Rows[iRowId]["FSPNumber"]);


                    try
                    {
                        con.Open();
                        var iTem = cmd.ExecuteNonQuery();
                        if (iTem == 1)
                        {
                            var dSqliteCmd = new SQLiteCommand("Delete from RmStoreDetail where id=@id");
                            //成功后,删除离线出库数据中的表
                            dSqliteCmd.Parameters.AddWithValue("@id", rds.RmStoreDetail.Rows[iRowId]["id"]);
                            PDAFunction.ExecSqLite(dSqliteCmd);
                            return true;
                        }
                        _sumException += 1;
                        return false;
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

        /// <summary>
        /// 将拣货的主表也上传到服务器上
        /// </summary>
        /// <param name="cGuid"></param>
        private void UpLoadMain(string cGuid)
        {
            rds.RmStoreDetail.Rows.Clear();
            var Sqlitecmd = new SQLiteCommand("select * from RmPo where cOrderNumber=@cOrderNumber");
            Sqlitecmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(Sqlitecmd, rds.RmPo);
            for (var i = 0; i <= rds.RmPo.Rows.Count - 1; i++)
            {
                ExecUpLoad(i, cGuid);
            }

            //using (var con = new SqlConnection(frmLogin.WmsCon))
            //{
            //    using (var cmd = con.CreateCommand())
            //    {
            //        cmd.CommandText = "insert into ProDelivery(cCode,cGuid) values(@cCode,@cGuid)";
            //        cmd.Parameters.AddWithValue("@cCode", lblOwhNumber.Text);
            //        cmd.Parameters.AddWithValue("@cGuid", cGuid.ToString());
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        private bool ExecUpLoad(int i, string cGuid)
        {
            using (var con = new SqlConnection(frmLogin.WmsCon))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Upload_RmPo";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cOrderNumber", rds.RmPo.Rows[i]["cOrderNumber"]);
                    cmd.Parameters.AddWithValue("@cInvCode", rds.RmPo.Rows[i]["cInvCode"]);
                    cmd.Parameters.AddWithValue("@cInvName", rds.RmPo.Rows[i]["cInvName"]);
                    cmd.Parameters.AddWithValue("@cUnit", rds.RmPo.Rows[i]["cUnit"]);
                    cmd.Parameters.AddWithValue("@iQuantity", rds.RmPo.Rows[i]["iQuantity"]);
                    cmd.Parameters.AddWithValue("@iScanQuantity", rds.RmPo.Rows[i]["iScanQuantity"]);
                    cmd.Parameters.AddWithValue("@cVendor", rds.RmPo.Rows[i]["cVendor"]);
                    cmd.Parameters.AddWithValue("@cMemo", rds.RmPo.Rows[i]["cMemo"]);
                    cmd.Parameters.AddWithValue("@cUser", frmLogin.lUser);
                    cmd.Parameters.AddWithValue("@cGuid", cGuid);
                    cmd.Parameters.AddWithValue("@FEntryID", rds.RmPo.Rows[i]["FEntryID"]);
                    cmd.Parameters.AddWithValue("@FItemID", rds.RmPo.Rows[i]["FItemID"]);
                    try
                    {
                        con.Open();
                        var iTem = cmd.ExecuteNonQuery();
                        if (iTem == 1)
                        {
                            var dSqliteCmd = new SQLiteCommand("Delete from RmPo where id=@id");
                            //成功后,删除离线出库数据中的表
                            dSqliteCmd.Parameters.AddWithValue("@id", rds.RmPo.Rows[i]["id"]);
                            PDAFunction.ExecSqLite(dSqliteCmd);
                            return true;
                        }
                        return false;
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
            var sqLiteCmd = new SQLiteCommand("Delete From RmStoreDetail where id=@id");
            sqLiteCmd.Parameters.AddWithValue("@id", rds.RmStoreDetail.Rows[dGridMain.CurrentRowIndex]["id"]);
            //执行删除
            PDAFunction.ExecSqLite(sqLiteCmd);


            var MinusCmd = new SQLiteCommand("update RmPo set iScanQuantity=iScanQuantity-@iQuantity where FEntryID=@FEntryID");
            MinusCmd.Parameters.AddWithValue("@cInvCode", rds.RmStoreDetail.Rows[dGridMain.CurrentRowIndex]["FEntryID"]);
            MinusCmd.Parameters.AddWithValue("@iQuantity", rds.RmStoreDetail.Rows[dGridMain.CurrentRowIndex]["iQuantity"]);
            PDAFunction.ExecSqLite(MinusCmd);

            rds.RmStoreDetail.Rows.RemoveAt(dGridMain.CurrentRowIndex);
            RefreshGrid();
            if (rds.RmStoreDetail.Rows.Count > 0)
                dGridMain.CurrentRowIndex = 0;
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            scan_OnDecodeEvent(txtBarCode.Text);
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

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            var rpd = new RmPoStoreDetail(lblOrderNumber.Text);
            rpd.ShowDialog();
        }


    }
}