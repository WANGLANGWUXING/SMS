using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class DBHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string conString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        /// <summary>
        /// 读取表
        /// </summary>
        /// <param name="sql">接收SQL语句</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetList(string sql)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(dt);
            con.Close();
            return dt;
        }
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql">接收SQL语句</param>
        /// <returns>返回影响行数</returns>
        public static bool ExecuteSql(string sql)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
        }
        /// <summary>
        /// 读取视图
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="view">视图</param>
        /// <returns></returns>
        public static DataSet ShowView(string sql, string view)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, view);
            con.Close();
            return ds;
        }
        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteScalar(string sql)
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result;
            if (cmd.ExecuteScalar() != DBNull.Value)
            {
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                result = 0;
            }
            conn.Close();
            return result;
        }
    }
}