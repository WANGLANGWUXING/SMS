using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SMS.Check
{
    /// <summary>
    /// DaySaleData 的摘要说明
    /// </summary>
    public class DaySaleData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //页码
            string page = context.Request["page"];
            //页面大小
            string rows = context.Request["rows"];
            DataTable dt = CheckBLL.GetSaleTable(rows, page);
            int count = CheckBLL.CountDaySale();
            object obj = new { total = count, rows = dt };
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