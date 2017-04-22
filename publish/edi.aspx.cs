using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

public partial class publish_edi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["publisher"] == "" || Session["publisher"] == null)
        {
            Response.Redirect("default.aspx");
        }
        if (!Page.IsPostBack)
        {
            binddr();
        }

    }

    //删除按钮事件
    protected void lb_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument.ToString();
        string sql = "delete from [content] where id=" + id + "";
        string sqlStr = "delete from [reply] where contentid=" + id + "";
        int i = SQLHelper.ExecuteSql(sql);
        SQLHelper.ExecuteSql(sqlStr);
        if (i == 1)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");
            binddr();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未知异常！');</script>");
        }
    }
    //分页
    void binddr()
    {
        string sqlStr = "select co.id,co.publisher,co.title,ca.category,si.type from [content] co,category ca,simplepic si where co.cateid=ca.id and co.simplepicid=si.id order by co.id desc";
        DataTable dt = SQLHelper.QueryTb(sqlStr);
        DataView dv = dt.DefaultView;
        PagedDataSource pds = new PagedDataSource();
        AspNetPager1.RecordCount = dv.Count;
        pds.DataSource = dv;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        this.rpt.DataSource = pds;
        this.rpt.DataBind();
    }
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        binddr();
    }
    protected void goback_Click(object sender, EventArgs e)
    {
        Response.Redirect("pub.aspx");
    }
}
