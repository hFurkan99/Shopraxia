using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace User.Infrastructure.Persistence;

public class UserDbContext(DbContextOptions<UserDbContext> options) 
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("user");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}