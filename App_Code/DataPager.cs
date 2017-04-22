using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

/// <summary>
///DataPager 的摘要说明
/// </summary>
public class DataPager
{
    public DataPager()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static int RecordCount(string sql)
    {
        using (OleDbConnection connection = new OleDbConnection(SQLHelper.connectionString))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            object val = new object();
            try
            {
                val = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return (int)val;
        }
    }


    public static DataTable Pager(string sqlStr, int CurrentPageIndex, int PageSize)
    {
        using (OleDbConnection connection = new OleDbConnection(SQLHelper.connectionString))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            OleDbCommand cmd = new OleDbCommand(sqlStr, connection);
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, PageSize * (CurrentPageIndex - 1), PageSize, "ds");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
    }

}
