using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dgridShowData.DataSource = clsServersManager.SelectPublicData();
            dgridShowData.DataBind();
        }
    }

    protected void dgridProjects_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnRead_Click(object sender, EventArgs e)
    {

    }

    protected void btnDownloadLog_Click(object sender, EventArgs e)
    {

    }

    protected void dgridShowData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {

    }
}