using Microsoft.EntityFrameworkCore;
using PRN232_PE_FA25_NguyenKhanhTin.Models;

namespace PRN232_PE_FA25_NguyenKhanhTin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed mẫu đúng đề
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Name = "Hello PRN232", Description = "Minimal API + HTML", ImageUrl = null, CreatedAt = DateTime.UtcNow },
                new Post { Id = 2, Name = "Deploy Render", Description = "Connected to Supabase/Postgres", ImageUrl = "https://picsum.photos/seed/p1/400/240", CreatedAt = DateTime.UtcNow },
                new Post { Id = 3, Name = "Search & Sort", Description = "A→Z / Z→A + search by name", ImageUrl = "https://picsum.photos/seed/p2/400/240", CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
