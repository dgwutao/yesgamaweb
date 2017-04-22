<%@ WebHandler Language="C#" Class="WaterMark" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.SessionState;  

public class WaterMark : IHttpHandler, IRequiresSessionState  // 要使用session必须实现该接口,记得要导入System.Web.SessionState命名空间
{

    public void ProcessRequest(HttpContext context)
    {
        string checkCode = GenCode(5);  // 产生5位随机字符
        context.Session["Code"] = checkCode; //将字符串保存到Session中，以便需要时进行验证
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(70, 22);
        Graphics g = Graphics.FromImage(image);
        try
        {
            //生成随机生成器
            Random random = new Random();

            //清空图片背景色
            g.Clear(Color.White);

            // 画图片的背景噪音线
            int i;
            for (i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2F, true);
            g.DrawString(checkCode, font, brush, 2, 2);

            //画图片的前景噪音点
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            context.Response.ClearContent();
            context.Response.ContentType = "image/Gif";
            context.Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }

    /// <summary>
    /// 产生随机字符串
    /// </summary>
    /// <param name="num">随机出几个字符</param>
    /// <returns>随机出的字符串</returns>
    private string GenCode(int num)
    {
        string str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] chastr = str.ToCharArray();
        string code = "";
        Random rd = new Random();
        int i;
        for (i = 0; i < num; i++)
        {
            code += str.Substring(rd.Next(0, str.Length), 1);
        }
        return code;

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}

