using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapp4_mvc.Areas.Identity.Data;
using webapp4_mvc.Models;

namespace webapp4_mvc.Areas.Identity.Data;

public class ApplicationDbContex : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    public DbSet<webapp4_mvc.Models.ProjectRole> ProjectRole { get; set; }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
  void IEntityTypeConfiguration<ApplicationUser>.Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}