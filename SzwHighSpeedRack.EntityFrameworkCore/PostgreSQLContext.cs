namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// PostgreSQLContext.
    /// </summary>
    public class PostgreSQLContext : BaseContext
    {
        public PostgreSQLContext(string connectionString) : base(connectionString)
        {
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this.ConnectionString);
        }
    }
}