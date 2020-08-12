namespace LekarnaApi.Data
{
    using LekarnaApi.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class LekarnaDbContext : IdentityDbContext<User>
    {
        public LekarnaDbContext(DbContextOptions<LekarnaDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pharmacy> Pharmacies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Pharmacy>()
                .HasOne(c => c.User)
                .WithMany(p => p.pharmacies)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
