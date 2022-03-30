using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for clsIgnoreListManager
/// </summary>
public class clsIgnoreListManager
{
    public static DataTable Select()
    {
        String strSQL = "SELECT * FROM tblIgnoreList";

        clsDBMS objDBMS = new clsDBMS();

        return objDBMS.ExecuteSelectSQL(strSQL);
    }

    public static DataTable Search_tblIgnoreList(String strValue)
    {
        String strSQL = "SELECT * FROM tblIgnoreList WHERE value LIKE '%" + strValue + "%'";

        clsDBMS objDBMS = new clsDBMS();

        return objDBMS.ExecuteSelectSQL(strSQL);
    }
}