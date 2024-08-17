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
    public class ExtraActivityConfiguration : IEntityTypeConfiguration<ExtraActivity>
    {
        public void Configure(EntityTypeBuilder<ExtraActivity> builder)
        {
            // Key configuration
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .IsRequired();

            // Relationships
            builder.HasMany(e => e.Schedules)
                   .WithOne(s => s.ExtraActivity)
                   .HasForeignKey(s => s.ExtraActivityId)
                   .OnDelete(DeleteBehavior.Cascade);

            // UserCreated and UserModified relationships
            builder.HasOne(e => e.UserCreated)
                   .WithMany()
                   .HasForeignKey(e => e.UserCreatedId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.UserModified)
                   .WithMany()
                   .HasForeignKey(e => e.UserModifiedId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
