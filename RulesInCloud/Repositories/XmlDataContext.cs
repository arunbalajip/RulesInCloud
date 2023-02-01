using Microsoft.EntityFrameworkCore;
using RulesInCloud.Models;

namespace RulesInCloud.Repositories
{
    public class XmlDataContext : DbContext
    {
        private readonly string connectionString;
        private readonly string databaseName;
        private readonly string collectionName;
        public DbSet<XMLData> xmlData { get; set; }

        public XmlDataContext(string connectionString, string databaseName, string collectionName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
            this.collectionName = collectionName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseCosmos(
                connectionString,
                databaseName: databaseName);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<XMLData>()

                .HasPartitionKey(o => o.name)
                .HasNoDiscriminator()
                .ToContainer(collectionName);
        }
    }
}