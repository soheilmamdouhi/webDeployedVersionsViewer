using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;

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
        String strCommandToExecute = "";
        String strOutputFileName = Guid.NewGuid().ToString() + ".tmp";
        String strOutputFileContent;
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

        string[] splitted = strOutputFileContent.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        File.Delete(@"E:\Weblogic\" + strOutputFileName);
    }










    //DataTable objDataTable = new DataTable();

    //objDataTable = clsServersDataManager.SelectServer(dgridShowData.SelectedRow.Cells[1].Text);

    //    stringArr = objDataTable.Rows[0].ItemArray.Select(arrServer => arrServer.ToString()).ToArray();

    //    using (var ssh = new SshClient(stringArr[2], stringArr[5], stringArr[6]))
    //    {
    //        ssh.Connect();

    //        lblTemp.Text = ssh.CreateCommand("wc -l " + stringArr[3] + " | awk '{print $1}'").Execute();

    //        ssh.Disconnect();
    //    }

    //    lblIDData.Text = dgridShowData.SelectedRow.Cells[1].Text;
    //    lblServerNameData.Text = dgridShowData.SelectedRow.Cells[2].Text;
    //    lblIPAddressData.Text = dgridShowData.SelectedRow.Cells[3].Text;

    //    btnRead.Enabled = true;
    //    btnDownloadFull.Enabled = true;
    //    btnDownloadLog.Enabled = false;
    //    lblStatus.Text = "Set";
    //    lblStatus.ForeColor = System.Drawing.Color.Green;

    //    lblMessageData01.Text = "";
    //    lblMessageData02.Text = "";
    //    txtOutput.Text = "";


}