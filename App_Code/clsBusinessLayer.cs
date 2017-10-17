using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsBusinessLayer
/// </summary>
public class clsBusinessLayer
{

    clsDataLayer myDataLayer;
    public clsBusinessLayer(string dataPath)
    {
        myDataLayer = new clsDataLayer(dataPath + "Course_Project.mdb");
    }

    public string UpdateUser(string username, string City, string State, string FavLang, string LeastFavLang, DateTime LastProgDate)
    {
        bool userUpdateError = false;
        string message = "";
        //try catch block update customer
        try
        {
            myDataLayer.UpdateUser(username, City, State, FavLang, LeastFavLang, LastProgDate);

        }
        catch (Exception error)
        {
            userUpdateError = true;
            message = "Error update user, please check form data. ";
            return message + error;

        }

        if (!userUpdateError)
        {
            HttpContext.Current.Response.Redirect("Account Details.aspx");
        }
        return message;
    }
    public string DeleteUser(string username)
    {
        string message = "";
        bool userDeleteError = false;
        try
        {
            myDataLayer.deleteUser(username);
        }
        catch (Exception error)
        {
            userDeleteError = true;
            message = "Error deleting user. ";
            return message + error;
        }
        if (!userDeleteError)
        {
            HttpContext.Current.Session["username"] = "";
            HttpContext.Current.Session["password"] = "";
            HttpContext.Current.Response.Redirect("Home.aspx");
        }
        return message;
    }

    public string ExportUser(string username)
    {
        string message = "";
        bool userExportError = false;
        try
        {
            myDataLayer.exportUser(username, HttpContext.Current.Server.MapPath("~/App_Data/"));
        }
        catch (Exception error)
        {
            userExportError = true;
            message = "Error Exporting to XML file. ";
            return message + error;
        }
        if (!userExportError)
        {
            message = "Succesfully Exported to XML file.";
        }
        return message;
    }

    public string LoginUser(string txtUsername, string txtPassword)
    {
        string message = "";
        // Declare userlogin of userdataset type
        dsUser dsUserLogin;

        dsUserLogin = myDataLayer.VerifyUser(txtUsername, txtPassword);

        // If less than 1 no matches found
        if (dsUserLogin.tblUsers.Count < 1)
        {

            message = "Incorrect Username or Password.";
            return message;
        }
        else
        {
            HttpContext.Current.Session["username"] = txtUsername;

            HttpContext.Current.Response.Redirect("Account Details.aspx");
            return message;
        }
    }

    public string CreateUser(string txtUsername, string txtPassword)
    {
        bool userAddError = false;
        string message = "";
        //try catch block add user
        try
        {
            //call datalayer class insertcustomer method
            myDataLayer.AddUser(txtUsername, txtPassword);

        }
        catch (Exception error)
        {
            //set error to true and update feedback text message
            userAddError = true;
            message = "Error adding customer, please check form data. " + error.Message;
            return message;
        }

        if (!userAddError)
        {
            HttpContext.Current.Session["username"] = txtUsername;
            HttpContext.Current.Session["password"] = txtPassword;
            HttpContext.Current.Response.Redirect("Account Details Confirmation.aspx");
        }
        return message;
    }

    public dsUser fillAccountDetails()
    {

        //create dataset
        dsUser dsUserDetails;

        try
        {
            //pass lastname text to findcustomer method and return results to dataset
            dsUserDetails = myDataLayer.UserDetails(HttpContext.Current.Session["username"].ToString());

            if (dsUserDetails.tblUsers.Rows.Count > 0)
            {
    
                foreach ( DataRow row in dsUserDetails.tblUsers.Rows)
                {
                    if (DBNull.Value.Equals(row["City"])){
                        row["City"] = "";
                    }
                    if (DBNull.Value.Equals(row["State"]))
                    {
                        row["State"] = "";
                    }
                    if (DBNull.Value.Equals(row["Favorite_Language"]))
                    {
                        row["Favorite_Language"] = "";
                    }
                    if (DBNull.Value.Equals(row["Least_Favorite_Language"]))
                    {
                        row["Least_Favorite_Language"] = "";
                    }
                    if (DBNull.Value.Equals(row["Last_Program_Date"]))
                    {
                        row["Last_Program_Date"] = DateTime.MinValue;
                    }
                }
                return dsUserDetails;
            }

            else
            {
                //Set feedback text to no records found
                HttpContext.Current.Response.Redirect("Account Details Confirmation.aspx");
                return null;
            }
        }
        catch (Exception error)
        {
            //feedback text displays catch error
            string message = "Something went wrong - ";
            HttpContext.Current.Session["feedback"] = message + error.Message;
            return null;
        }
    }

    public string searchUser(string searchText)
    {
        dsUser dsUserSearch;

        string message = "";
        dsUserSearch = myDataLayer.SearchUser(searchText);

        if (dsUserSearch.tblUsers.Count < 1)
        {
            message = "No User found";
            return message;
        }
        else
        {
            HttpContext.Current.Session["username"] = dsUserSearch.tblUsers[0].Username;
            HttpContext.Current.Response.Redirect("Account Details.aspx");
            return null;
        }
    }
}