using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class Account_Details : System.Web.UI.Page
{

    clsBusinessLayer myBusinessLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        //create dataset
        dsUser dsUserDetails;

            //pass lastname text to findcustomer method and return results to dataset
            dsUserDetails = myBusinessLayer.fillAccountDetails();

            if (dsUserDetails != null)
            {
                txtUsername.Text = dsUserDetails.tblUsers[0].Username;
                txtCity.Text = dsUserDetails.tblUsers[0].City;  
                txtState.Text = dsUserDetails.tblUsers[0].State;
                txtFavLang.Text = dsUserDetails.tblUsers[0].Favorite_Language;
                txtLeastFav.Text = dsUserDetails.tblUsers[0].Least_Favorite_Language;
                txtLastProgDate.Text = dsUserDetails.tblUsers[0].Last_Program_Date.ToString();
            }

            else
            {
            lblUserFeedback.Text = Session["feedback"].ToString();
            }

    }

    //get input values
    public Label Username
    {
        get { return txtUsername; }
    }

    public Label City
    {
        get { return txtCity; }
    }

    public Label State
    {
        get { return txtState; }
    }

    public Label FavLang
    {
        get { return txtFavLang; }
    }

    public Label LeastFavLang
    {
        get { return txtLeastFav; }
    }
    public Label LastProgDate
    {
        get { return txtLastProgDate; }
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Account Details Confirmation.aspx");
    }

    protected void btnDelete_click(object sender, EventArgs e)
    {
        string results = myBusinessLayer.DeleteUser(Session["username"].ToString());
        //set feedback
        lblUserFeedback.Text = results;

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string results = myBusinessLayer.ExportUser(Session["username"].ToString());
        //set feedback
        lblUserFeedback.Text = results;
    }

}