using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SMS.Check
{
    public class ReckoningModel
    {
        public string Type { get; set; }
        public string CommodityName { get; set; }
        public string CompanyName { get; set; }
        public int NotPayment { get; set; }
        public int Count { get; set; }
        public string ReckoningID { get; set; }
        public int id { get; set; }
        public string IsCheck { get; set; }
    }
    /// <summary>
    /// ReckoningData 的摘要说明
    /// </summary>
    public class ReckoningData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Type = context.Request["type"];
            //页码
            string page = context.Request["page"];
            //页面大小
            string rows = context.Request["rows"];
            if (string.IsNullOrWhiteSpace(Type))
            {
                Type = "进货信息";
            } 
            int count = CheckBLL.CountReckoning(Type);
            DataTable dt = CheckBLL.GetReckoningView(Type, rows, page).Tables[0];
            List<ReckoningModel> ReckoningModelList = new List<ReckoningModel>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ReckoningModel ReckoningModel = new ReckoningModel();
                    ReckoningModel.Type = dt.Rows[i]["Type"].ToString();
                    ReckoningModel.CommodityName = dt.Rows[i]["CommodityName"].ToString();
                    ReckoningModel.CompanyName = dt.Rows[i]["CompanyName"].ToString();
                    string id = dt.Rows[i]["id"].ToString();
                    ReckoningModel.id = Convert.ToInt32(id);
                    ReckoningModel.NotPayment = CheckBLL.GetNotPayment(id);
                    ReckoningModel.Count = CheckBLL.Count(id);
                    ReckoningModel.ReckoningID = CheckBLL.GetReckoningID(id);
                    if (ReckoningModel.NotPayment == 0)
                    {
                        ReckoningModel.IsCheck = "已结算";
                    }
                    else
                    {
                        ReckoningModel.IsCheck = "结算";

                    }
                    ReckoningModelList.Add(ReckoningModel);
                }
            }
            object obj = new { total = count, rows = ReckoningModelList };
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