using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class clsDBMS
{
    SqlConnection objSqlConnection;
    SqlCommand objSqlCommand;

    public clsDBMS()
    {
        objSqlConnection = new SqlConnection();
        objSqlCommand = new SqlCommand();

        objSqlCommand.Connection = objSqlConnection;
        objSqlConnection.ConnectionString = "Server = 192.9.200.108; Database = dbDeployedVersionsViewer; User Id = dvvuser; Password = dvvuser;";
        //objSqlConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LogViewerDS"].ConnectionString;
    }

    public void ExecuteSQL(String strSQL)
    {
        try
        {
            objSqlCommand.CommandText = strSQL;

            objSqlConnection.Open();
            objSqlCommand.ExecuteNonQuery();
            objSqlConnection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
        }
    }

    public DataTable ExecuteSelectSQL(String strSQL)
    {
        try
        {
            objSqlCommand.CommandText = strSQL;

            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
            DataTable objDataTable = new DataTable();

            objSqlDataAdapter.Fill(objDataTable);

            return objDataTable;
        }
        catch (Exception ex)
        {
            throw new Exception(clsUtilities.GetErr(ex.Message.ToString()));
        }
    }
}