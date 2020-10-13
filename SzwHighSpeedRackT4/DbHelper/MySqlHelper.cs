using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace SzwHighSpeedRackT4
{
    public class MySqlHelper : BaseSqlHelper
    {
        public override string SelectTableName
        {
            get { return $"select TABLE_NAME as Name from information_schema.tables where table_type='BASE TABLE' and table_schema='@Database' order by TABLE_NAME asc;"; }
        }

        #region ExecuteNonQuery方法

        public int ExecuteNonQuery(string connectionString, string sql, params DbParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
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

        public MySqlDataReader ExecuteDataReader(string connectionString, string sql, params DbParameter[] parameters)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        #endregion ExecuteReader方法
    }
}