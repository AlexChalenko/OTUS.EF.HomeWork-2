using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration
{
    public class PreferenceConfiguration : IEntityTypeConfiguration<Preference>
    {
        public void Configure(EntityTypeBuilder<Preference> builder)
        {
            builder.HasData(FakeDataFactory.Preferences);
            builder.Property(n => n.Name).HasMaxLength(50);
            builder.HasMany(p => p.PromoCodes).WithOne(p => p.Preference).HasForeignKey(p => p.PreferenceId);
        }
    }
}
