using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.Barcode2;
using System.Data.SqlClient;

namespace HPDA
{
    public partial class frmLogin : Form
    {
        public static string WmsCon;
        public static string KisCon;
        public static string lUser;
        public static string PDASN;

        public static string SqliteCon = "Data Source=.\\data\\WmsData;Pooling=true;FailIfMissing=false";

        public struct SystemTime
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        public frmLogin()
        {
            InitializeComponent();
        }

       
        private void frmLogin_Load(object sender, EventArgs e)
        {
            PDASN = "A20140810E";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        }

        private void miSetting_Click(object sender, EventArgs e)
        {
            using (var fs = new frmSetting())
            {
                fs.ShowDialog();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {



            LoginOk();

            
        }

        private void LoginOk()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("用户名必填");
                return;
            }


            WmsCon = PDAFunction.GetWmsConstring();
            KisCon = PDAFunction.GetKisConstring();
            lUser = txtName.Text;

            if (!PDAFunction.IsCanCon())
            {
                MessageBox.Show(@"无法连接到SQL服务器,无法验证", @"Warning");
                return;
            }

            var strTemp = PDAFunction.GetServerTime();
            if (strTemp != null)
            {
                var dt = DateTime.Parse(strTemp);
                var sysdt = new SystemTime
                {
                    wYear = (short)dt.Year,
                    wMonth = (short)dt.Month,
                    wDay = (short)dt.Day,
                    wHour = (short)dt.Hour,
                    wMinute = (short)dt.Minute,
                    wSecond = (short)dt.Second
                };
                Win32API.SetLocalTime(ref sysdt);
            }

            var con = new SqlConnection(WmsCon);
            var cmd = new SqlCommand
            {
                Connection = con,
                CommandText =
                    "select uName,uRole from BUser where (uName=@uName or uCode=@uName) and uPassword=@uPassword"
            };

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@uName", txtName.Text);
            cmd.Parameters.AddWithValue("@uPassword", PDAFunction.GetMd5Hash(txtPwd.Text));
            con.Open();
            var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read()) //直接登陆
            {
                lUser = dr["uName"].ToString(); //把登陆名和登陆服务器保存到静态变量中


                dr.Close();
                Hide();
                using (var fMain = new frmMain())
                {
                    fMain.ShowDialog();
                }
                Show();
            }
            else
            {
                MessageBox.Show(@"用户名或密码错误，请联系管理员！", @"Warning");
            }
        }

        private void biK3Setting_Click(object sender, EventArgs e)
        {
            using (var fs = new frmKisSetting())
            {
                fs.ShowDialog();
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            LoginOk();
        }

    }
    /// <summary>
    /// Win32API,WinCE自带
    /// </summary>
    public class Win32API
    {
        [DllImport("coredll.dll", SetLastError = true)]
        public static extern int SetLocalTime(ref frmLogin.SystemTime lpSystemTime);
    }

}