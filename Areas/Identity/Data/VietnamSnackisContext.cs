using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VietnamSnackis.Areas.Identity.Data;
using VietnamSnackis.Models;

namespace VietnamSnackis.Data;

public class VietnamSnackisContext : IdentityDbContext<VietnamSnackisUser>
{
    public VietnamSnackisContext(DbContextOptions<VietnamSnackisContext> options)
        : base(options)
    {
    }

    public DbSet<VietnamSnackis.Models.Post> CreatePost { get; set; } = default!;

    public DbSet<VietnamSnackis.Models.Comment> Comment { get; set; } = default!; 

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<VietnamSnackis.Models.Category> Category { get; set; } = default!;

public DbSet<VietnamSnackis.Models.SubCategory> SubCategory { get; set; } = default!;

public DbSet<PrivateMessage> PrivateMessage { get; set; } = default!; 
}
