using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
///DB 的摘要说明
/// </summary>
public class DB
{
    public static string connectionString = "server=Yep;Uid=sa;database=bank;pwd=123456";
    public DB()  //构造函数
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static SqlConnection Getconn()                //实例化一个空连接
    {
        SqlConnection conn = new SqlConnection(connectionString);
        if (conn.State.Equals(ConnectionState.Closed))
        {
            conn.Open();
        }
        return conn;

    }
    public static int ExecuteSql(string SQLString)       // 执行SQL语句，返回影响的记录数 接受一个参数sql
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw e;
                }
                finally { connection.Close(); }          //关闭连接
            }
        }
    }


    public static DataSet getDataSet(string sql) //运行sql 返回值：DataSet
    {
        try
        {
            SqlConnection conn = DB.Getconn();
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "ds");
            return ds;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            closeConnection();
        }
    }

    private static void closeConnection()                                   //功能描述：关闭数据库
    {
        SqlConnection conn = DB.Getconn();
        SqlCommand cmd = new SqlCommand();
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
        }
    }

}