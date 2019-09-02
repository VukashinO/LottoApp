using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<Round> Rounds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Round>().HasData(new Round
            {
                Id = 1,
                CreatedRound = DateTime.Now
            }); 
        }
    }
}
