using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TravelPalette.PL;

public partial class TravelPaletteEntities : DbContext
{
    public TravelPaletteEntities()
    {
    }

    public TravelPaletteEntities(DbContextOptions<TravelPaletteEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblAddress> tblAddresses { get; set; }

    public virtual DbSet<tblListItem> tblListItems { get; set; }

    public virtual DbSet<tblLocation> tblLocations { get; set; }

    public virtual DbSet<tblLocationTag> tblLocationTags { get; set; }

    public virtual DbSet<tblSchedule> tblSchedules { get; set; }

    public virtual DbSet<tblTag> tblTags { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    public virtual DbSet<tblUserList> tblUserLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TravelPalette.DB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAddre__3214EC079D5B4985");

            entity.ToTable("tblAddress");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.StreetName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ZIP)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblListItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblListI__3214EC07FC8F4155");

            entity.ToTable("tblListItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblLocat__3214EC07111B67F1");

            entity.ToTable("tblLocation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BusinessName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Coordinates)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblLocationTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblLocat__3214EC07FAE06678");

            entity.ToTable("tblLocationTag");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblSched__3214EC07868F14BD");

            entity.ToTable("tblSchedule");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblTag__3214EC07950BD254");

            entity.ToTable("tblTag");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC07D8EEE6EE");

            entity.ToTable("tblUser");

            entity.HasIndex(e => e.Email, "UQ__tblUser__A9D10534A6FCBA67").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUserList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUserL__3214EC071F0FD2FB");

            entity.ToTable("tblUserList");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ListName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
