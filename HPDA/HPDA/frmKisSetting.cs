using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace HPDA
{
    public partial class frmKisSetting : Form
    {

      

       // private NLSScanner scanTest = new NLSScanner();

        public frmKisSetting()
        {
            InitializeComponent();
            //scanTest.OnDecodeEvent += new DecodeEventHandler(scan_OnDecodeEvent);

        }

   
        private void frmLogin_Load(object sender, EventArgs e)
        {
            using (var con = new SQLiteConnection(frmLogin.SqliteCon))
            {
                using (var cmd = new SQLiteCommand("select cValue from Setting where cName='cK3Server' or cName='cK3Data' or cName='cK3User' or cName='cK3Pwd'   order by id", con))
                {
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                            txtServer.Text = dr[0].ToString();
                    if (dr.Read())
                            txtData.Text = dr[0].ToString();
                        if (dr.Read())
                            txtUser.Text =dr[0].ToString();
                        if (dr.Read())
                            txtPwd.Text = dr[0].ToString();
                    }
                }
            }


        }

        private void bntLogin_Click(object sender, EventArgs e)
        {


            frmLogin.KisCon= "Data Source=" + txtServer.Text
                                + ";Initial Catalog=" + txtData.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPwd.Text;

            using (var cmd = new SQLiteCommand("update Setting set cValue=@cValue where cName=@cName"))
            {
                //更新服务器
                cmd.Parameters.AddWithValue("@cValue", txtServer.Text);
                cmd.Parameters.AddWithValue("@cName", "cK3Server");
                PDAFunction.ExecSqlite(cmd);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cValue", txtData.Text);
                cmd.Parameters.AddWithValue("@cName", "cK3Data");
                PDAFunction.ExecSqlite(cmd);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cValue", txtUser.Text);
                cmd.Parameters.AddWithValue("@cName", "cK3User");
                PDAFunction.ExecSqlite(cmd);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cValue", txtPwd.Text);
                cmd.Parameters.AddWithValue("@cName", "cK3Pwd");
                PDAFunction.ExecSqlite(cmd);


            }
            MessageBox.Show("更新成功");


           
        }




    }
}