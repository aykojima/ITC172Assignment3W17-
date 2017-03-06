using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; //general data tools
using System.Data.SqlClient; //sql server data tools
using System.Configuration; //tools for talking to config file

/// <summary>
/// Summary description for LoginClass
/// </summary>
public class LoginClass
{
    //set up the class level variables
    //declare the sqlconnection object
    SqlConnection connect;
    string Email;
    string pass;
    public LoginClass(string emailAddress, string password)
    {
        //assign names
        Email = emailAddress;
        pass = password;
        //initialize the connection string and connection object
        string connectString = 
            ConfigurationManager.ConnectionStrings["Community_AssistConnection"].ToString();
        connect = new SqlConnection(connectString);
    }

    public int ValidateLogin()
    {
        //declare command
        SqlCommand cmd = new SqlCommand();
        //set up the command properties
        cmd.Connection = connect;
        //we are using a stored procedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "usp_Login";
        //assign values to the stored procedure parameters
        cmd.Parameters.AddWithValue("@Email", Email);//Starter file had @ReviewerUserName
        cmd.Parameters.AddWithValue("@password", pass); //Starter file had @ReviewerPassword
        //open connection
        connect.Open();
        //execute the stored procedure
        //it returns a -1 or 0
        int result = cmd.ExecuteNonQuery();
        //close connection
        connect.Close();
        int key = 0;
        //if it is good then call the GetUserKey method and assign
        //the userkey
        if(result != -1)
        {
            key = GetUserKey();
        }
        return result;
    }

    private int GetUserKey()
    {
        //this method is called only if the 
        //stored procedure has validated the user
        //it returns the user key
        string sql = "Select PersonKey from Person where PersonEmail =@Emai";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@Email", Email);
        SqlDataReader reader = null;
        connect.Open();
        reader = cmd.ExecuteReader();
        int key = 0;
        while (reader.Read())
        {
             key= (int)reader["PersonKey"];
        }
        connect.Close();


        return key;
    }
}