using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SMS.Check
{
    public class StockModel
    {
        public string CommodityName { get; set; }
        public string CompanyName { get; set; }
        public string Unit { get; set; }
        public int id { get; set; }
        public int StockCount { get; set; }
        public int SellCount { get; set; }
        public int Stock { get; set; }


    }
    /// <summary>
    /// StockData 的摘要说明
    /// </summary>
    public class StockData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string sql = "";
            //页码
            string page = context.Request["page"];
            //页面大小
            string rows = context.Request["rows"];
            string CommodityName = context.Request["CommodityName"];
            string CompanyName = context.Request["CompanyName"];
            if (!string.IsNullOrWhiteSpace(CommodityName))
            {
                sql += " and CommodityName like '%" + CommodityName + "%' ";
            }
            if (!string.IsNullOrWhiteSpace(CompanyName))
            {
                sql += " and CompanyName like '%" + CompanyName + "%' ";
            }
            List<StockModel> StockModelList = new List<StockModel>();
            //string sql = context.Request["sql"];
            DataTable dt = CheckBLL.GetStockpileView(sql, rows, page).Tables[0];
            int count = CheckBLL.CountStockpile();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StockModel StockModel = new StockModel();
                    StockModel.CommodityName = dt.Rows[i]["CommodityName"].ToString();
                    StockModel.CompanyName = dt.Rows[i]["CompanyName"].ToString();
                    StockModel.Unit = dt.Rows[i]["Unit"].ToString();
                    StockModel.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                    StockModel.StockCount = CheckBLL.StockCount(StockModel.id.ToString());
                    StockModel.SellCount = CheckBLL.SellCount(StockModel.id.ToString());
                    StockModel.Stock = StockModel.StockCount - StockModel.SellCount;
                    StockModelList.Add(StockModel);
                }
            }
            object obj = new { total = count, rows = StockModelList };
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}