using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS.Check
{
    public partial class Reckoning_open : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["ReckoningID"]))
                {
                    Not.Text = CheckBLL.GetNotPayment(Request.QueryString["ReckoningID"]).ToString();
                    NowDate.Text = DateTime.Now.Date.ToShortDateString();
                    
                }
            }

        }

        protected void ReckoningBtn_Click(object sender, EventArgs e)
        {
            string PayMent = Not.Text;
            string ManageMan = this.ManageMan.Text;
            string UserName = "admin";
            string ReckoningId = Request.QueryString["ReckoningID"];
            if (CheckBLL.AddReckoning(ReckoningId, PayMent, ManageMan, UserName, NowDate.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('结算成功');opener.location='Reckoning.aspx?Type=" + Request.QueryString["Type"] + "';window.close();</script>");
            }
        }
    }
}