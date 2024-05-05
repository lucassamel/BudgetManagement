using BudgetManagement.Domain.Entities.Outlay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetManagement.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(200);   
            
            builder.HasMany(x => x.Spents).WithOne(x => x.Category)
                .HasForeignKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Categories)
                .HasForeignKey(x => x.IdUser);
        }
    }
}
