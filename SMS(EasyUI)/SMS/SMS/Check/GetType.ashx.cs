using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SMS.Check
{

    public class TypeData
    {
        public int id { get; set; }
        public string type { get; set; }
    }
    /// <summary>
    /// GetType 的摘要说明
    /// </summary>
    public class GetType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DataTable dt = CheckBLL.GetType();
            List<TypeData> TypeDataList = new List<TypeData>();

            if (dt != null && dt.Rows.Count>0) {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TypeData TypeData = new TypeData();
                    TypeData.id = i;
                    TypeData.type = dt.Rows[i]["type"].ToString();
                    TypeDataList.Add(TypeData);
                }
            }
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(TypeDataList));

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