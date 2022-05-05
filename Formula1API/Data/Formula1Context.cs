﻿// Auto Generated by scaffolding DB
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using formula1.Models;

namespace formula1.Data
{
    public partial class Formula1Context : DbContext
    {
        public Formula1Context()
        {
        }

        public Formula1Context(DbContextOptions<Formula1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.HasIndex(e => e.CarId, "CarID_IDX");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CarId)
                    .HasMaxLength(45)
                    .HasColumnName("CarID");

                entity.Property(e => e.Team).HasMaxLength(100);

                entity.Property(e => e.Year).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.HasIndex(e => e.CarId, "CarID_FK_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CarId)
                    .HasMaxLength(45)
                    .HasColumnName("CarID");

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.Number).HasColumnType("int(11)");

                entity.Property(e => e.Team).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}