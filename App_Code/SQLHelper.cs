using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Collections;

/// <summary>
///SQLHelper 的摘要说明
/// </summary>
public class SQLHelper
{
    public SQLHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

    /// <summary>
    /// 判断是否存在
    /// </summary>
    /// <param name="strSql"></param>
    /// <param name="cmdParms"></param>
    /// <returns></returns>
    public static bool Exist(string strSql, params OleDbParameter[] cmdParms)
    {
        object obj = SQLHelper.GetSingle(strSql, cmdParms);
        int cmdresult;
        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        {
            cmdresult = 0;
        }
        else
        {
            cmdresult = int.Parse(obj.ToString());
        }
        if (cmdresult == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="SQLString">计算查询结果语句</param>
    /// <returns>查询结果（object）</returns>
    public static object GetSingle(string SQLString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }
    }
    public static object GetSingle(string SQLString, int Times)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    cmd.CommandTimeout = Times;
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }
    }
    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="SQLString">计算查询结果语句</param>
    /// <returns>查询结果（object）</returns>
    public static object GetSingle(string SQLString, params OleDbParameter[] cmdParms)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand cmd = new OleDbCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
    /// <summary>
    /// 执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(string SQLString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception E)
                {
                    connection.Close();
                    throw new Exception(E.Message);
                }
            }
        }
    }

    /// <summary>
    /// 执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(string SQLString, params OleDbParameter[] cmdParms)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand cmd = new OleDbCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (Exception E)
                {
                    throw new Exception(E.Message);
                }
            }
        }
    }

    /// <summary>
    /// 执行查询语句，返回DataTable
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataTable QueryTb(string SQLString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            OleDbCommand cmd = new OleDbCommand(SQLString,connection);
            DataTable dt = new DataTable();
            using (OleDbDataAdapter command = new OleDbDataAdapter(cmd))
            {
                try
                {
                    command.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;
            }
        }
    }

    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            OleDbCommand cmd = new OleDbCommand(SQLString, connection);
            DataSet ds = new DataSet();
            using (OleDbDataAdapter command = new OleDbDataAdapter(cmd))
            {
                try
                {
                    command.Fill(ds,"ds");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }

    /// <summary>
    /// 执行查询语句，返回DataTable
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataTable QueryTb(string SQLString, params  OleDbParameter[] cmdParms)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
    }

    /// <summary>
    /// 执行查询语句，返回DataTable
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString, params  OleDbParameter[] cmdParms)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand cmd = new OleDbCommand();
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }


    /// <summary>
    /// 执行多条SQL语句，实现数据库事务。
    /// </summary>
    /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
    public static bool ExecuteSqlTran(Hashtable SQLStringList)
    {
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            conn.Open();
            using (OleDbTransaction trans = conn.BeginTransaction())
            {
                OleDbCommand cmd = new OleDbCommand();
                try
                {
                    foreach (DictionaryEntry myDE in SQLStringList)
                    {
                        string cmdText = myDE.Key.ToString();
                        OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
                        PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 执行语句返回DataReader
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static OleDbDataReader GetDataReader(string sql)
    {
        OleDbConnection connection = new OleDbConnection(connectionString);
        if (connection.State != ConnectionState.Open)
            connection.Open();
        OleDbCommand cmd = new OleDbCommand(sql, connection);
        try
        {
            OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
            connection.Close();
        }
    }

    /// <summary>
    /// 执行带参数的语句返回DataReader
    /// </summary>
    /// <param name="SQLString"></param>
    /// <param name="cmdParms"></param>
    /// <returns></returns>
    public static OleDbDataReader GetDataReader(string SQLString, params OleDbParameter[] cmdParms)
    {
        OleDbConnection connection = new OleDbConnection(connectionString);
        OleDbCommand cmd = new OleDbCommand();
        try
        {
            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
            OleDbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return myReader;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// 执行语句返回第一行第一列object类型
    /// </summary>
    /// <param name="cmdText"></param>
    /// <returns></returns>
    public static object ExecuteScalar(string cmdText)
    {
        OleDbCommand cmd = new OleDbCommand();
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            PrepareCommand(cmd, conn, null, cmdText, null);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 执行带参数的语句返回第一行第一列object类型
    /// </summary>
    /// <param name="cmdText"></param>
    /// <param name="cmdParms"></param>
    /// <returns></returns>
    public static object ExecuteScalar(string cmdText, params OleDbParameter[] cmdParms)
    {
        OleDbCommand cmd = new OleDbCommand();
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            PrepareCommand(cmd, conn, null, cmdText, cmdParms);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 写系统日志
    /// </summary>
    /// <param name="admin"></param>
    /// <param name="message"></param>
    public static void wSystem(string admin, string message)
    {
        string ip = Common.getIP();
        string sqlStr = "insert into [systemlog] (admin,message,ip) values (@admin,@message,@ip)";
        OleDbParameter[] param = {
                 new OleDbParameter("@admin",admin),
                 new OleDbParameter("@message",message),
                 new OleDbParameter("@ip",ip) 
                                        };
        ExecuteSql(sqlStr, param);
    }

    private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        if (trans != null)
            cmd.Transaction = trans;
        cmd.CommandType = CommandType.Text;
        if (cmdParms != null)
        {
            foreach (OleDbParameter parameter in cmdParms)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                cmd.Parameters.Add(parameter);
            }
        }
    }
}


