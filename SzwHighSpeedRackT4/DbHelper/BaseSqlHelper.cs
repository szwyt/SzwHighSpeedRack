using System.Data;
using System.Data.Common;

namespace SzwHighSpeedRackT4
{
    public abstract class BaseSqlHelper
    {
        public virtual string SelectTableName { get; set; }

        public virtual string SelectTableColumName { get; set; } = $"SELECT  * FROM @TableName LIMIT 0 ";

        public abstract DataTable ExecuteDataTable(string connectionString, string sql, params DbParameter[] parameters);
    }
}