using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebService
{
    public class BaseClass : System.Web.UI.Page
    {
        private MySqlCommand cmd;
        private MySqlConnection conn;
        private MySqlDataAdapter adp;
        private static string address = "127.0.0.1";
        private static string myname = "root";
        private static string mypwd = "root";
        private static string connString = "Data Source=" + address + ";Allow User Variables=True;Database=web;User ID=" + myname + ";Password=" + mypwd + ";Charset=gbk;convert zero datetime=True";



        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="what">要查询的数据</param>
        /// <param name="from">表名</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        protected DataSet GetList(string what,string from,string where)
        {
            try
            {
                string sql = "Select " + what + "  from " + from + " ";
                if ("" != where)
                {
                    sql += "where " + where + "";
                }
                conn = new MySqlConnection(connString);
                conn.Open();
                adp = new MySqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected bool ExecuteQuery(string sql, out string msg)
        {
            int i = 0;
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                i = cmd.ExecuteNonQuery();
                conn.Close();
                msg = null;
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return i > 0 ? true : false;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string MD5jm(string pwd)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] MD5Source = System.Text.Encoding.UTF8.GetBytes(pwd);
            byte[] MD5Out = MD5CSP.ComputeHash(MD5Source);

            return Convert.ToBase64String(MD5Out);
        }
    }
}