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
            bigbind();
        }
    }
    protected void ok_Click(object sender, EventArgs e)
    {
        int commend = 0;
        if (chk.Checked)
            commend = 1;
        int settop = 0;
        if (chktop.Checked)
            settop = 1;
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        int cateid = Convert.ToInt32(ddltype.SelectedValue.ToString());
        int simplepicid = Convert.ToInt32(ddlpic.SelectedValue.ToString());
        string title = txttitle.Text.Trim().ToString();
        string content = ftb.Text.ToString();
        string newspic = txtnewspic.Text.Trim().ToString();
        string sqlStr = "update content set cateid=@cateid,title=@title,content=@content,newspic=@newspic,simplepicid=@simplepicid,commend=@commend,settop=@settop where id=@id";
        OleDbParameter[] param = {
                 ParamHelper.MakeInParam("@cateid", OleDbType.Integer, cateid),
                 ParamHelper.MakeInParam("@title", OleDbType.VarWChar, title),
                 ParamHelper.MakeInParam("@content", OleDbType.VarWChar, content), 
                 ParamHelper.MakeInParam("@newspic", OleDbType.VarWChar, newspic),
                 ParamHelper.MakeInParam("@simplepicid", OleDbType.Integer, simplepicid),
                 ParamHelper.MakeInParam("@commend", OleDbType.Integer, commend),
                 ParamHelper.MakeInParam("@settop", OleDbType.Integer, settop),
                 ParamHelper.MakeInParam("@id", OleDbType.Integer, id)
                                        };
        int i = SQLHelper.ExecuteSql(sqlStr, param);
        if (i == 1)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('重新发布成功！');</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未知原因导致重新发布不成功！');</script>");
        }
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
    private void bigbind()
    {
        string id = Request.QueryString["id"].ToString();
        string sqlStr = "select co.newspic,co.title,co.content,ca.category,co.commend,co.settop,si.type from [content] co,category ca,simplepic si where co.id=@id and co.cateid=ca.id and co.simplepicid=si.id";
        OleDbParameter[] param = {
                 ParamHelper.MakeInParam("@id", OleDbType.VarWChar, id) 
                                        };
        DataTable dt = SQLHelper.QueryTb(sqlStr, param);
        txtnewspic.Text = dt.Rows[0]["newspic"].ToString();
        txttitle.Text = dt.Rows[0]["title"].ToString();
        this.ftb.Text = dt.Rows[0]["content"].ToString();
        if ((int)dt.Rows[0]["commend"] == 1)
            chk.Checked = true;
        if ((int)dt.Rows[0]["settop"] == 1)
            chktop.Checked = true;
        ddlpic.Items.FindByText(dt.Rows[0]["type"].ToString()).Selected = true;
        ddltype.Items.FindByText(dt.Rows[0]["category"].ToString()).Selected = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("edi.aspx");
    }
}
