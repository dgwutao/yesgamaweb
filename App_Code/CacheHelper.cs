using System;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.Collections;

/// <summary>
///CacheHelper 的摘要说明
/// </summary>
public class CacheHelper
{
    public CacheHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    private static readonly Cache _cache;
    /// <summary>
    /// 清除所有缓存
    /// </summary>
    public static void Clear()
    {
        IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
        ArrayList al = new ArrayList();
        while (CacheEnum.MoveNext())
        {
            al.Add(CacheEnum.Key);
        }

        foreach (string key in al)
        {
            _cache.Remove(key);
        }
    }
    /// <summary>
    /// 清除缓存
    /// </summary>
    /// <param name="key"></param>
    public static void Remove(string key)
    {
        _cache.Remove(key);
    }
    /// <summary>
    /// 按分钟间隔缓存对象 并具有最高优先级
    /// </summary>
    /// <param name="key"></param>
    /// <param name="obj"></param>
    /// <param name="Minutes"></param>
    public static void Insert(string key, object obj, int Minutes)
    {
        if (obj != null)
        {
            _cache.Insert(key, obj, null, DateTime.MaxValue, TimeSpan.FromMinutes(Minutes), CacheItemPriority.High, null);
        }
    }
}
