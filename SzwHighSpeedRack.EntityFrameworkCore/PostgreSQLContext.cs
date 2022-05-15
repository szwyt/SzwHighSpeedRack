namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// PostgreSQLContext.
    /// </summary>
    public class PostgreSQLContext : BaseContext
    {
        public PostgreSQLContext(DbContextOptions options) : base(options)
        {
        }
        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(this.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}