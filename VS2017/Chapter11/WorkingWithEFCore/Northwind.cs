using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
    // this manages the connection to the database 
    public class Northwind : DbContext
    {
        // these properties map to tables in the database 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(
          DbContextOptionsBuilder optionsBuilder)
        {
            // to use Microsoft SQL Server, uncomment the following 
            optionsBuilder.UseSqlServer(
              @"Data Source=(localdb)\mssqllocaldb;" +
              "Initial Catalog=Northwind;" +
              "Integrated Security=true;" +
              "MultipleActiveResultSets=true;");

            // to use SQLite, uncomment the following 
            // string path = System.IO.Path.Combine(
            //   System.Environment.CurrentDirectory, "Northwind.db");
            // optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(
          ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes
            // to limit the length of a category name to under 40 
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
