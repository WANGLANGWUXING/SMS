using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SMS.Check
{
    public class RankModel
    {
        public int RankNum { get; set; }
        public string CommodityName { get; set; }
        public string CompanyName { get; set; }
        public int id { get; set; }
        public string Unit { get; set; }
        public int TotalCount { get; set; }
    }
    /// <summary>
    /// RankData 的摘要说明
    /// </summary>
    public class RankData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //页码
            string page = context.Request["page"];
            //页面大小
            string rows = context.Request["rows"];
            DataTable dt = CheckBLL.GetTotalView(rows, page).Tables[0];
            int count = CheckBLL.CountTotal();
            List<RankModel> RankModelList = new List<RankModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RankModel RankModel = new RankModel();
                    RankModel.RankNum = i + 1;
                    RankModel.CommodityName = dt.Rows[i]["CommodityName"].ToString();
                    RankModel.CompanyName = dt.Rows[i]["CompanyName"].ToString();
                    RankModel.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                    RankModel.Unit = dt.Rows[i]["Unit"].ToString();
                    RankModel.TotalCount = CheckBLL.SellCount(RankModel.id.ToString());
                    CheckBLL.UpdateCommodity(RankModel.TotalCount.ToString(), RankModel.id.ToString());
                    RankModelList.Add(RankModel);
                }
            }
            object obj = new { total = count, rows = RankModelList };
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