using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Extensions;

namespace WAW.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext {
  private DbSet<Offer>? offers;
  private DbSet<User>? users;
  private DbSet<Company.Domain.Models.Company>? companies;

  public DbSet<Offer> Offers {
    get => GetContext(offers);
    set => offers = value;
  }

  public DbSet<User> Users {
    get => GetContext(users);
    set => users = value;
  }

  public DbSet<Company.Domain.Models.Company> Companies {
    get => GetContext(companies);
    set => companies = value;
  }

  public AppDbContext(DbContextOptions options) : base(options) {}

  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);

    var offerEntity = builder.Entity<Offer>();
    offerEntity.ToTable("Offer");
    offerEntity.HasKey(p => p.Id);
    offerEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    offerEntity.Property(p => p.Title).IsRequired().HasMaxLength(256);
    offerEntity.Property(p => p.Image).HasMaxLength(2048);
    offerEntity.Property(p => p.Description).IsRequired();
    offerEntity.Property(p => p.Status).IsRequired();

    var userEntity = builder.Entity<User>();
    userEntity.ToTable("Users");
    userEntity.HasKey(p => p.Id);
    userEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    userEntity.Property(p => p.FullName).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.PreferredName).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.Email).IsRequired().HasMaxLength(256);
    userEntity.Property(p => p.Birthdate).IsRequired();

    var companyEntity = builder.Entity<Company.Domain.Models.Company>();
    companyEntity.ToTable("Companies");
    companyEntity.HasKey(p => p.Id);
    companyEntity.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    companyEntity.Property(p => p.Name).IsRequired().HasMaxLength(100);
    companyEntity.Property(p => p.Address).HasMaxLength(256);
    companyEntity.Property(p => p.Email).IsRequired().HasMaxLength(256);

    builder.UseSnakeCase();
  }

  private static T GetContext<T>(T? ctx) {
    if (ctx == null) throw new NullReferenceException();
    return ctx;
  }
}