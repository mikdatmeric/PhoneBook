using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Abstractions;
using ReportService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Infrastructure.Concrete.Persistence.Context
{
    public class ReportServiceDbContext : DbContext
    {

        public ReportServiceDbContext(DbContextOptions<ReportServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Report> Reports => Set<Report>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ReportStatus enum'u int olarak saklansın
            modelBuilder.Entity<Report>()
                .Property(r => r.Status)
                .HasConversion<int>();

            modelBuilder.Entity<Report>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Report>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd(); // Otomatik artan

            modelBuilder.Entity<Report>()
                .Property(r => r.Id)
                .UseSerialColumn(); // PostgreSQL için SERIAL gibi davranır

            // ReportId (UUID) benzersiz olsun
            modelBuilder.Entity<Report>()
                .HasIndex(r => r.ReportCode)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditFields()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }

                entity.UpdatedAt = DateTime.UtcNow;
            }
        }

    }
}
