using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration
{
    public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            builder.HasData(FakeDataFactory.PromoCodes);
            builder.HasOne(c => c.Customer).WithMany(p => p.PromoCodes).HasForeignKey(fk => fk.CustomerId);
            builder.HasOne(c => c.PartnerManager).WithMany(p => p.PromoCodes).HasForeignKey(fk => fk.PartnerManagerId);
            builder.HasOne(c => c.Preference).WithMany(p => p.PromoCodes).HasForeignKey(fk => fk.PreferenceId);

            builder.Property(c => c.Code).HasMaxLength(15);
            builder.Property(si => si.ServiceInfo).HasMaxLength(50);
        }
    }
}
