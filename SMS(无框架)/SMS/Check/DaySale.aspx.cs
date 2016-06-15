﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMS.Check
{
    public partial class DaySale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }

        }

        void Bind()
        {
            rptDaySale.DataSource = CheckBLL.GetSaleTable();
            rptDaySale.DataBind();
        }
    }
}