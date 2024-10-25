using Microsoft.EntityFrameworkCore; // Ensure this namespace is included

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=products.db");
}
