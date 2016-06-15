using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS.Check
{
    public partial class Stock_Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["sql"] = "";
                Bind();
            }
        }

        void Bind()
        {
            rptStock.DataSource = CheckBLL.GetStockpileView(Session["sql"].ToString());
            rptStock.DataBind();
        }

        protected void rptStock_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField StockId = e.Item.FindControl("StockId") as HiddenField;
            Label StockCount = e.Item.FindControl("StockCount") as Label;
            Label SellCount = e.Item.FindControl("SellCount") as Label;
            Label Stock = e.Item.FindControl("Stock") as Label;
            if (!string.IsNullOrWhiteSpace(StockId.Value))
            {
                StockCount.Text = CheckBLL.StockCount(StockId.Value).ToString();
                SellCount.Text = CheckBLL.SellCount(StockId.Value).ToString();
                Stock.Text = (Convert.ToInt32(StockCount.Text) - Convert.ToInt32(SellCount.Text)).ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (CBCommodityName.Checked)
            {
                sql += " and CommodityName like '%" + Request["txtCommodityName"] + "%' ";
            }
            if (CBCompanyName.Checked)
            {
                sql += " and CompanyName like '%" + Request["txtCompanyName"] + "%' ";
            }
            Session["sql"] = sql;
            Bind();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Session["sql"] = "";
            Bind();
        }


    }
}