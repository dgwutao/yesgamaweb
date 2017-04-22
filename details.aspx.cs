using System;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using URLRewriter.Config;


public partial class details : RefreshServe
{
    public string content = null;
    public string title = null;
    public string readcount = null;
    public string reply = null;
    public string publisher = null;
    public string time = null;
    public string uparticle = null;
    public string downarticle = null;
    public string uptime = null;
    public string downtime = null;
    public int uparticleid;
    public int downarticleid;

    WordFilter wf = new WordFilter();

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"].ToString();
        Common.countPv(id);
        bindcontent();
        getUpdown();
    }
    private void bindcontent()
    {
        try
        {
            string id = Request.QueryString["id"].ToString();
            string sqlStr = "select co.[title],co.[content],co.[publisher],co.[readcount],co.[time]  from [content] co where co.id=@id";
            string sql = "select count(re.id) as [count] from [reply] re where re.contentid=@id";
            OleDbParameter[] param = {
                 ParamHelper.MakeInParam("@id",OleDbType.VarWChar,id)
                                     };
            OleDbDataReader dr = SQLHelper.GetDataReader(sqlStr, param);
            if (dr.Read())
            {
                title = dr[0].ToString();
                content = dr[1].ToString();
                publisher = dr[2].ToString();
                readcount = dr[3].ToString();
                time = dr[4].ToString();
            }
            else
            {
                Response.Redirect("error.aspx");
            }
            dr.Close();
            string replynum = SQLHelper.ExecuteScalar(sql, param).ToString();
            if (!string.IsNullOrEmpty(replynum))
            {
                reply = replynum;
            }
        }
        catch
        {
            Response.Redirect("error.aspx");
        }
    }

    private void getUpdown()
    {
        int id = int.Parse(Request.QueryString["id"].ToString());
        string preSql = "select co.[id],co.[title],co.[time] from [content] co where co.id = (select MAX(id) from [content] where id<@id)";
        OleDbParameter[] param = {
                                     ParamHelper.MakeInParam("@id",OleDbType.Integer,id)
                                 };
        OleDbDataReader drup = SQLHelper.GetDataReader(preSql, param);
        if (drup.Read())
        {
            uptime = Convert.ToDateTime(drup[2].ToString()).ToString("yyyy/MM/dd");
            uparticle = drup[1].ToString();
            uparticleid = (int)drup[0];
        }
        else
            up.Visible = false;
        drup.Close();
        string nextSql = "select co.[id],co.[title],co.[time] from [content] co where co.id = (select MIN(id) from [content] where id>@id)";
        OleDbDataReader drdown = SQLHelper.GetDataReader(nextSql, param);
        if (drdown.Read())
        {
            downtime = Convert.ToDateTime(drdown[2].ToString()).ToString("yyyy/MM/dd");
            downarticle = drdown[1].ToString();
            downarticleid = (int)drdown[0];
        }
        else
            down.Visible = false;
        drdown.Close();
    }

    protected void btnok_Click(object sender, EventArgs e)
    {
        string code = this.txtverify.Text.Trim().ToUpper();
        string rightcode = Session["code"].ToString();
        if (!IsPageRefreshed)
        {
            if (txtreply.Text == "")
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('评论内容不能为空！');</script>");
            else
            {
                if (code != "" && code == rightcode)
                {
                    if (txtreply.Text.Length > 200)
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('您的评论内容过长！');</script>");
                    else
                    {
                        int contentid = int.Parse(Request.QueryString["id"].ToString());
                        string reply = Server.HtmlEncode(wf.Word(txtreply.Text.Trim().ToString()));
                        string ip = Common.getIP();
                        string sqlStr = "insert into [reply] (contentid,reply,ip) values (@contentid,@reply,@ip)";
                        OleDbParameter[] param = {
                                         ParamHelper.MakeInParam("@contentid", OleDbType.Integer, contentid),
                                         ParamHelper.MakeInParam("@reply",OleDbType.VarWChar,reply),
                                         ParamHelper.MakeInParam("@ip",OleDbType.VarWChar,ip)
                                     };
                        int i = SQLHelper.ExecuteSql(sqlStr, param);
                        if (i == 1)
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('感谢您的评论，您的评论2分钟后会在本页显示！');</script>");
                            txtreply.Text = "";
                            txtverify.Text = "";
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未知原因评论发表不成功！');</script>");
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('验证码输入错误！');</script>");
                }
            }
        }
    }
}
