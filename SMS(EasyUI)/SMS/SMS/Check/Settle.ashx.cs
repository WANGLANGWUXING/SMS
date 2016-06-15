using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Check
{
    /// <summary>
    /// Settle 的摘要说明
    /// </summary>
    public class Settle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
        
            string UserName = "admin";
            string PayMent = context.Request["NotPayment"];
            string ManageMan = context.Request["ManageMan"];
            string NowData = context.Request["NowData"];
            string CommodityId = context.Request["CommodityId"];
            if (CheckBLL.AddReckoning(CommodityId, PayMent, ManageMan, UserName, NowData))
            {
                context.Response.Write("ok");
            }
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