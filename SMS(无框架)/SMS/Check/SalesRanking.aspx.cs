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
    public partial class SalesRanking : System.Web.UI.Page
    {
        protected int num = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            rptRanking.DataSource = CheckBLL.GetTotalView();
            rptRanking.DataBind();
        }

        protected void rptRanking_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField TotalId = e.Item.FindControl("TotalId") as HiddenField;
            Label total = e.Item.FindControl("total") as Label;
            Label RankingID = e.Item.FindControl("RankingID") as Label;
            if (!string.IsNullOrWhiteSpace(TotalId.Value))
            {
                total.Text = CheckBLL.SellCount(TotalId.Value).ToString();
                CheckBLL.UpdateCommodity(total.Text, TotalId.Value);
                num++;
                RankingID.Text = num.ToString();
            }
        }
    }
}