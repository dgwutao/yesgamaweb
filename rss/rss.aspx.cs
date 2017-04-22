using System;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;


public partial class rss_rss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/xml";
        Response.Write(GetRSS());
    }

    /// <summary>
    /// 取得聚合文章
    /// </summary>
    /// <returns></returns>
    public string GetRSS()
    {
        string sqlStr = "select top 50 co.id,co.title,co.time,co.content,ca.category from [content] co,[category] ca where co.cateid=ca.id order by co.id desc";
        DataSet ds = SQLHelper.Query(sqlStr);

        StringBuilder strCode = new StringBuilder();
        strCode.Append("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\" ?>\n");
        strCode.Append("<rss version='2.0'>\n");
        strCode.Append("<channel>\n");
        strCode.Append("<title>Yes!gama Rss订阅，欢迎订阅Yes!gama的信息</title>\n");
        strCode.Append("<link>http://" + Request.ServerVariables["SERVER_NAME"] + "</link> \n");
        strCode.Append("<description>Yes!gama-是一个专注于互联网分享的个人网站，欢迎订阅来自Yes!gama的信息，在这里你可以找到最新的电影电视，和热门的IT新闻。</description>\n ");
        strCode.Append("<language>" + "zh-CN" + "</language>\n");
        strCode.Append("<webMaster>" + "dgwutao@qq.com" + "</webMaster>\n");
        strCode.Append("<copyright>Copyright 2010 by Yes!gama</copyright>\n ");

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            string Id = row["id"].ToString();
            string title = row["title"].ToString();
            string description = Common.CutStr(Common.GetNoHTMLString(row["content"].ToString()), 150);
            DateTime pubdate = (DateTime)row["time"];
            string Category = row["category"].ToString();


            strCode.Append("<item>\n");
            strCode.Append("<title>" + title + "</title>\n");
            strCode.Append("<link>http://" + Request.ServerVariables["SERVER_NAME"] + pubdate.ToString("/yyyy/MM/dd/") + Id + ".html" + "</link>\n");
            strCode.Append("<pubDate>" + Common.DateConvert(pubdate).ToString("r") + "</pubDate>\n");
            strCode.Append("<author>" + "Yes!gama" + "</author>\n");
            strCode.Append("<category>" + Category + "</category>\n");
            strCode.Append("<description><![CDATA[" + description + "]]></description>\n");
            strCode.Append("</item>\n");
        }
        strCode.Append("</channel>\n");
        strCode.Append("</rss>\n");
        return strCode.ToString();
    }
}
