using System;
using System.Data;
using System.Data.OleDb;
using System.Web;


public partial class usercontrol_topnews : System.Web.UI.UserControl
{
    public string title = null;
    public string content = null;
    public int id;
    public string stime = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindtopnews();
        }
    }

    private void bindtopnews()
    {
        string sqlStr = "select top 7 co.[id],co.[title],co.[time],co.[content],co.readcount from [content] co where settop=1 order by co.id desc";
        OleDbDataReader dr = SQLHelper.GetDataReader(sqlStr);
        if (dr.Read())
        {
            id = int.Parse(dr[0].ToString());
            title = dr[1].ToString();
            stime = dr[2].ToString();
            content = Common.CutStr(Common.GetNoHTMLString(dr[3].ToString()), 320);
            rpttopnews.DataSource = dr;
            rpttopnews.DataBind();
        }
        dr.Close();
    }
}
