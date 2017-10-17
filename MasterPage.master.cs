using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    clsBusinessLayer myBusinessLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblSearchFeedback.Text=myBusinessLayer.searchUser(txtSearch.Text);
    }
}
