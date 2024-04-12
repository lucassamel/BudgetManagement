using BudgetManagement.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Infra.Data.EntitiesConfiguration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.NickName).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Spents).WithOne(x => x.Profile)
                .HasForeignKey(x => x.IdProfile).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Categories).WithOne(x => x.Profile)
                .HasForeignKey(x => x.IdProfile).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
