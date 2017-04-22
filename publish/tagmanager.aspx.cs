using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Web.UI.WebControls;


public partial class publish_tagmanager : RefreshServe
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["publisher"] == "" || Session["publisher"] == null)
        {
            Response.Redirect("default.aspx");
        }
        if (!Page.IsPostBack)
        {
            bindtag();
        }
    }

    private void bindtag()
    {
        string sqlStr = "select si.id,si.type,si.picaddress from simplepic si";
        DataTable dt = SQLHelper.QueryTb(sqlStr);
        rpttag.DataSource = dt;
        rpttag.DataBind();
    }

    protected void btnok_Click(object sender, EventArgs e)
    {
        if (!IsPageRefreshed)
        {
            string type = txttag.Text.ToString();
            string sqltype = "select [id] from simplepic where [type]='" + type + "'";
            object obj = SQLHelper.ExecuteScalar(sqltype);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                string filename = this.fileupload.PostedFile.FileName;
                if (filename == null || filename == "")
                {
                    Response.Write("<script>alert('请选择上传的图片！')</script>");
                }
                else
                {
                    string extendName = filename.Substring(filename.LastIndexOf(".")).ToLower();
                    if (extendName == ".jpg" || extendName == ".bmp" || extendName == ".gif" || extendName == ".jpeg" || extendName == ".png")
                    {
                        string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                        newFileName = newFileName + extendName;
                        string sqlStr = "insert into [simplepic] ([type],picaddress) values (@type,@picaddress)";
                        string picaddress = "/icon/" + newFileName;
                        OleDbParameter[] param = {
                                            ParamHelper.MakeInParam("@type", OleDbType.VarWChar, type),
                                            ParamHelper.MakeInParam("@picaddress", OleDbType.VarWChar, picaddress)
                                         };
                        int i = SQLHelper.ExecuteSql(sqlStr, param);
                        if (i == 1)
                        {
                            txttag.Text = "";
                            Response.Write("<script>alert('标签添加成功！')</script>");
                            this.fileupload.SaveAs(Server.MapPath("~/icon" + "\\" + newFileName));
                            bindtag();
                        }
                        else
                        {
                            Response.Write("<script>alert('标签添加失败！')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('上传的图片只能是JPG、BMP 、GIF 、JPEG格式，请选择正确图片格式！')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('此标签已经存在！')</script>");
            }
        }
    }

    protected void lb_Click(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument.ToString();
        string sql = "delete from [simplepic] where id=" + id + "";
        string sqlStr = "select picaddress from simplepic where id=" + id + "";
        string FileName = (string)SQLHelper.ExecuteScalar(sqlStr);
        int i = SQLHelper.ExecuteSql(sql);
        string path = "~" + FileName;
        if (File.Exists(Server.MapPath(path)))
            File.Delete(Server.MapPath(path));
        if (i == 1)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除成功！');</script>");
            bindtag();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('未知异常！');</script>");
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("pub.aspx");
    }
}
