using Microsoft.EntityFrameworkCore;

namespace DomainModels
{
    public class LottoDbContext : DbContext
    {
   
        public LottoDbContext(DbContextOptions<LottoDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RoundResult> RoundResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserId);
        }
    }
}
