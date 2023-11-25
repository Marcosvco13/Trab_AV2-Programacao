using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trab_AV2.Areas.Identity.Data;

namespace Trab_AV2.Data;

public class Trab_AV2Context : IdentityDbContext<Trab_AV2User>
{
    public Trab_AV2Context(DbContextOptions<Trab_AV2Context> options)
        : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    => optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;Initial Catalog=PARADIA_AV2;User Id=sa;Password=22102001da;TrustserverCertificate=True");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
