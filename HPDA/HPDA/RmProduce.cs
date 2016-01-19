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

namespace SPDA
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

        public RmProduce(string cOrderNumber)
        {
            InitializeComponent();
            lblOrderNumber.Text = cOrderNumber;
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
            if ((!cBarCode.StartsWith("RM*") && !cBarCode.StartsWith("SE*")) || !cBarCode.Contains("*C*") || !cBarCode.Contains("*L*"))
            {
                MessageBox.Show("无效条码", "Error");
                return;
            }
            //物料编码
            var cInvCode=cBarCode.Substring(3, cBarCode.IndexOf("*C*")-3);
            //产品序列号
            var cSerialNumber = cBarCode.Substring(cBarCode.IndexOf("*C*") + 3, cBarCode.IndexOf("*L*") - cBarCode.IndexOf("*C*") - 3);

            //产品批号
            var cLotNo = cBarCode.Substring(cBarCode.IndexOf("*L*") + 3, cBarCode.Length - cBarCode.IndexOf("*L*") - 3);
            
            ////判断该产品序列号是否已经被扫描
            //if (!JudgeBarCode(cSerialNumber))
            //    return;

            //判断波次订单中是否存在此出库要求产品
            if (!JudgeInvCode(cInvCode))
                return;

            //判断要拣货的产品是否已经全部拣完
            if (!OutAll(cInvCode))
                return;

            var dtQuantity = GetQuantityData(cInvCode);
            var ciQuantity = dtQuantity.Rows[0]["iQuantity"].ToString();
            var ciScanQuantity = dtQuantity.Rows[0]["iScanQuantity"].ToString();
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

            using (var pgq = new PdaGetQuantity(cInvCode,cInvName,cLotNo,(iQuantity-iScanQuantity).ToString()))
            {
                if (pgq.ShowDialog() != DialogResult.Yes)
                    return;
                //通过校验后进行波次拣货保存
                SaveOutWareHouse(cSerialNumber, cInvCode, cInvName, pgq.IQuantity, cLotNo);
            }


            
        }


        /// <summary>
        /// 保存出库扫描,并重新进入出库单号的扫描获取
        /// </summary>
        private void SaveOutWareHouse(string cSerialNumber, string cInvCode, string cInvName, decimal iQuantity, string cLotNo)
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


            var selectCmd = new SQLiteCommand("select * from RmProduceDetail where cOrderNumber=@cOrderNumber order by id desc");
            selectCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(selectCmd, rds.RmProduceDetail);

            if (rds.RmProduceDetail.Rows.Count >= 1)
                dGridMain.CurrentRowIndex = 0;

            var selectSumCmd = new SQLiteCommand("select sum(iQuantity) from RmProduceDetail where cOrderNumber=@cOrderNumber");
            selectSumCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            lblSum.Text = PDAFunction.GetScalreExecSqLite(selectSumCmd);

            var bOutAllCmd = new SQLiteCommand("select * from RmProduce where cOrderNumber=@cOrderNumber and ifnull(iScanQuantity,0)<ifnull(iQuantity,0)");
            bOutAllCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            if (PDAFunction.ExistSqlite(PdaLogin.SqliteCon, bOutAllCmd))
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
        //    if (PDAFunction.ExistSqlite(PdaLogin.SqliteCon, bDeliveryCmd))
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
        private bool JudgeInvCode(string cInvCode)
        {
            var bOutAllCmd = new SQLiteCommand("select cInvCode,cInvName from RmProduce where cInvCode=@cInvCode and cOrderNumber=@cOrderNumber");
            bOutAllCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            bOutAllCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            var dt=PDAFunction.GetSqLiteTable(bOutAllCmd);
            if (dt==null||dt.Rows.Count<1)
            {
                MessageBox.Show(@"该生产订单不包含此产品！");
                return false;

            }
            cInvName = dt.Rows[0]["cInvName"].ToString();
            return true;
        }


        /// <summary>
        /// 判断该产品的批号是否全部出完
        /// </summary>
        /// <param name="cInvCode"></param>
        /// <returns></returns>
        private bool OutAll(string cInvCode)
        {
            var bOutAllCmd = new SQLiteCommand("select * from RmProduce where cInvCode=@cInvCode and iScanQuantity<iQuantity and cOrderNumber=@cOrderNumber");
            bOutAllCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            bOutAllCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            if (!PDAFunction.ExistSqlite(PdaLogin.SqliteCon, bOutAllCmd))
            {
                MessageBox.Show(@"该产品已经领料完成");
                return false;

            }
            return true;
        }


        private DataTable GetQuantityData(string cInvCode)
        {
            var bOutAllCmd = new SQLiteCommand("select iQuantity,iScanQuantity from RmProduce where cInvCode=@cInvCode and iScanQuantity<iQuantity and cOrderNumber=@cOrderNumber");
            bOutAllCmd.Parameters.AddWithValue("@cInvCode", cInvCode);
            bOutAllCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            return PDAFunction.GetSqLiteTable(bOutAllCmd);
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

            for (var i = 0; i <= rds.RmProduceDetail.Rows.Count - 1; i++)
            {
                dGridMain.CurrentRowIndex = i;
                //当有一行记录异常后,将跳出
                if (UpLoaRmProduceDetail(i, cGuid)) continue;
                //RefreshGrid();
                btnComplete.Enabled = true;
                //成功后,删除离线出库通知单数据

            }

            if (_sumException == 0)
            {
                UpLoadMain(cGuid);
                MessageBox.Show(@"全部上传成功!", @"Success");
                var dCmd = new SQLiteCommand("Delete from RmProduce where cOrderNumber=@cOrderNumber");
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
        private bool UpLoaRmProduceDetail(int iRowId,string cGuid)
        {
            using (var con = new SqlConnection(PdaLogin.WmsCon))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Upload_RmProduceDetail";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cSerialNumber", rds.RmProduceDetail.Rows[iRowId]["cSerialNumber"]);
                    cmd.Parameters.AddWithValue("@cOrderNumber", rds.RmProduceDetail.Rows[iRowId]["cOrderNumber"]);
                    cmd.Parameters.AddWithValue("@cLotNo", rds.RmProduceDetail.Rows[iRowId]["cLotNo"]);
                    cmd.Parameters.AddWithValue("@cInvCode", rds.RmProduceDetail.Rows[iRowId]["cInvCode"]);
                    cmd.Parameters.AddWithValue("@cInvName", rds.RmProduceDetail.Rows[iRowId]["cInvName"]);
                    cmd.Parameters.AddWithValue("@cUnit", rds.RmProduceDetail.Rows[iRowId]["cUnit"]);
                    cmd.Parameters.AddWithValue("@iQuantity", rds.RmProduceDetail.Rows[iRowId]["iQuantity"]);
                    cmd.Parameters.AddWithValue("@dScanTime", rds.RmProduceDetail.Rows[iRowId]["dScanTime"]);
                    cmd.Parameters.AddWithValue("@cUser", rds.RmProduceDetail.Rows[iRowId]["cUser"]);
                    cmd.Parameters.AddWithValue("@cGuid", cGuid);


                    try
                    {
                        con.Open();
                        var iTem = cmd.ExecuteNonQuery();
                        if (iTem == 1)
                        {
                            var dSqliteCmd = new SQLiteCommand("Delete from RmProduceDetail where id=@id");
                            //成功后,删除离线出库数据中的表
                            dSqliteCmd.Parameters.AddWithValue("@id", rds.RmProduceDetail.Rows[iRowId]["id"]);
                            PDAFunction.ExecSqLite(dSqliteCmd);
                            return true;
                        }
                        _sumException += 1;
                        return false;
                    }
                    catch (Exception)
                    {
                        _sumException += 1;
                        MessageBox.Show(@"无法连接到SQL服务器,请重试!", @"Warning");
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
            rds.RmProduceDetail.Rows.Clear();
            var Sqlitecmd = new SQLiteCommand("select id,cOrderNumber,cInvCode,cInvName,iQuantity,iScanQuantity,cMemo from RmProduce where cOrderNumber=@cOrderNumber");
            Sqlitecmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
            PDAFunction.GetSqLiteTable(Sqlitecmd, rds.RmProduce);
            for (var i = 0; i <= rds.RmProduce.Rows.Count - 1; i++)
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
            using (var con = new SqlConnection(PdaLogin.WmsCon))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Upload_RmProduce";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cOrderNumber", rds.RmProduce.Rows[i]["cOrderNumber"]);
                    cmd.Parameters.AddWithValue("@cInvCode", rds.RmProduce.Rows[i]["cInvCode"]);
                    cmd.Parameters.AddWithValue("@cInvName", rds.RmProduce.Rows[i]["cInvName"]);
                    cmd.Parameters.AddWithValue("@cUnit", rds.RmProduce.Rows[i]["cUnit"]);
                    cmd.Parameters.AddWithValue("@iQuantity", rds.RmProduce.Rows[i]["iQuantity"]);
                    cmd.Parameters.AddWithValue("@iScanQuantity", rds.RmProduce.Rows[i]["iScanQuantity"]);
                    cmd.Parameters.AddWithValue("@cMemo", rds.RmProduce.Rows[i]["cMemo"]);
                    cmd.Parameters.AddWithValue("@cUser", PdaLogin.lUser);
                    cmd.Parameters.AddWithValue("@cGuid", cGuid);

                    try
                    {
                        con.Open();
                        var iTem = cmd.ExecuteNonQuery();
                        if (iTem == 1)
                        {
                            var dSqliteCmd = new SQLiteCommand("Delete from RmProduce where id=@id");
                            //成功后,删除离线出库数据中的表
                            dSqliteCmd.Parameters.AddWithValue("@id", rds.RmProduce.Rows[i]["id"]);
                            PDAFunction.ExecSqLite(dSqliteCmd);
                            return true;
                        }
                        return false;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"无法连接到SQL服务器,请重试!", @"Warning");
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


            var MinusCmd = new SQLiteCommand("update RmProduce set iScanQuantity=iScanQuantity-@iQuantity where cOrderNumber=@cOrderNumber and cInvCode=@cInvCode");
            MinusCmd.Parameters.AddWithValue("@cOrderNumber", lblOrderNumber.Text);
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
            mBc2.EnableScanner = true;
            RefreshGrid();
        }


    }
}