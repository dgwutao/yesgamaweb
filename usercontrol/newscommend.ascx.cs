using System;
using System.Web;
using System.Data;
using System.Data.OleDb;

public partial class usercontrol_newscommend : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindcommend();
        }
    }
    private void bindcommend()
    {
        string sqlStr = "select top 10 id,title,readcount,[time] from content where commend=1 order by id desc";
        OleDbDataReader dr = SQLHelper.GetDataReader(sqlStr);
        rptcommend.DataSource = dr;
        rptcommend.DataBind();
        dr.Close();
    }
}
