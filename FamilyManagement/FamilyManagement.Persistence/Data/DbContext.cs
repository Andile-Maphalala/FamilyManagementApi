using FamilyManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FamilyManagement.Persistence.Data
{
    public partial class FamilyManagementDbContext : IdentityDbContext<User>
    {
        public FamilyManagementDbContext(DbContextOptions<FamilyManagementDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ExtraActivity> ExtraActivitities { get; set; }
        public virtual DbSet<UserAvailability> UserAvailability { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FamilyManagementDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new Configurations.UserAvailabilityConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ExtraActivityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
