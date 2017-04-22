using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
///Common 的摘要说明
/// </summary>
public class Common
{
    public Common()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 截取字符
    /// </summary>
    /// <param name="Str">要截取的字符串</param>
    /// <param name="StrLen">要截取的长度</param>
    /// <returns>返回截取后的字符串</returns>
    public static string CutStr(string Str, int StrLen)
    {
        if (Str != null && Convert.IsDBNull(StrLen) == false)
        {
            int t = 0;
            for (int i = 0; i <= StrLen; i++)
            {
                if (t >= StrLen)
                {
                    Str = Str.Substring(0, i) + "....";
                    break;
                }
                else
                {
                    if (i >= Str.Length)
                    {
                        Str = Str.Substring(0, i);
                        break;
                    }
                }
                int c = Math.Abs((int)Str[i]);
                if (c > 255)
                {
                    t += 2;
                }
                else
                {
                    t++;
                }
            }
        }
        else
        {
            Str = null;
        }
        return Str;
    }

    //获取浏览器版本号   
    public static string getBroswer()
    {
        string browsers;
        HttpBrowserCapabilities hbc = HttpContext.Current.Request.Browser;
        string browser = hbc.Browser.ToString();
        string version = hbc.Version.ToString();
        browsers = browser + version;
        return browsers;
    }

    //获取操作系统版本
    public static string getSys()
    {
        string Agent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
        if (Agent.Contains("NT 6.1"))
        {
            return "Windows 7";
        }
        else if (Agent.Contains("NT 6.0"))
        {
            return "Windows Vista";
        }
        else if (Agent.Contains("NT 5.1"))
        {
            return "Windows XP";
        }
        else if (Agent.Contains("Linux"))
        {
            return "Linux";
        }
        else if (Agent.Contains("Mac"))
        {
            return "Mac OS";
        }
        else
        {
            return "未知";
        }
    }

    //获取客户端IP地址   
    public static string getIP()
    {
        string result = String.Empty;
        result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (null == result || result == String.Empty)
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        if (null == result || result == String.Empty)
        {
            result = HttpContext.Current.Request.UserHostAddress;
        }
        if (null == result || result == String.Empty)
        {
            result = "0.0.0.0";
        }
        return result;
    }


    public static string GetNoHTMLString(string Htmlstring)
    {
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<.*", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @".*>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
        return Htmlstring;
    }



    public static string GetSafeHTMLString(string str)
    {
        str = Regex.Replace(str, @"<applet[^>]*?>.*?</applet>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<body[^>]*?>.*?</body>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<embed[^>]*?>.*?</embed>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<frame[^>]*?>.*?</frame>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<frameset[^>]*?>.*?</frameset>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<html[^>]*?>.*?</html>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<layer[^>]*?>.*?</layer>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<link[^>]*?>.*?</link>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<ilayer[^>]*?>.*?</ilayer>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<meta[^>]*?>.*?</meta>", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, @"<object[^>]*?>.*?</object>", "", RegexOptions.IgnoreCase);
        return str;
    }

    public static void countPv(string id)
    {
        string sqlStr = "update [content] co set readcount=readcount+1 where co.id=@id";
        OleDbParameter[] param ={
                                    new OleDbParameter("@id",id)
                               };
        SQLHelper.ExecuteSql(sqlStr, param);
    }

    public static string ConvertDateTimeView(string OldDate)
    {
        DateTime newDateTime = Convert.ToDateTime(OldDate);
        TimeSpan span = DateTime.Now - newDateTime;
        if (span.TotalDays > 60)
        {
            return newDateTime.ToString("yyyy-MM-dd");
        }
        else if (span.TotalDays > 30)
        {
            return "1个月前";
        }
        else if (span.TotalDays > 14)
        {
            return "2周前";
        }
        else if (span.TotalDays > 7)
        {
            return "1周前";
        }
        else if (span.TotalDays > 1)
        {
            return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
        }
        else if (span.TotalHours > 1)
        {
            return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
        }
        else if (span.TotalMinutes > 1)
        {
            return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
        }
        else if (span.TotalSeconds >= 1)
        {
            return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
        }
        else
        {
            return "1秒前";
        }
    }

    public static DateTimeOffset DateConvert(DateTime dt)
    {
        DateTime dateA = DateTime.SpecifyKind(dt, DateTimeKind.Local);
        DateTimeOffset dateC = dateA;
        return dateC;
    }

}
