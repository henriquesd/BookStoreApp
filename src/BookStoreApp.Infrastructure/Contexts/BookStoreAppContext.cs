using BookStoreApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookStoreApp.Infrastructure.Contexts
{
    public class BookStoreAppContext : DbContext
    {
        public BookStoreAppContext(DbContextOptions<BookStoreAppContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // if not informed, it will create with varchar(100);
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreAppContext).Assembly);

            // for disable cascate delete;
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}