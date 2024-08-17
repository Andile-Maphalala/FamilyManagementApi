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
    public class UserAvailabilityConfiguration : IEntityTypeConfiguration<UserAvailability>
    {
        public void Configure(EntityTypeBuilder<UserAvailability> builder)
        {
            //Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(e => e.Date)
                   .IsRequired();

            builder.Property(e => e.TimeSlot)
                   .HasConversion<int>() // Store enum as int
                   .IsRequired();

            // Relationships
            builder.HasOne(ua => ua.User)
                   .WithMany(u => u.UserAvailability)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // UserCreated and UserModified relationships
            builder.HasOne(ua => ua.UserCreated)
                   .WithMany()
                   .HasForeignKey(ua => ua.UserCreatedId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ua => ua.UserModified)
                   .WithMany()
                   .HasForeignKey(ua => ua.UserModifiedId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
