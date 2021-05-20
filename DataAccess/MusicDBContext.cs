using Microsoft.EntityFrameworkCore;
using Models;

namespace APIWorkshop.DataAccess
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext()
        {
        }

        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Artist>()
            .ToTable("Artist");

            modelBuilder.Entity<Album>()
            .HasOne(p => p.Artist)
            .WithMany(b => b.Albums)
            .HasForeignKey(p => p.ArtistId);
        }
    }
}