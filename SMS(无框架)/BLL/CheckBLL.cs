using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CheckBLL
    {
        /// <summary>
        /// 查询结算视图
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DataSet GetReckoningView(string type)
        {
            return CheckDAL.GetReckoningView(type);
        }
        /// <summary>
        /// 获取未付金额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetNotPayment(string id)
        {
            return CheckDAL.GetNotPayment(id);
        }
        /// <summary>
        /// 结款次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Count(string id)
        {
            return CheckDAL.Count(id);
        }
        /// <summary>
        /// 添加结算信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payment"></param>
        /// <param name="managemen"></param>
        /// <param name="username"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static bool AddReckoning(string id, string payment, string managemen, string username, string datetime)
        {
            return CheckDAL.AddReckoning(id, payment, managemen, username, datetime);
        }
        /// <summary>
        /// 查询商品库存视图
        /// </summary>
        /// <param name="searchSql"></param>
        /// <returns></returns>
        public static DataSet GetStockpileView(string searchSql)
        {
            return CheckDAL.GetStockpileView(searchSql);
        }
        /// <summary>
        /// 计算商品库存（进货减退货）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int StockCount(string id)
        {
            return CheckDAL.StockCount(id);
        }
        /// <summary>
        /// 计算销售数量（销售减销售退货）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int SellCount(string id)
        {
            return CheckDAL.SellCount(id);
        }
        /// <summary>
        /// 单据编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetReckoningID(string id)
        {
            return CheckDAL.GetReckoningID(id);
        }
        /// <summary>
        /// 详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataSet GetStock(string id)
        {
            return CheckDAL.GetStock(id);
        }
        /// <summary>
        /// 显示统计视图
        /// </summary>
        /// <returns></returns>
        public static DataSet GetTotalView()
        {
            return CheckDAL.GetTotalView();
        }
        /// <summary>
        /// 改变商品数量
        /// </summary>
        /// <param name="total"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool UpdateCommodity(string total, string id)
        {
            return CheckDAL.UpdateCommodity(total, id);
        }
        /// <summary>
        /// 日销售额
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSaleTable()
        {
            return CheckDAL.GetSaleTable();
        }
    }
}
