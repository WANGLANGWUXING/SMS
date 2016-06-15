using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS.Check
{
    public partial class Reckoning : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string typestr = "进货结算";
                if (!string.IsNullOrWhiteSpace(Request.QueryString["Type"]))
                {
                    typestr = Request.QueryString["Type"];
                }
                if (typestr == "进货结算")
                {
                    stockbtn.Enabled = false;
                    returnbtn.Enabled = true;
                    typestr = "进货信息";
                }
                else
                {
                    stockbtn.Enabled = true;
                    returnbtn.Enabled = false;
                    typestr = "进货退货";
                }
                dataBind(typestr);
            }
        }

        void dataBind(string type)
        {
            rptReckoning.DataSource = CheckBLL.GetReckoningView(type);
            rptReckoning.DataBind();
        }

        protected void rptReckoning_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField ReckoningID = e.Item.FindControl("ReckoningID") as HiddenField;
            Label ReckoningNot = e.Item.FindControl("ReckoningNot") as Label;
            Label ReckoningCount = e.Item.FindControl("ReckoningCount") as Label;
            LinkButton ReceiptsId = e.Item.FindControl("ReceiptsId") as LinkButton;
            if (!string.IsNullOrWhiteSpace(ReckoningID.Value))
            {
                ReckoningNot.Text = CheckBLL.GetNotPayment(ReckoningID.Value).ToString();
                LinkButton btnReckoning = e.Item.FindControl("btnReckoning") as LinkButton;
                if (ReckoningNot.Text == "0")
                {
                    ReckoningNot.Text = "<font color='red'>已结款</font>";
                    btnReckoning.Enabled = false;
                    btnReckoning.Text = "已结账";
                }
                else
                {
                    btnReckoning.Attributes.Add("onclick", "window.open('Reckoning_open.aspx?ReckoningID=" + ReckoningID.Value + "','','width=500,height=500,scrollbars=yes')");// .PostBackUrl = "Reckoning_open.aspx?ReckoningID=" + ReckoningID.Value;
                }
                ReckoningCount.Text = CheckBLL.Count(ReckoningID.Value).ToString();
                ReceiptsId.Text = CheckBLL.GetReckoningID(ReckoningID.Value).ToString();
                ReceiptsId.PostBackUrl = "Stock_open.aspx?ReckoningID=" + ReckoningID.Value;
            }

        }

        protected void stockbtn_Click(object sender, EventArgs e)
        {
            stockbtn.Enabled = false;
            returnbtn.Enabled = true;
            string typestr = "进货信息";
            dataBind(typestr);
            type.Text = "进货信息结算";
        }

        protected void returnbtn_Click(object sender, EventArgs e)
        {
            stockbtn.Enabled = true;
            returnbtn.Enabled = false;
            string typestr = "进货退货";
            dataBind(typestr);
            type.Text = "进货退货结算";
        }
    }
}