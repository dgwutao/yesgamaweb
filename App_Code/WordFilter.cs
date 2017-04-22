using System;
using System.Data;


/// <summary>
///WordFilter 的摘要说明
/// </summary>
public class WordFilter
{
	public WordFilter()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public string Word(string str)
    {
        string[] keys = filtewords.Split('|');
        foreach (string key in keys)
        {
            str = str.Replace(key, "***");
        }
        return str;
    }

    private string filtewords = "2b|操你妈|草你妈|傻逼|fuck|你妈|我操|日你妈|我日|鸡巴|他妈的|妈b";
}
