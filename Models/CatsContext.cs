using Microsoft.EntityFrameworkCore;

namespace Cats_API.Models
{
    public class CatsContext : DbContext
    {
        public CatsContext(DbContextOptions<CatsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>()
                 .HasMany(x => x.Tags)
                 .WithMany(x => x.Cats);

            modelBuilder.Entity<Breed>()
                .HasOne(b => b.Weight)
                .WithOne(w => w.Breed)
                .HasForeignKey<Weight>(w => w.BreedId)
                .IsRequired(false);

            modelBuilder.Entity<Image>()
                .HasMany(i => i.Breeds)
                .WithMany(b => b.Images);

            modelBuilder.Entity<Cat>()
                .Property(c => c.Created)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Tag>()
                .Property(c => c.Created)
                .HasDefaultValueSql("getdate()");
        }


        public DbSet<Cat> Cats { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
