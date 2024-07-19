using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options):base(options) { }
    

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> Subcategories { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Subcategories)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<SubCategory>()
                .HasMany(s => s.Books)
                .WithOne(b => b.Subcategory)
                .HasForeignKey(b => b.SubcategoryId);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDelete);
            modelBuilder.Entity<Author>().HasQueryFilter(b => !b.IsDelete);
            modelBuilder.Entity<Category>().HasQueryFilter(b => !b.IsDelete);
            modelBuilder.Entity<SubCategory>().HasQueryFilter(b => !b.IsDelete);
        }
       
    }
}
