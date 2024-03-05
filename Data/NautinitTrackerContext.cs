using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tracker.Configurations;
using Tracker.Models;
using Tracker.Utils;

namespace Tracker.Data;

public partial class NautinitTrackerContext : DbContext
{
    private readonly IConfiguration _configuration;
    public NautinitTrackerContext()
    {
    }

    public NautinitTrackerContext(DbContextOptions<NautinitTrackerContext> options, IConfiguration configuration, IOptionsMonitor<DatabaseSettings> databaseSettings, IWebHostEnvironment env)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Tracking> Trackings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //var _rdsConnectionString = _configuration["ConnectionStrings:PRDS"];

        var _rdsConnectionString = AppSettings.GetSettingAsString("ConnectionStrings:PRDS");

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL(_rdsConnectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PRIMARY");

            entity.ToTable("admins");

            entity.Property(e => e.Aid)
                .HasColumnType("int(11)")
                .HasColumnName("aid");
            entity.Property(e => e.Regdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("regdate");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("status");
            entity.Property(e => e.Uid)
                .HasColumnType("int(10)")
                .HasColumnName("uid");
        });

        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PRIMARY");

            entity.ToTable("alerts");

            entity.Property(e => e.Aid)
                .HasColumnType("int(11)")
                .HasColumnName("aid");
            entity.Property(e => e.Ddate)
                .HasColumnType("timestamp")
                .HasColumnName("ddate");
            entity.Property(e => e.Did)
                .HasColumnType("int(7)")
                .HasColumnName("did");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.Regdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("regdate");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("status");
            entity.Property(e => e.Uid)
                .HasColumnType("int(10)")
                .HasColumnName("uid");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Gid).HasName("PRIMARY");

            entity.ToTable("groups");

            entity.HasIndex(e => e.Uid, "uid").IsUnique();

            entity.Property(e => e.Gid)
                .HasColumnType("int(11)")
                .HasColumnName("gid");
            entity.Property(e => e.Pid)
                .HasColumnType("int(11)")
                .HasColumnName("pid");
            entity.Property(e => e.Uid)
                .HasColumnType("int(11)")
                .HasColumnName("uid");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PRIMARY");

            entity.ToTable("profiles");

            entity.HasIndex(e => e.Uid, "uid").IsUnique();

            entity.Property(e => e.Pid)
                .HasColumnType("int(11)")
                .HasColumnName("pid");
            entity.Property(e => e.Address)
                .HasColumnType("int(11)")
                .HasColumnName("address");
            entity.Property(e => e.Phone)
                .HasColumnType("int(11)")
                .HasColumnName("phone");
            entity.Property(e => e.Uid)
                .HasColumnType("int(11)")
                .HasColumnName("uid");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PRIMARY");

            entity.ToTable("sessions");

            entity.Property(e => e.Sid)
                .HasColumnType("int(11)")
                .HasColumnName("sid");
            entity.Property(e => e.Regdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("regdate");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("status");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .HasColumnName("token");
            entity.Property(e => e.Uid)
                .HasColumnType("int(10)")
                .HasColumnName("uid");
        });

        modelBuilder.Entity<Tracking>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PRIMARY");

            entity.ToTable("tracking");

            entity.Property(e => e.Tid)
                .HasColumnType("int(11)")
                .HasColumnName("tid");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.Regdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("regdate");
            entity.Property(e => e.Uid)
                .HasColumnType("int(10)")
                .HasColumnName("uid");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Uid)
                .HasColumnType("int(11)")
                .HasColumnName("uid");
            entity.Property(e => e.Custno)
                .HasMaxLength(20)
                .HasColumnName("custno");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email");
            entity.Property(e => e.Gid)
                .HasColumnType("int(10)")
                .HasColumnName("gid");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
            entity.Property(e => e.Regdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("regdate");
            entity.Property(e => e.Ruc)
                .HasMaxLength(13)
                .HasColumnName("ruc");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("status");
            entity.Property(e => e.Token)
                .HasMaxLength(32)
                .HasColumnName("token");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
