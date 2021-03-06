﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CheckDAL
    {

        /// <summary>
        /// 查询结算视图
        /// </summary>
        /// <param name="type">信息类型</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static DataSet GetReckoningView(string type, string pageSize, string pageIndex)
        {
            string sql = "select TOP " + pageSize + " * from Reckoning where type='" + type + "' and id not in(select top ((" + pageIndex + "-1)*" + pageSize + ") id from Reckoning) order by id desc";
            return DBHelper.ShowView(sql, "Reckoning");
        }
        /// <summary>
        /// 计算数据总量
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int CountReckoning(string type)
        {
            string sql = "select count(*) from Reckoning where type='" + type + "' ";
            return Convert.ToInt32(DBHelper.GetList(sql).Rows[0][0].ToString());
        }
        /// <summary>
        /// 获取未付金额
        /// </summary>
        /// <param name="id">视图id</param>
        /// <returns>返回金额</returns>
        public static int GetNotPayment(string id)
        {
            string sql = "select NotPayment from Reckoning where id=" + id;
            int NotPayment = DBHelper.ExecuteScalar(sql);
            sql = "select sum(Settlement) as payment from tb_Reckoning where CommodityId=" + id;
            int payment = DBHelper.ExecuteScalar(sql);
            int not = NotPayment - payment;
            return not;
        }
        /// <summary>
        /// 结款次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Count(string id)
        {
            string sql = "select count(*) from tb_Reckoning where CommodityId=" + id;
            return DBHelper.ExecuteScalar(sql) + 1;
        }
        /// <summary>
        /// 添加结算信息
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <param name="payment">结账金额</param>
        /// <param name="managemen">经手人</param>
        /// <param name="username">管理员名称</param>
        /// <param name="datetime">时间</param>
        /// <returns>返回是否添加成功</returns>
        public static bool AddReckoning(string id, string payment, string managemen, string username, string datetime)
        {
            string sql = string.Format("insert into tb_Reckoning (CommodityId,Settlement,ManageMan,username,Addtime,datetime)values({0},'{1}','{2}','{3}','{4}','{5}')", id, payment, managemen, username, Convert.ToString(DateTime.Now), Convert.ToDateTime(datetime).ToShortDateString());
            return DBHelper.ExecuteSql(sql);
        }

        /// <summary>
        /// 查询商品库存视图
        /// </summary>
        /// <param name="searchSql">查询时的额外参数</param>
        /// <returns>返回DataSet</returns>
        public static DataSet GetStockpileView(string searchSql, string pageSize, string pageIndex)
        {
            string sql = "select top " + pageSize + " * from Stockpile where id not in(select top ((" + pageIndex + "-1)*" + pageSize + ") id from Stockpile) and id is not null order by id desc";
            if (!string.IsNullOrWhiteSpace(searchSql))
            {
                sql = "select top " + pageSize + " * from Stockpile where id not in(select top ((" + pageIndex + "-1)*" + pageSize + ") id from Stockpile) and id is not null " + searchSql + " order by id desc";

            }
            return DBHelper.ShowView(sql, "Stockpile");
        }
        /// <summary>
        /// 计算库存视图的数量总量
        /// </summary>
        /// <returns></returns>
        public static int CountStockpile()
        {
            string sql = "select COUNT(*) from Stockpile where id is not null";
            return Convert.ToInt32(DBHelper.GetList(sql).Rows[0][0].ToString());
        }
        /// <summary>
        /// 计算商品库存（进货减退货）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int StockCount(string id)
        {
            int StockNum, returnNum;
            string sql = "select sum(Number) from tb_Stock where CommodityId=" + id + " and Type='进货信息'";
            StockNum = DBHelper.ExecuteScalar(sql);
            sql = "select sum(Number) from tb_Stock where CommodityId=" + id + " and Type='进货退货'";
            returnNum = DBHelper.ExecuteScalar(sql);
            return StockNum - returnNum;
        }
        /// <summary>
        /// 计算销售数量（销售减销售退货）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int SellCount(string id)
        {
            int StockNum, returnNum;
            string sql = "select sum(Number) from tb_Stock where CommodityId=" + id + " and Type='销售信息'";
            StockNum = DBHelper.ExecuteScalar(sql);
            sql = "select sum(Number) from tb_Stock where CommodityId=" + id + " and Type='销售退货'";
            returnNum = DBHelper.ExecuteScalar(sql);
            return StockNum - returnNum;
        }
        /// <summary>
        /// 单据编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetReckoningID(string id)
        {
            string sql = "select StockDate from Reckoning where id=" + id;
            string StockDate = DBHelper.GetList(sql).Rows[0]["StockDate"].ToString();
            string Month = Convert.ToDateTime(StockDate).Month.ToString();
            if (Month.Length < 2)
            {
                Month = "0" + Month;
            }
            string Day = Convert.ToDateTime(StockDate).Day.ToString();
            if (Day.Length < 2)
            {
                Day = "0" + Day;
            }
            string zero = "";
            for (int i = 1; i < (3 - id.Length); i++)
            {
                zero += "0";
            }
            string Year = Convert.ToDateTime(StockDate).Year.ToString();
            string ReckoningID = Year + Month + Day + zero + id;
            return ReckoningID;
        }
        /// <summary>
        /// 详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataSet GetStock(string id)
        {
            string sql = "select * from stock where id=" + id;
            return DBHelper.ShowView(sql, "stock");
        }
        /// <summary>
        /// 显示统计视图
        /// </summary>
        /// <returns></returns>
        public static DataSet GetTotalView(string pageSize, string pageIndex)
        {
            string sql = "select top " + pageSize + " * from total where total not in(select top ((" + pageIndex + "-1)*" + pageSize + ") total from total) order by total desc";
            return DBHelper.ShowView(sql, "total");
        }
        /// <summary>
        /// 统计视图总计
        /// </summary>
        /// <returns></returns>
        public static int CountTotal()
        {
            string sql = "select count(*) from total";
            return Convert.ToInt32(DBHelper.GetList(sql).Rows[0][0].ToString());
        }
        /// <summary>
        /// 改变商品数量
        /// </summary>
        /// <param name="total"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool UpdateCommodity(string total, string id)
        {
            string sql = "update tb_Commodity  set total=" + total + " where id=" + id;
            return DBHelper.ExecuteSql(sql);
        }
        /// <summary>
        /// 日销售额
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSaleTable(string pageSize, string pageIndex)
        {
            string sql = "select top " + pageSize + " *  from DaySale where year not in(select top ((" + pageIndex + "-1)*" + pageSize + ") year from DaySale) order by year desc";
            return DBHelper.GetList(sql);
        }

        public static int CountDaySale()
        {
            string sql = "select count(*) from DaySale";
            return Convert.ToInt32(DBHelper.GetList(sql).Rows[0][0].ToString());
        }


        /// <summary>
        /// 获取结算类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetType()
        {
            string sql = "select distinct type from Reckoning";
            return DBHelper.GetList(sql);
        }


    }
}
