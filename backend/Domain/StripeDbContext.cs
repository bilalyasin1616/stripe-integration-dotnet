using Domain.Extensions;
using Domain.Models;
using Domain.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class StripeDbContext : DbContext
    {
        IClientStateService State { get; }
        public StripeDbContext(DbContextOptions<StripeDbContext> options, IClientStateService stateService) : base(options)
        {
            State = stateService;
        }

        public virtual DbSet<User> User { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
                    modelBuilder.SetSoftDeleteFilter(entityType.ClrType);
            }

            base.OnModelCreating(modelBuilder);
        }

        private void ProcessSave()
        {
            var currentTime = DateTimeOffset.UtcNow;
            foreach (var item in ChangeTracker.Entries().Where(e => e.Entity is Entity))
            {

                var entity = item.Entity as Entity;
                if (item.State == EntityState.Added)
                {
                    AuditAdd(entity, item);
                    AuditUpdate(entity, item);
                    entity.IsActive = true;
                }
                else if(item.State == EntityState.Modified)
                {
                    AuditUpdate(entity, item);
                    SetCreateFieldsNotModified(entity, item);
                    item.Property(nameof(entity.IsActive)).IsModified = false;
                }
                else if(item.State == EntityState.Deleted)
                {
                    item.State = EntityState.Modified;
                    item.Members.ToList().ForEach(_ => _.IsModified = false);
                    AuditUpdate(entity, item);
                    item.Property(nameof(entity.IsActive)).IsModified = true;
                    entity.IsActive = false;
                }
            }
        }

        private void AuditAdd(Entity entity, EntityEntry item)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.CreatedByName = State.UserName;
            entity.CreatedById = State.UserId;
            item.Property(nameof(entity.DateCreated)).IsModified = true;
            item.Property(nameof(entity.CreatedByName)).IsModified = true;
            item.Property(nameof(entity.CreatedById)).IsModified = true;
        }

        private void AuditUpdate(Entity entity, EntityEntry item)
        {
            entity.DateLastUpdated = DateTime.UtcNow;
            entity.LastUpdateByName = State.UserName;
            entity.LastUpdatedById = State.UserId;
        }

        private void SetCreateFieldsNotModified(Entity entity, EntityEntry item)
        {
            item.Property(nameof(entity.DateCreated)).IsModified = false;
            item.Property(nameof(entity.CreatedByName)).IsModified = false;
            item.Property(nameof(entity.CreatedById)).IsModified = false;
        }
    }
}
