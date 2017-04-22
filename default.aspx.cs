using System;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.Data.OleDb;
using System.Web.UI;
using Wuqi.Webdiyer;
using System.Web.UI.WebControls;
using URLRewriter.Config;


public partial class _Default : System.Web.UI.Page
{
    public string pictxt = null;
    public string linktxt = null;
    public string titletxt = null;
    public string browser = null;
    public string ip = null;
    public string system = null;
    public string constSql = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            activepic();
            userinfo();
            ViewState["sqlRecordCount"] = SQLClass.sqlRecordCountAll;
            ViewState["sqlData"] = SQLClass.sqlDataAll;
            BindPager(ViewState["sqlRecordCount"].ToString(), ViewState["sqlData"].ToString());
        }
    }

    private void activepic()
    {
        string sqlStr = "select top 5 [title],[newspic],[id],[time] from [content] where newspic<>'' order by [id] desc";
        OleDbDataReader dr = SQLHelper.GetDataReader(sqlStr);
        while (dr.Read())
        {
            titletxt += dr[0].ToString() + "|";
            pictxt += dr[1].ToString() + "|";
            linktxt += ((DateTime)dr[3]).ToString("/yyyy/MM/dd/") + dr[2].ToString() + ".html" + "|";
        }
        pictxt = pictxt.Trim().TrimEnd('|');
        dr.Close();
    }

    private void BindPager(string sqlRecordCount, string sqlData)
    {
        aspnetpager.RecordCount = DataPager.RecordCount(sqlRecordCount);
        DataTable dt = DataPager.Pager(sqlData, aspnetpager.CurrentPageIndex, aspnetpager.PageSize);
        rptmain.DataSource = dt;
        rptmain.DataBind();
    }

    protected void lkball_Click(object sender, EventArgs e)
    {
        ViewState["sqlRecordCount"] = SQLClass.sqlRecordCountAll;
        ViewState["sqlData"] = SQLClass.sqlDataAll;
        BindPager(ViewState["sqlRecordCount"].ToString(), ViewState["sqlData"].ToString());
    }

    protected void lkbmovie_Click(object sender, EventArgs e)
    {
        ViewState["sqlRecordCount"] = SQLClass.sqlRecordCountMovie;
        ViewState["sqlData"] = SQLClass.sqlDataMovie;
        BindPager(ViewState["sqlRecordCount"].ToString(), ViewState["sqlData"].ToString());
    }

    protected void lkbit_Click(object sender, EventArgs e)
    {
        ViewState["sqlRecordCount"] = SQLClass.sqlRecordCountIt;
        ViewState["sqlData"] = SQLClass.sqlDataIt;
        BindPager(ViewState["sqlRecordCount"].ToString(), ViewState["sqlData"].ToString());
    }

    protected void PageChanged(object src, EventArgs e)
    {
        BindPager(ViewState["sqlRecordCount"].ToString(), ViewState["sqlData"].ToString());
    }

    public string CutString(object str, int i)
    {
        return Common.CutStr((string)str, i);
    }

    private void userinfo()
    {
        ip = Common.getIP();
        system = Common.getSys();
        switch (system)
        {
            case "Linux":
                imgsystem.ImageUrl = "icon/Linux.jpg";
                break;
            case "Mac OS":
                imgsystem.ImageUrl = "icon/Mac OS.jpg";
                break;
            case "未知":
                imgsystem.ImageUrl = "icon/Windows.gif";
                break;
            default:
                imgsystem.ImageUrl = "icon/Windows.gif";
                break;
        }
        browser = Common.getBroswer();
        if (browser.Contains("IE"))
            imgbrowser.ImageUrl = "icon/IE.png";
        else if (browser.Contains("Firefox"))
            imgbrowser.ImageUrl = "icon/firefox.png";
        else if (browser.Contains("chrome"))
            imgbrowser.ImageUrl = "icon/chrome.png";
        else
            imgbrowser.ImageUrl = "icon/chrome.png";
    }

    public string GetNoHtmlstr(object str)
    {
        return Common.GetNoHTMLString((string)str);
    }

}
