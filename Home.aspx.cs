using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    clsBusinessLayer myBusinessLayer;
    protected void Page_Load(object sender, EventArgs e)
    {
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));
    }

    public TextBox Username
    {
        get { return txtUsername; }
    }

    public TextBox Password
    {
        get { return txtPassword; }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        lblUserFeedback.Text = myBusinessLayer.LoginUser(txtUsername.Text, txtPassword.Text);     

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        lblUserFeedback.Text = myBusinessLayer.CreateUser(txtUsername.Text, txtPassword.Text);
    }
}
