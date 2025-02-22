using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class SQLHelper
    {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        #region 普通方法

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            var conn = new SqlConnection(ConnStr);
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection); // 让 reader 关闭时自动关闭 conn
            }
            catch
            {
                conn.Dispose();
                throw;
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable FillDataTable(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var adapter = new SqlDataAdapter(sql, conn))
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static int Update(DataTable dataTable, string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddRange(parameters);
                var rows = adapter.Update(dataTable);
                conn.Close();
                return rows;
            }
        }

        #endregion

        #region 事务方法

        // 新增事务上下文类
        public class TransactionContext : IDisposable
        {
            internal SqlConnection Conn { get; }
            internal SqlTransaction Transaction { get; }

            public TransactionContext(string connectionString)
            {
                Conn = new SqlConnection(connectionString);
                Conn.Open();
                Transaction = Conn.BeginTransaction();
            }

            public void Commit() => Transaction.Commit();
            public void Rollback() => Transaction.Rollback();

            public void Dispose()
            {
                Transaction?.Dispose();
                Conn?.Close();
                Conn?.Dispose();
            }
        }

        // 新增事务入口方法
        public static TransactionContext BeginTransaction()
        {
            return new TransactionContext(ConnStr);
        }

        // 新增事务版执行方法（重载）
        public static int ExecuteNonQuery(TransactionContext context, string sql, params SqlParameter[] parameters)
        {
            using (var cmd = new SqlCommand(sql, context.Conn, context.Transaction))
            {
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // 其他事务版方法（类似模式添加）
        public static object ExecuteScalar(TransactionContext context, string sql, params SqlParameter[] parameters)
        {
            using (var cmd = new SqlCommand(sql, context.Conn, context.Transaction))
            {
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }


        public static DataTable FillDataTable(TransactionContext context, string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var adapter = new SqlDataAdapter(sql, conn))
                {
                    using (var cmd = new SqlCommand(sql, context.Conn, context.Transaction))
                    {
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    #endregion
}