using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GashnyaLohotron;

public partial class User13Context : DbContext
{
    public User13Context()
    {
    }

    public User13Context(DbContextOptions<User13Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=192.168.200.35;database=user13;user=user13;password=41225;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banner>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BannerImg)
                .HasColumnType("image")
                .HasColumnName("bannerImg");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("History");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BannerId).HasColumnName("bannerId");
            entity.Property(e => e.RewardId).HasColumnName("rewardId");

            entity.HasOne(d => d.Banner).WithMany(p => p.Histories)
                .HasForeignKey(d => d.BannerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Banners");

            entity.HasOne(d => d.Reward).WithMany(p => p.Histories)
                .HasForeignKey(d => d.RewardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Rewards");
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BannerId).HasColumnName("bannerId");
            entity.Property(e => e.Chance)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("chance");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.RewardImg)
                .HasColumnType("image")
                .HasColumnName("rewardImg");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");

            entity.HasOne(d => d.Banner).WithMany(p => p.Rewards)
                .HasForeignKey(d => d.BannerId)
                .HasConstraintName("FK_Rewards_Banners");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HistoryId).HasColumnName("historyId");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.UserBalance).HasColumnName("userBalance");

            entity.HasOne(d => d.History).WithMany(p => p.Users)
                .HasForeignKey(d => d.HistoryId)
                .HasConstraintName("FK_Users_History");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
