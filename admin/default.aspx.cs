using System;
using System.Web;
using System.Data.OleDb;

public partial class publish_pub : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtusername.Focus();
        }
    }

    protected void IbtnEnter_Click(object sender, EventArgs e)
    {
        string code = this.txtverifycode.Text.Trim().ToUpper();
        string rightcode = Session["code"].ToString();
        if (code != "" && code == rightcode)
        {
            if (this.txtusername.Text == "" || this.txtpassword.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('用户名密码不能为空！');</script>");
            }
            else
            {
                string username = this.txtusername.Text.Trim();
                string password = this.txtpassword.Text.Trim();
                string sql = "select id from admin where username=@username and password=@password and power=1";
                OleDbParameter[] param = {
                 ParamHelper.MakeInParam("@username", OleDbType.VarWChar, username),
                 ParamHelper.MakeInParam("@password",OleDbType.VarWChar,password) 
                                        };
                bool b = SQLHelper.Exist(sql, param);
                if (b)
                {
                    Session["admin"] = username;
                    Response.Redirect("manage.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('用户名或密码有误！');</script>");
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('验证码输入错误！');</script>");
        }
    }
}
