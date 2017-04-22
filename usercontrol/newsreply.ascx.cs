using System;
using System.Data;
using System.Web;
using System.Data.OleDb;

public partial class usercontrol_newsreply : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindnewsreply();
    }
    private void bindnewsreply()
    {
        string sqlStr = "select top 15 re.contentid,re.reply,re.ip,re.[time],co.title,co.id from [reply] re,[content] co where re.contentid=co.id order by re.time desc";
        OleDbDataReader dr = SQLHelper.GetDataReader(sqlStr);
        if (dr.HasRows)
        {
            rptnewsreply.DataSource = dr;
            rptnewsreply.DataBind();
        }
        dr.Close();
    }
    public string Convertdate2view(string date)
    {
        return Common.ConvertDateTimeView(date);
    }
}
