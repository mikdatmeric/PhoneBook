using ContactService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Abstractions;

namespace ContactService.Infrastructure.Persistence.Context
{
    public class ContactServiceDbContext : DbContext
    {
        public ContactServiceDbContext(DbContextOptions<ContactServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons => Set<Person>();
        public DbSet<ContactInfo> ContactInfos => Set<ContactInfo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Kişi - İletişim bilgileri ilişkilendirmesi
            modelBuilder.Entity<Person>()
                .HasMany(p => p.ContactInfos)
                .WithOne(ci => ci.Person)
                .HasForeignKey(ci => ci.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enum: ContactInfoType as int (optional, EF does this by default)
            modelBuilder.Entity<ContactInfo>()
                .Property(ci => ci.Type)
                .HasConversion<int>();

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
