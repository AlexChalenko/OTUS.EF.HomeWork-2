using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.DataAccess.Data;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.DataConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(FakeDataFactory.Employees);
            builder.HasOne(r => r.Role).WithMany(e => e.Employees).HasForeignKey(r => r.RoleId);
            builder.HasMany(e => e.PromoCodes).WithOne(pc => pc.PartnerManager).HasForeignKey(pc => pc.PartnerManagerId);
            builder.Property(fn => fn.FirstName).HasMaxLength(50);
            builder.Property(ln => ln.LastName).HasMaxLength(50);
            builder.Property(e => e.Email).HasMaxLength(50);
        }
    }
}
