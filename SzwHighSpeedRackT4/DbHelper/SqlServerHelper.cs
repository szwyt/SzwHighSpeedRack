using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SzwHighSpeedRackT4
{
    public class SqlServerHelper : BaseSqlHelper
    {
        public override string SelectTableName
        {
            get { return $"select Name from sysobjects where xtype='U' order By Name;"; }
        }

        public override string SelectTableColumName
        {
            get { return $"SELECT top 0 * FROM @TableName;"; }
        }

        #region ExecuteNonQuery方法

        public int ExecuteNonQuery(string connectionString, string sql, params DbParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion ExecuteNonQuery方法

        #region ExecuteScalar方法

        public object ExecuteScalar(string connectionString, string sql, params DbParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        #endregion ExecuteScalar方法

        #region ExecuteTable方法

        public override DataTable ExecuteDataTable(string connectionString, string sql, params DbParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            da.FillSchema(dt, SchemaType.Source);   //从数据源中检索架构
                            return dt;
                        }
                    }
                }
            }
        }

        #endregion ExecuteTable方法

        #region ExecuteReader方法

        public SqlDataReader ExecuteDataReader(string connectionString, string sql, params DbParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        #endregion ExecuteReader方法
    }
}