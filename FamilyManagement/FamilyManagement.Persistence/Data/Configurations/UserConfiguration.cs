using FamilyManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Persistence.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Key configuration
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(e => e.ProfilePicture)
                   .HasColumnType("bytea");

            builder.Property(e => e.IsActive)
                   .IsRequired()
               .HasDefaultValue(true); 

            // Relationship configurations
            builder.HasMany(u => u.UserAvailability)
                   .WithOne(ua => ua.User)
                   .HasForeignKey(ua => ua.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.PickupSchedules)
                   .WithOne(s => s.PickupPerson)
                   .HasForeignKey(s => s.PickupPersonId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.DropoffSchedules)
                   .WithOne(s => s.DropoffPerson)
                   .HasForeignKey(s => s.DropoffPersonId)
                   .OnDelete(DeleteBehavior.SetNull);

        }

    }
}

