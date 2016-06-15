using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS.Check
{
    public partial class Stock_open : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request["ReckoningID"]))
                {
                    string id = Request["ReckoningID"];
                    ReceiptsId.Text = CheckBLL.GetReckoningID(id).ToString();
                    DataTable dt = CheckBLL.GetStock(id).Tables[0];
                    CommodityName.Text = dt.Rows[0]["CommodityName"].ToString();
                    CompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    Type.Text = dt.Rows[0]["Type"].ToString();
                    Number.Text = dt.Rows[0]["Number"].ToString();
                    Pirce.Text = dt.Rows[0]["Pirce"].ToString();
                    StockDate.Text = Convert.ToDateTime(dt.Rows[0]["StockDate"].ToString()).ToShortDateString();
                    ManageMan.Text = dt.Rows[0]["ManageMan"].ToString();
                    SettlementType.Text = dt.Rows[0]["SettlementType"].ToString();
                    Username.Text = dt.Rows[0]["Username"].ToString();
                    AddTime.Text = dt.Rows[0]["AddTime"].ToString();
                    Total.Text = (Convert.ToInt32(Number.Text) * Convert.ToInt32(Pirce.Text)).ToString();
                }
            }
        }
    }
}