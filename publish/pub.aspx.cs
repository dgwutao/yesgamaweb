using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Web;

public partial class publish_pub : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["publisher"] == "" || Session["publisher"] == null)
        {
            Response.Redirect("default.aspx");
        }
        if (!Page.IsPostBack)
        {
            bindtype();
            bindpic();
        }
    }
    protected void ok_Click(object sender, EventArgs e)
    {
        if (txttitle.Text == "" || ftb.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('标题和内容不能为空！');</script>");
        }
        else
        {
            int commend = 0;
            if (chk.Checked)
                commend = 1;
            int settop = 0;
            if (chktop.Checked)
                settop = 1;
            string publisher = Session["publisher"].ToString();
            string cateid = ddltype.SelectedValue.ToString();
            string simplepicid = ddlpic.SelectedValue.ToString();
            string title = txttitle.Text.Trim().ToString();
            string content = ftb.Text.ToString();
            string newspic = txtnewspic.Text.Trim().ToString();
            string sqlStr = "insert into [content] (cateid,publisher,title,content,newspic,simplepicid,commend,settop) values (@cateid,@publisher,@title,@content,@newspic,@simplepicid,@commend,@settop)";
            OleDbParameter[] param = {
                 ParamHelper.MakeInParam("@cateid", OleDbType.Integer, int.Parse(cateid)),
                 ParamHelper.MakeInParam("@publisher", OleDbType.VarWChar, publisher),
                 ParamHelper.MakeInParam("@title", OleDbType.VarWChar, title),
                 ParamHelper.MakeInParam("@content", OleDbType.VarWChar, content), 
                 ParamHelper.MakeInParam("@newspic", OleDbType.VarWChar, newspic),
                 ParamHelper.MakeInParam("@simplepicid", OleDbType.Integer, int.Parse(simplepicid)), 
                 ParamHelper.MakeInParam("@commend", OleDbType.Integer, commend),
                 ParamHelper.MakeInParam("@settop", OleDbType.Integer, settop)
                                        };
            int i = SQLHelper.ExecuteSql(sqlStr, param);
            if (i == 1)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('发布成功！');</script>");
                clear();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未知原因导致发布不成功！');</script>");
                clear();
            }
        }
    }
    protected void cancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("edi.aspx");
    }

    protected void tagmanager_Click(object sender, EventArgs e)
    {
        Response.Redirect("tagmanager.aspx");
    }
    private void bindtype()
    {
        string sqlStr = "select id,category from category";
        DataTable dt = new DataTable();
        dt = SQLHelper.QueryTb(sqlStr);
        ddltype.DataSource = dt;
        ddltype.DataTextField = "category";
        ddltype.DataValueField = "id";
        ddltype.DataBind();
    }
    private void bindpic()
    {
        string sqlStr = "select id,type from simplepic";
        DataTable dt = new DataTable();
        dt = SQLHelper.QueryTb(sqlStr);
        ddlpic.DataSource = dt;
        ddlpic.DataTextField = "type";
        ddlpic.DataValueField = "id";
        ddlpic.DataBind();
    }
    private void clear()
    {
        txtnewspic.Text = "";
        txttitle.Text = "";
        ftb.Text = "";
    }
}
