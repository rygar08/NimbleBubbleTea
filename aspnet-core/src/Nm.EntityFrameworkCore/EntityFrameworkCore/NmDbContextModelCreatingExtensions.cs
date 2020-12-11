using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Nm.EntityFrameworkCore
{
    public static class NmDbContextModelCreatingExtensions
    {
        public static void ConfigureNm(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(NmConsts.DbTablePrefix + "YourEntities", NmConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}