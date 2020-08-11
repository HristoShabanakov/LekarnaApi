namespace LekarnaApi.Data
{
    using LekarnaApi.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class LekarnaDbContext : IdentityDbContext<User>
    {
        public LekarnaDbContext(DbContextOptions<LekarnaDbContext> options)
            : base(options)
        {
        }
    }
}
