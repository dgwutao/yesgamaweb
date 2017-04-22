using System;
using System.Data.OleDb;
using System.Data;
using System.Web;


public partial class usercontrol_associatepage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            bindassociate();
    }
    private void bindassociate()
    {
        string id = Request.QueryString["id"].ToString();
        string sql = "select top 10 co.id,co.title,co.readcount,co.time from [content] co where co.simplepicid=(select simplepicid from content where id=@id) order by co.id desc";
        OleDbParameter[] param = {
                                     ParamHelper.MakeInParam("@id",OleDbType.VarWChar,id)
                                 };
        OleDbDataReader dr = SQLHelper.GetDataReader(sql, param);
        if (dr.HasRows)
        {
            rptassociate.DataSource = dr;
            rptassociate.DataBind();
        }
        dr.Close();

    }

    public string Convertdate2view(string date)
    {
        return Common.ConvertDateTimeView(date);
    }
}
