using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(FakeDataFactory.Customers);
            builder.Property(с => с.FirstName).HasMaxLength(50);
            builder.Property(с => с.LastName).HasMaxLength(50);
            builder.Property(с => с.Email).HasMaxLength(50);
        }
    }
}
