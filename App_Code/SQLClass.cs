using System;

/// <summary>
///SQLEnum 的摘要说明
/// </summary>
public class SQLClass
{
    /// <summary>
    /// 全部记录数
    /// </summary>
    public static string sqlRecordCountAll = "select count(id) as num from [content]";
    /// <summary>
    /// 全部记录数据
    /// </summary>
    public static string sqlDataAll = "select co.[id],co.[title],co.[content],co.publisher,co.readcount,co.simplepicid,co.[time],si.picaddress,si.type from [content] co,simplepic si where co.simplepicid=si.id order by co.id desc";

    /// <summary>
    /// Movie记录数
    /// </summary>
    public static string sqlRecordCountMovie = "select count(id) as num from [content] where cateid=1";
    /// <summary>
    /// Movie记录数据
    /// </summary>
    public static string sqlDataMovie = "select co.[id],co.[title],co.[content],co.publisher,co.readcount,co.simplepicid,co.[time],si.picaddress,si.type from [content] co,simplepic si where co.simplepicid=si.id and co.cateid=1 order by co.id desc";

    /// <summary>
    /// It记录数量
    /// </summary>
    public static string sqlRecordCountIt = "select count(id) as num from [content] where cateid=2";
    /// <summary>
    /// It记录数据
    /// </summary>
    public static string sqlDataIt = "select co.[id],co.[title],co.[content],co.publisher,co.readcount,co.simplepicid,co.[time],si.picaddress,si.type from [content] co,simplepic si where co.simplepicid=si.id and co.cateid=2 order by co.id desc";
}
