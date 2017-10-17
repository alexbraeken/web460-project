using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Details_Confirmation : System.Web.UI.Page
{

    clsBusinessLayer myBusinessLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        try
        {
            if (PreviousPage.IsCrossPagePostBack)
            {
                txtCity.Text = PreviousPage.City.Text;
                txtState.Text = PreviousPage.State.Text;
                txtFavLang.Text = PreviousPage.FavLang.Text;
                txtLeastFavLang.Text = PreviousPage.LeastFavLang.Text;
                calLastProgDate.SelectedDate = Convert.ToDateTime(PreviousPage.LastProgDate.Text);
            }
            else
            {
                txtCity.Text = "";
                txtState.Text = "";
                txtFavLang.Text = "";
                txtLeastFavLang.Text = "";
                calLastProgDate.SelectedDate = Convert.ToDateTime("");
            }
        }
        catch (Exception error)
        {
            lblUserFeedback.Text = error.ToString();
        }
        finally
        {
            Username.Text = Session["username"].ToString();
        }

    }

    //get input values
    public Label Username
    {
        get { return lblUsername; }
    }

    public TextBox City
    {
        get { return txtCity; }
    }

    public TextBox State
    {
        get { return txtState; }
    }

    public TextBox FavLang
    {
        get { return txtFavLang; }
    }

    public TextBox LeastFavLang
    {
        get { return txtLeastFavLang; }
    }
    public Calendar LastProgDate
    {
        get { return calLastProgDate; }
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        string results = myBusinessLayer.UpdateUser(Session["username"].ToString(), City.Text, State.Text, FavLang.Text, LeastFavLang.Text, LastProgDate.SelectedDate);
        //set error to false
        lblUserFeedback.Text = results;
    }

    protected void btnDelete_click(object sender, EventArgs e)
    {

        string results = myBusinessLayer.DeleteUser(Session["username"].ToString());
        //set error to false
        lblUserFeedback.Text = results;
    }
  }
