using System;
using System.Data;
using System.Web;
using System.Data.OleDb;

public partial class usercontrol_newshot : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindhot();
        }
    }
    private void bindhot()
    {
        string sqlStr = "select top 10 id,title,readcount,time from content order by readcount desc";
        OleDbDataReader dr = SQLHelper.GetDataReader(sqlStr);
        rpthot.DataSource = dr;
        rpthot.DataBind();
        dr.Close();
    }
}
