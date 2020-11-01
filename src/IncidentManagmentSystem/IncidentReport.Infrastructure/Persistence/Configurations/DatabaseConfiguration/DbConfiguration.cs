namespace IncidentReport.Infrastructure.Persistence.Configurations.DatabaseConfiguration
{
    public class DbConfiguration
    {
        public string ConnectionString { get; }
        public DatabaseProvider? DatabaseProvider { get; }
        public InMemoryDatabaseProvider? InMemoryDatabaseProvider { get; }

        public DbConfiguration(string connectionString, DatabaseProvider databaseProvider)
        {
            this.ConnectionString = connectionString;
            this.DatabaseProvider = databaseProvider;
        }

        public DbConfiguration(InMemoryDatabaseProvider? inMemoryDatabaseProvider)
        {
            this.InMemoryDatabaseProvider = inMemoryDatabaseProvider;
        }
    }
}
