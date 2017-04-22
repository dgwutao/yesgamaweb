using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI.WebControls;

public partial class admin_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["admin"] == "" || Session["admin"] == null)
        {
            Response.Redirect("default.aspx");
        }
        if (!Page.IsPostBack)
        {
            bindrtp();
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("add.aspx");
    }

    private void bindrtp()
    {
        string sqlStr = "select a.username,a.password,a.id,p.power  from admin a,power p where a.power=p.id";
        DataTable dt = SQLHelper.QueryTb(sqlStr);
        dt.Rows.RemoveAt(0);
        rpt.DataSource = dt;
        rpt.DataBind();
    }
    //删除按钮事件
    protected void lb_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32((sender as LinkButton).CommandArgument.ToString());
        string sqlStr = "delete from [admin] where id=@id";
        OleDbParameter[] param = {
                 ParamHelper.MakeInParam("@id", OleDbType.Integer, id) 
                                        };
        int i = SQLHelper.ExecuteSql(sqlStr, param);
        if (i == 1)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");
            bindrtp();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未知原因导致删除失败！');</script>");
        }
    }
}
