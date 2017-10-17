using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsDataLayer
/// </summary>
public class clsDataLayer
{

    OleDbConnection dbConnection;

    public clsDataLayer(string Path)
    {
        dbConnection = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path);
    }
    public dsUser VerifyUser(string UserName, string UserPassword)
    {
        // declare new User dataset
        dsUser DS;
        OleDbDataAdapter sqlDA;
        // Create adapter
        sqlDA = new OleDbDataAdapter("Select * FROM tblUsers WHERE Username LIKE '" + UserName + "' " +
        "and Password LIKE '" + UserPassword + "'", dbConnection);
        // initialize new user dataset
        DS = new dsUser();
        // Fill dataset with userlogin table data
        sqlDA.Fill(DS.tblUsers);
        // Return filled dataset
        return DS;
    }

    public dsUser SearchUser(string username)
    {
        // declare new User dataset
        dsUser DS;
        OleDbDataAdapter sqlDA;
        // Create adapter
        sqlDA = new OleDbDataAdapter("Select Username from tblUsers WHERE Username LIKE '" + username + "'", dbConnection);
        // initialize new user dataset
        DS = new dsUser();
        // Fill dataset with userlogin table data
        sqlDA.Fill(DS.tblUsers);
        // Return filled dataset
        return DS;
    }

    public void UpdateUser(string username, string city, string state, string favLang, string leastFavLang, DateTime lastProgDate )
    {

        //open db connection
        dbConnection.Open();

        //create sql query
        string sqlStmt = "UPDATE tblUsers SET City = @city, " + "State = @state, " + "Favorite_Language = @favLang, " + "Least_Favorite_Language = @leastFavLang, " + "Last_Program_Date = @lastProgDate " + "WHERE (tblUsers.Username = @username)";

        //Store sql statement
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        //set query parameters
        OleDbParameter param = new OleDbParameter("@city", city);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@state", state));
        dbCommand.Parameters.Add(new OleDbParameter("@favLang", favLang));
        dbCommand.Parameters.Add(new OleDbParameter("@leastFavLang", leastFavLang));
        dbCommand.Parameters.Add(new OleDbParameter("@lastProgDate", lastProgDate));
        dbCommand.Parameters.Add(new OleDbParameter("@id", username));

        //execute statement
        dbCommand.ExecuteNonQuery();

        //close connection
        dbConnection.Close();
    }

    public void AddUser(string username, string password)
    {
        //open db connection
        dbConnection.Open();

        //create sql statement
        string sqlStmt = "INSERT INTO tblUsers ([Username], [Password]) VALUES (@username, @password)";

        //store sql statement
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        //set query parameters
        OleDbParameter param = new OleDbParameter("@username", username);
        dbCommand.Parameters.Add(param);
        dbCommand.Parameters.Add(new OleDbParameter("@password", password));
        
        //execute query
        dbCommand.ExecuteNonQuery();

        //close connection
        dbConnection.Close();
    }

    public dsUser UserDetails(string Username)
    {
        //sql query
        string sqlStmt = "SELECT * FROM tblUsers WHERE Username LIKE '" + Username + "'";

        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        //create and fill dataset
        dsUser userDataSet = new dsUser();
        sqlDataAdapter.Fill(userDataSet.tblUsers);

        //return filled dataset
        return userDataSet;
    }

    public void deleteUser (string username)
    {
        dbConnection.Open();
        string sqlStmt = "DELETE FROM tblUsers WHERE Username = @username";

        try
        {
            OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);
            dbCommand.Parameters.Add(new OleDbParameter("@username", username));

            dbCommand.ExecuteNonQuery();
        }
        catch(Exception error)
        {
            Console.WriteLine(error);
            dbConnection.Close();
        }
        finally
        {
            dbConnection.Close();
        }
    }

    public void exportUser(string username, string datapath)
    {
        string sqlStmt = "SELECT * FROM tblApplications WHERE Username = '" + username + "'";
        //new adapter
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter( sqlStmt , dbConnection);
        //new dataset
        dsApplications myApplicationsDataSet = new dsApplications();
        
        sqlDataAdapter.Fill(myApplicationsDataSet.tblApplications);

        myApplicationsDataSet.WriteXml(datapath + username + ".xml");

    }

}
