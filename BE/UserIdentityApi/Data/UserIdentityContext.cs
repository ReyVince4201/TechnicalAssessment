using Microsoft.EntityFrameworkCore;
using UserIdentityApi.Models;

namespace UserIdentityApi.Data
{
    public class UserIdentityContext : DbContext
    {
        public UserIdentityContext(DbContextOptions<UserIdentityContext> options) : base(options) { }

        public DbSet<UserIdentity> UserIdentities { get; set; }
    }
}
