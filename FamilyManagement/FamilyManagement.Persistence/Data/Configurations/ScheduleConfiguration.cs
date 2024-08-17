using FamilyManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Persistence.Data.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            // Key configuration
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(e => e.PickupLocation)
                   .HasMaxLength(255)
                   .IsUnicode(false)
                   .IsRequired(false);

            builder.Property(e => e.Notes)
                   .IsUnicode(false)
                   .IsRequired(false);

            // Relationships
            builder.HasOne(s => s.PickupPerson)
                   .WithMany(u => u.PickupSchedules)
                   .HasForeignKey(s => s.PickupPersonId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.DropoffPerson)
                   .WithMany(u => u.DropoffSchedules)
                   .HasForeignKey(s => s.DropoffPersonId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ExtraActivity)
                   .WithMany(e => e.Schedules)
                   .HasForeignKey(s => s.ExtraActivityId)
                   .OnDelete(DeleteBehavior.Cascade);

            // UserCreated and UserModified relationships
            builder.HasOne(s => s.UserCreated)
                   .WithMany()
                   .HasForeignKey(s => s.UserCreatedId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.UserModified)
                   .WithMany()
                   .HasForeignKey(s => s.UserModifiedId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
