using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrol_userreply : System.Web.UI.UserControl
{
    public void Page_Load(object sender, EventArgs e)
    {
        bindreply();
    }

    public void bindreply()
    {
        string id = Request.QueryString["id"].ToString();
        string sqlStr = "select re.id,re.[reply],re.[ip],re.[time] from [reply] re where re.contentid=@id order by id desc";
        OleDbParameter[] param = {
                                   ParamHelper.MakeInParam("@id", OleDbType.VarWChar, id)
                               };
        OleDbDataReader dr = SQLHelper.GetDataReader(sqlStr, param);
        if (dr.HasRows)
        {
            noreply.Visible = false;
            rptreply.DataSource = dr;
            rptreply.DataBind();
        }
        else
        {
            reply.Visible = false;
        }
        dr.Close();
    }

    public string Convertdate2view(string date)
    {
        return Common.ConvertDateTimeView(date);
    }

    protected void lbcancle_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32((sender as LinkButton).CommandArgument.ToString());
        string sqlStr = "delete from [reply] where id=@id";
        OleDbParameter[] param = {
                                   ParamHelper.MakeInParam("@id", OleDbType.Integer, id)
                               };
        int i = SQLHelper.ExecuteSql(sqlStr, param);
        if (i == 1)
            bindreply();
    }

    protected void rptreply_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
        {
            LinkButton lb = e.Item.FindControl("lbcancle") as LinkButton;
            if ((string)Session["publisher"] == "" || Session["publisher"] == null)
            {
                lb.Visible = false;
            }
            else
            {
                lb.Visible = true;
            }
        }
    }
}