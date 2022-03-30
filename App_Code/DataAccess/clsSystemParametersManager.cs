using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for clsSystemParametersManager
/// </summary>
public class clsSystemParametersManager
{
    public static DataTable Select()
    {
        String strSQL = "SELECT * FROM tblSystemParameters";

        clsDBMS objDBMS = new clsDBMS();

        return objDBMS.ExecuteSelectSQL(strSQL);
    }
}