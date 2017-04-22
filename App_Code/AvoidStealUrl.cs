using System;
using System.Web;
using System.Configuration;

/// <summary>
///avoidstealurl 的摘要说明
/// </summary>
public class AvoidStealUrl
    : IHttpHandler
{
    public AvoidStealUrl()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region IHttpHandler 成员

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

    #endregion
    public void ProcessRequest(HttpContext context)
    {
        Uri urlreferrer = context.Request.UrlReferrer;
        string ip = context.Request.UserHostAddress;
        string serverhost = context.Request.Url.Host;
        string localIp = ConfigurationManager.AppSettings["LocalIP"];
        if (urlreferrer == null || urlreferrer.Host.ToLower() != serverhost.ToLower())
        {
            context.Response.WriteFile("~/images/avoidstealurl.jpg");
        }
        else
        {
            context.Response.WriteFile(context.Request.PhysicalPath);
        }
    }
}
