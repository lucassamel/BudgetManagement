using BudgetManagement.Domain.Entities.Outlay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetManagement.Infra.Data.EntitiesConfiguration
{
    public class SpentConfiguration : IEntityTypeConfiguration<Spent>
    {
        public void Configure(EntityTypeBuilder<Spent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdCategory).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100);

            builder.HasOne(x => x.Category).WithMany(x => x.Spents)
                .HasForeignKey(x => x.IdCategory).IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.User).WithMany(x => x.Spents)
                .HasForeignKey(x =>x.IdUser).IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
