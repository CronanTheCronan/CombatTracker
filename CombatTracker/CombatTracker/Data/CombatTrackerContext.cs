using System;
using CombatTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CombatTracker.Data
{
    public partial class CombatTrackerContext : DbContext
    {
        public CombatTrackerContext() { }

        public CombatTrackerContext(DbContextOptions<CombatTrackerContext> options) : base(options) { }

        public virtual DbSet<Conditions> Conditions { get; set; }
        public virtual DbSet<Heroes> Heroes { get; set; }
        public virtual DbSet<HeroesExtended> HeroesExtended { get; set; }
        public virtual DbSet<Monsters> Monsters { get; set; }
        public virtual DbSet<MonstersExtended> MonstersExtended { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Conditions>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Heroes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Heroes_Users");
            });

            modelBuilder.Entity<HeroesExtended>(entity =>
            {
                entity.Property(e => e.CurrentHp).HasColumnName("CurrentHP");

                entity.Property(e => e.MaxHp).HasColumnName("MaxHP");

                entity.HasOne(d => d.Condition1Navigation)
                    .WithMany(p => p.HeroesExtendedCondition1Navigation)
                    .HasForeignKey(d => d.Condition1)
                    .HasConstraintName("FK_HeroesExtended_Conditions1");

                entity.HasOne(d => d.Condition2Navigation)
                    .WithMany(p => p.HeroesExtendedCondition2Navigation)
                    .HasForeignKey(d => d.Condition2)
                    .HasConstraintName("FK_HeroesExtended_Conditions2");

                entity.HasOne(d => d.Condition3Navigation)
                    .WithMany(p => p.HeroesExtendedCondition3Navigation)
                    .HasForeignKey(d => d.Condition3)
                    .HasConstraintName("FK_HeroesExtended_Conditions3");

                entity.HasOne(d => d.Condition4Navigation)
                    .WithMany(p => p.HeroesExtendedCondition4Navigation)
                    .HasForeignKey(d => d.Condition4)
                    .HasConstraintName("FK_HeroesExtended_Conditions4");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.HeroesExtendedCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeroesExtended_Users");

                entity.HasOne(d => d.Hero)
                    .WithMany(p => p.HeroesExtended)
                    .HasForeignKey(d => d.HeroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeroesExtended_Heroes");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.HeroesExtendedLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeroesExtended_Users1");
            });

            modelBuilder.Entity<Monsters>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByUserNavigation)
                    .WithMany(p => p.MonstersCreatedByUserNavigation)
                    .HasForeignKey(d => d.CreatedByUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Monsters_Users");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.MonstersLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Monsters_Users1");
            });

            modelBuilder.Entity<MonstersExtended>(entity =>
            {
                entity.Property(e => e.CurrentHp).HasColumnName("CurrentHP");

                entity.Property(e => e.MaxHp).HasColumnName("MaxHP");

                entity.HasOne(d => d.Condition1Navigation)
                    .WithMany(p => p.MonstersExtendedCondition1Navigation)
                    .HasForeignKey(d => d.Condition1)
                    .HasConstraintName("FK_MonstersExtended_Conditions1");

                entity.HasOne(d => d.Condition2Navigation)
                    .WithMany(p => p.MonstersExtendedCondition2Navigation)
                    .HasForeignKey(d => d.Condition2)
                    .HasConstraintName("FK_MonstersExtended_Conditions2");

                entity.HasOne(d => d.Condition3Navigation)
                    .WithMany(p => p.MonstersExtendedCondition3Navigation)
                    .HasForeignKey(d => d.Condition3)
                    .HasConstraintName("FK_MonstersExtended_Conditions");

                entity.HasOne(d => d.Condition4Navigation)
                    .WithMany(p => p.MonstersExtendedCondition4Navigation)
                    .HasForeignKey(d => d.Condition4)
                    .HasConstraintName("FK_MonstersExtended_Conditions3");

                entity.HasOne(d => d.CreatedByUserNavigation)
                    .WithMany(p => p.MonstersExtendedCreatedByUserNavigation)
                    .HasForeignKey(d => d.CreatedByUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MonstersExtended_Users");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.MonstersExtendedLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MonstersExtended_Users1");

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.MonstersExtended)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MonstersExtended_Monsters");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
