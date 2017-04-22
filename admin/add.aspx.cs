using System;
using System.Data;
using System.Data.OleDb;
using System.Web;

public partial class admin_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["admin"] == "" || Session["admin"] == null)
        {
            Response.Redirect("default.aspx");
        }
        if (!Page.IsPostBack)
        {
            bindddlpower();
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (txtusername.Text != "" && txtpassword.Text != "")
        {
            string username = txtusername.Text.ToString();
            string password = txtpassword.Text.ToString();
            int power = Convert.ToInt32(ddlpower.SelectedValue.ToString());
            string sqlStr = "insert into [admin] ([username],[password],[power]) values (@username,@password,@power)";
            OleDbParameter[] param = {
                 ParamHelper.MakeInParam("@username", OleDbType.VarWChar, username),
                 ParamHelper.MakeInParam("@password", OleDbType.VarWChar, password),
                 ParamHelper.MakeInParam("@power", OleDbType.Integer, power),
                                        };
            int i = SQLHelper.ExecuteSql(sqlStr, param);
            if (i == 1)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功！');</script>");
                Response.Redirect("manage.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未知原因导致添加失败！');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('用户名密码不能为空！');</script>");
        }
    }
    private void bindddlpower()
    {
        string sqlStr = "select id,power from power";
        DataTable dt = SQLHelper.QueryTb(sqlStr);
        ddlpower.DataSource = dt;
        ddlpower.DataTextField = "power";
        ddlpower.DataValueField = "id";
        ddlpower.DataBind();
    }
}
