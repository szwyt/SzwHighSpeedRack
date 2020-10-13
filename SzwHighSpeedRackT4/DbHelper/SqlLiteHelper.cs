using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace SzwHighSpeedRackT4
{
    public class SqlLiteHelper : BaseSqlHelper
    {
        public override string SelectTableName
        {
            get { return $"SELECT Name FROM sqlite_master WHERE type='table' ORDER BY name"; }
        }

        public override DataTable ExecuteDataTable(string connectionString, string sql, params DbParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            da.FillSchema(dt, SchemaType.Source);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}