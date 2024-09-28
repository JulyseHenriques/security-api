using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Security.Infrastructure.Models;

namespace Security.Infrastructure.Data;

public partial class SecurityContext : DbContext
{
    #region Properties

    private readonly IConfiguration _configuration;

    #endregion

    #region Constructors

    public SecurityContext(DbContextOptions<SecurityContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    #endregion

    #region Tables

    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Contact> Contacts { get; set; }
    public virtual DbSet<ContactType> ContactTypes { get; set; }
    public virtual DbSet<User> Users { get; set; }

    #endregion

    #region Configurations

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("address_pk");

            entity.ToTable("address");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("postal_code");
            entity.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("street");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_user_id_fk");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contact_pk");

            entity.ToTable("contact");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("contact_contacttype_id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("contact_user_id_fk");
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contacttype_pk");

            entity.ToTable("contact_type");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('contacttype_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.TypeName)
                .HasDefaultValueSql("nextval('contacttype_typename_seq'::regclass)")
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("user");

            entity.HasIndex(e => e.Id, "user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    #endregion
}