using System;
using System.Data;

/// <summary>
/// Summary description for clsServersManager
/// </summary>
public class clsServersManager
{
    public static DataTable SelectFullData()
    {
        String strSQL = "EXEC dbo.xp_SelectServers";

        clsDBMS objDBMS = new clsDBMS();

        return objDBMS.ExecuteSelectSQL(strSQL);
    }

    public static DataTable SelectPublicData()
    {
        String strSQL = "EXEC dbo.xp_SelectServersFromviwPublicData";

        clsDBMS objDBMS = new clsDBMS();

        return objDBMS.ExecuteSelectSQL(strSQL);
    }

    public static DataTable SelectServersByID(String strID)
    {
        String strSQL = "EXEC dbo.xp_SelectServersByID " + strID + "";

        clsDBMS objDBMS = new clsDBMS();

        return objDBMS.ExecuteSelectSQL(strSQL);
    }
}