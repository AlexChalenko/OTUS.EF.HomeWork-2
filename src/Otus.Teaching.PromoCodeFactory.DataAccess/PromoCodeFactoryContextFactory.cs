using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Otus.Teaching.PromoCodeFactory.DataAccess
{
    public class PromoCodeFactoryContextFactory : IDesignTimeDbContextFactory<PromoCodeFactoryContext>
    {
        public PromoCodeFactoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PromoCodeFactoryContext>();
            optionsBuilder.UseSqlite("Data Source=promocodefactory.db");

            return new PromoCodeFactoryContext(optionsBuilder.Options);
        }
    }
}
