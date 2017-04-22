using System;
using System.Data;
using System.Data.OleDb;

/// <summary>
///ParamHelper 的摘要说明
/// </summary>
public class ParamHelper
{
    public ParamHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 生成输入参数
    /// </summary>
    /// <param name="ParamName">Name of param.</param>
    /// <param name="DbType">Param type.</param>
    /// <param name="Value">Param value.</param>
    /// <returns>New parameter.</returns>
    public static OleDbParameter MakeInParam(string ParamName, OleDbType DbType, object Value)
    {
        return MakeParam(ParamName, DbType, ParameterDirection.Input, Value);
    }

    /// <summary>
    /// 生成输出参数
    /// </summary>
    /// <param name="ParamName">Name of param.</param>
    /// <param name="DbType">Param type.</param>
    /// <returns>New parameter.</returns>
    public static OleDbParameter MakeOutParam(string ParamName, OleDbType DbType)
    {
        return MakeParam(ParamName, DbType, ParameterDirection.Output, null);
    }

    /// <summary>
    /// 生成返回参数
    /// </summary>
    /// <param name="ParamName"></param>
    /// <param name="DbType"></param>
    /// <returns></returns>
    public static OleDbParameter MakeReturnParam(string ParamName, OleDbType DbType)
    {
        return MakeParam(ParamName, DbType, ParameterDirection.ReturnValue, null);
    }
    /// <summary>
    /// 生成参数
    /// </summary>
    /// <param name="ParamName">Name of param.</param>
    /// <param name="DbType">Param type.</param>
    /// <param name="Direction">Parm direction.</param>
    /// <param name="Value">Param value.</param>
    /// <returns>New parameter.</returns>
    private static OleDbParameter MakeParam(string ParamName, OleDbType DbType, ParameterDirection Direction, object Value)
    {
        OleDbParameter param = new OleDbParameter(ParamName, DbType);
        param.Direction = Direction;
        if (Direction == ParameterDirection.Input && Value != null)
        {
            param.Value = Value;
        }
        return param;
    }
}
