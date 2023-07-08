using eBookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace eBookStore.Persistence.Data;

public class eBookStoreContext : IdentityDbContext<BookStoreUser, BookStoreRole, int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server =Azizbayli;Database=eBookStore;Trusted_Connection=True;TrustServerCertificate=True;");
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    // bunlar bizim DB olan cedvelerin c# terefdeki eksidir (entity domain modeller, yani esas modeller)
    //public DbSet<Author> Authors { get; set; }
    //public DbSet<Book> Books { get; set; }
    //public DbSet<Genre> Genres { get; set; }
    //public DbSet<Language> Languages { get; set; }
    //public DbSet<Offer> Offers { get; set; }
    //public DbSet<Order> Orders { get; set; }
    //public DbSet<OrderProduct> OrderProducts { get; set; }
    //public DbSet<PaperType> PaperTypes { get; set; }
    //public DbSet<Product> Products { get; set; }
    //public DbSet<Publisher> Publishers { get; set; }
    //public DbSet<Review> Reviews { get; set; }
    //public DbSet<Translator> Translators { get; set; }
}