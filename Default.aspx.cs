﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections;

public partial class _Default : Page
{
    public String strWeblogic11gJarPath = @"E:\Weblogic\Weblogic11g\wlserver_10.3\server\lib\weblogic.jar";
    public String strWeblogic12cJarPath = @"E:\Weblogic\Weblogic12c\wlserver\server\lib\weblogic.jar";
    public String strJythonFilespath = @"E:\Weblogic\RetriveAppsVersions.py";
    public String[] stringArr = new String[5];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dgridShowData.DataSource = clsServersManager.SelectPublicData();
            dgridShowData.DataBind();
        }
    }

    protected void dgridShowData_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable objDataTable = new DataTable();
        Dictionary<string, string> dictAppsAndVersions = new Dictionary<string, string>();
        String strCommandToExecute = "";
        String strOutputFileName = Guid.NewGuid().ToString() + ".tmp";
        String strOutputFileContent;
        String strName;
        String strVersion;
        String strTemp;
        
        objDataTable = clsServersManager.SelectServersByID(dgridShowData.SelectedRow.Cells[1].Text);

        stringArr = objDataTable.Rows[0].ItemArray.Select(arrServer => arrServer.ToString()).ToArray();

        if (stringArr[6] == "11g")
        {
            strCommandToExecute = "/C java -classpath " + strWeblogic11gJarPath + " weblogic.WLST " + strJythonFilespath + " " + stringArr[4] + " " + stringArr[5] + " t3://" + stringArr[2] + ":" + stringArr[3] + @" > E:\Weblogic\" + strOutputFileName;
            Process.Start("cmd.exe", strCommandToExecute);
        }
        else
        {
            strCommandToExecute = "/C java -classpath " + strWeblogic12cJarPath + " weblogic.WLST " + strJythonFilespath + " " + stringArr[4] + " " + stringArr[5] + " t3://" + stringArr[2] + ":" + stringArr[3] + @" > E:\Weblogic\" + strOutputFileName;
            Process.Start("cmd.exe", strCommandToExecute);
        }

        Thread.Sleep(30000);

        strOutputFileContent = File.ReadAllText(@"E:\Weblogic\" + strOutputFileName);
        strOutputFileContent = strOutputFileContent.Remove(0, strOutputFileContent.IndexOf("["));

        File.Delete(@"E:\Weblogic\" + strOutputFileName);

        string[] arrDeployedAppLib = strOutputFileContent.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        int intLength = arrDeployedAppLib.Length;

        //dictAppsAndVersions.Add("Application or Library name", "Version");

        for (int intCounter = 0; intCounter < intLength; intCounter++)
        {
            strTemp = arrDeployedAppLib[intCounter];

            strTemp = strTemp.Remove(0, 43);

            //strTemp = strTemp.Split('=')[1];
            if (strTemp.Contains('#'))
            {
                //isVersioned = True
                if (strTemp.Contains('@'))
                {
                    //isLibrary = True
                    //isApplication = False
                    strName = strTemp.Split('#')[0];
                    strTemp = strTemp.Remove(0, strTemp.IndexOf('#') + 1);
                    strVersion = strTemp.Split('@')[0];
                }
                else
                {
                    //isLibrary = False
                    //isApplication = True
                    strName = strTemp.Split('#')[0];
                    strTemp = strTemp.Remove(0, strTemp.IndexOf('#') + 1);
                    strVersion = strTemp.Split(',')[0];
                }
            }
            else
            {
                //isVersioned = False
                strName = strTemp.Split(',')[0];
                strVersion = "";
            }

            if (!clsIgnoreListManager.isInIgnoreList(strName))
            {
                dictAppsAndVersions.Add(strName, strVersion);
            }
        }

        dgridShowVersions.DataSource = dictAppsAndVersions;
        dgridShowVersions.DataBind();

        //dgridShowVersions.Columns[0].HeaderText = "Application or Library name";
        //dgridShowVersions.Columns[1].HeaderText = "Version";
    }
}