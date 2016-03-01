using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Security.Cryptography;


namespace HPDA
{
    class PDAFunction
    {

        
        /// <summary>
        /// 判断是否,可以打开数据库连接
        /// </summary>
        /// <returns>真表示可以,假表示不可以</returns>
        public static Boolean IsCanCon()
        {
            using (var con = new SqlConnection(frmLogin.WmsCon))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取服务器端时间
        /// </summary>
        /// <returns></returns>
        public static string GetServerTime()
        {
            using (var con = new SqlConnection(frmLogin.WmsCon))
            {
                using (var cmd = new SqlCommand("select GETDATE()", con))
                {
                    try
                    {
                        con.Open();
                        var sResult = cmd.ExecuteScalar().ToString();
                        return sResult;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }

            }
        }
        /// <summary>
        /// 执行先SQL命令,更新SQLite数据库
        /// </summary>
        /// <param name="sQlitecmd">执行的命令sQlitecmd</param>
        public static void ExecSqLite(SQLiteCommand sQlitecmd)
        {
            using (var sQlitecon = new SQLiteConnection(frmLogin.SqliteCon))
            {
                using (sQlitecmd)
                {
                    sQlitecmd.Connection = sQlitecon;
                    sQlitecon.Open();
                    sQlitecmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// 执行先SQL命令,更新SQLite数据库
        /// </summary>
        /// <param name="sQlitecmd">执行的命令sQlitecmd</param>
        public static void ExecSqL(SqlConnection sqlCon,SqlCommand sqlCmd)
        {
            using (sqlCon)
            {
                using (sqlCmd)
                {
                    sqlCmd.Connection = sqlCon;
                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetSqlTable(SqlConnection con,SqlCommand cmd)
        {
            using (con)
            {
                using (cmd)
                {
                    cmd.Connection=con;
                    using(var da=new SqlDataAdapter(cmd))
                    {
                        var dt=new DataTable("dtTemp");
                        da.Fill(dt);
                        return dt;

                    }
                }
            }
        }

        public static void GetSqlTable(SqlConnection con, SqlCommand cmd,DataTable dt)
        {
            using (con)
            {
                using (cmd)
                {
                    cmd.Connection = con;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            da.Fill(dt);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }

                        

                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="cmd"></param>
        /// <param name="dt"></param>
        public static DataTable GetSqlTable( SqlCommand cmd)
        {
            DataTable dt = new DataTable("Temp");
            using (SqlConnection con = new SqlConnection(frmLogin.WmsCon))
            {
                using (cmd)
                {
                    
                    cmd.Connection = con;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            da.Fill(dt);
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 判断SQL数据库中是否存在符合条件的数据 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool ExistSql(SqlConnection con, SqlCommand cmd)
        {
            using (con)
            {
                using (cmd)
                {
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteReader().Read();
                }
            }
        }

        /// <summary>
        /// 判断SQL数据库中是否存在符合条件的数据 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool ExistSqlKis(SqlCommand cmd)
        {
            using (var con=new SqlConnection(frmLogin.KisCon))
            {
                using (cmd)
                {
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteReader().Read();
                }
            }
        }


        /// <summary>
        /// 返回数据库中的一条记录
        /// </summary>
        /// <param name="con"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string GetSqlSingle(SqlConnection con, SqlCommand cmd)
        {
            using (con)
            {
                using (cmd)
                {
                    cmd.Connection = con;
                    con.Open();
                    var rs=cmd.ExecuteScalar();
                    if(rs==null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return rs.ToString();
                    }
                    
                }
            }
        }
        /// <summary>
        /// 判断SQL数据库中是否存在符合条件的数据 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool ExistSqlite(string strcon, SQLiteCommand cmd)
        {
            var con = new SQLiteConnection(strcon);
            using (con)
            {
                using (cmd)
                {
                    cmd.Connection = con;
                    con.Open();
                    return cmd.ExecuteReader().Read();
                }
            }
        }


        public static DataTable GetSqLiteTable(SQLiteCommand sQlitecmd, DataTable dt)
        {
            using (var sQlitecon = new SQLiteConnection(frmLogin.SqliteCon))
            {
                using (sQlitecmd)
                {
                    sQlitecmd.Connection = sQlitecon;
                    sQlitecon.Open();
                    using (var da = new SQLiteDataAdapter(sQlitecmd))
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        public static DataTable GetSqLiteTable(SQLiteCommand sQlitecmd)
        {
            using (var sQlitecon = new SQLiteConnection(frmLogin.SqliteCon))
            {
                using (sQlitecmd)
                {
                    sQlitecmd.Connection = sQlitecon;
                    sQlitecon.Open();
                    using (var da = new SQLiteDataAdapter(sQlitecmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// 执行先SQL命令,返回是否有记录
        /// </summary>
        /// <param name="sQlitecmd">执行的命令sQlitecmd</param>
        /// <returns>返回得到的一个值</returns>
        public static string GetScalreExecSqLite(SQLiteCommand sQlitecmd)
        {
            using (var sQlitecon = new SQLiteConnection(frmLogin.SqliteCon))
            {
                using (sQlitecmd)
                {
                    sQlitecmd.Connection = sQlitecon;
                    sQlitecon.Open();
                    using (var dr = sQlitecmd.ExecuteReader())
                    {
                        return dr.Read() ? dr[0].ToString() : string.Empty;
                    }
                }
            }
        }

        public static void ExecSqlite(SQLiteCommand cmd)
        {
            using (var con = new SQLiteConnection(frmLogin.SqliteCon))
            {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 获取服务器连接配置
        /// </summary>
        /// <returns></returns>
        public static string GetWmsConstring()
        {
            string cServer = "", cData = "", cUser = "", cPwd = "";
            using (var con = new SQLiteConnection(frmLogin.SqliteCon))
            {
                using (var cmd = new SQLiteCommand("select cValue from Setting where cName='cServer' or cName='cData' or cName='cUser' or cName='cPwd'  or cName='U8Account' order by id", con))
                {
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                            cServer = dr[0].ToString();
                        if (dr.Read())
                            cData = dr[0].ToString();
                        if (dr.Read())
                            cUser = dr[0].ToString();
                        if (dr.Read())
                            cPwd = dr[0].ToString();
                    }
                }
            }
            return "Data Source=" + cServer
                                + ";Initial Catalog=" + cData + ";User ID=" + cUser + ";Password=" + cPwd;

        }

        public static string GetKisConstring()
        {
            string cServer = "", cData = "", cUser = "", cPwd = "";
            using (var con = new SQLiteConnection(frmLogin.SqliteCon))
            {
                using (var cmd = new SQLiteCommand("select cValue from Setting where cName='cK3Server' or cName='cK3Data' or cName='cK3User' or cName='cK3Pwd'  or cName='U8Account' order by id", con))
                {
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                            cServer = dr[0].ToString();
                        if (dr.Read())
                            cData = dr[0].ToString();
                        if (dr.Read())
                            cUser = dr[0].ToString();
                        if (dr.Read())
                            cPwd = dr[0].ToString();
                    }
                }
            }
            return "Data Source=" + cServer
                                + ";Initial Catalog=" + cData + ";User ID=" + cUser + ";Password=" + cPwd;

        }


        /// <summary>
        /// 输入一字符串返回该字符串的MD值
        /// </summary>
        /// <param name="sDataIn">输入要加密的字符串</param>
        /// <returns>返回:MD5加密后的文件</returns>
        public static string GetMd5Hash(String sDataIn)
        {
            //加盐  "@abc*i"
            sDataIn = sDataIn + "@abc*i";
            //初始化System.Security.Cryptography.MD5CryptoServiceProvider的新实例
            var md5 = new MD5CryptoServiceProvider();
            //将String.String字符串中的字符编码为一个字节序列 返回byte[]
            var bytValue = Encoding.UTF8.GetBytes(sDataIn);
            //计算指定字节数组的Hash值 返回byte[]
            var bytHash = md5.ComputeHash(bytValue);
            //释放资源
            md5.Clear();
            var sTemp = "";
            for (var i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }
    }
}
