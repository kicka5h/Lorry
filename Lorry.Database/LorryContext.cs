using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lorry.Database
{
    public partial class LorryContext : DbContext
    {
        public LorryContext()
        {
        }

        public LorryContext(DbContextOptions<LorryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Couplet> Couplet { get; set; }
        public virtual DbSet<Haiku> Haiku { get; set; }
        public virtual DbSet<Recent> Recent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLExpress;Initial Catalog=Lorry;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Couplet>(entity =>
            {
                entity.Property(e => e.CoupletContent).HasMaxLength(120);

                entity.Property(e => e.CoupletRhyme).HasMaxLength(50);
            });

            modelBuilder.Entity<Haiku>(entity =>
            {
                entity.Property(e => e.HaikuContent)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.HaikuCount).HasMaxLength(50);
            });

            modelBuilder.Entity<Recent>(entity =>
            {
                entity.Property(e => e.RecentContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RecentDate)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.RecentType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
