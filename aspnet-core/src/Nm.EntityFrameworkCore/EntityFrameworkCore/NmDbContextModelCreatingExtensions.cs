using Nm.Bookings;
using Nm.Toppings;
using Nm.Flavours;
using Nm.Teas;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Nm.EntityFrameworkCore
{
    public static class NmDbContextModelCreatingExtensions
    {
        public static void ConfigureNm(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */  

            builder.Entity<Tea>(b =>
            {
                b.ToTable(NmConsts.DbTablePrefix + "Teas", NmConsts.DbSchema);
                b.ConfigureByConvention();  
            });


            builder.Entity<Flavour>(b =>
            {
                b.ToTable(NmConsts.DbTablePrefix + "Flavours", NmConsts.DbSchema);
                b.ConfigureByConvention();  
            });


            builder.Entity<Topping>(b =>
            {
                b.ToTable(NmConsts.DbTablePrefix + "Toppings", NmConsts.DbSchema);
                b.ConfigureByConvention();  
            });


            builder.Entity<CupSizes.CupSize>(b => {
                b.ToTable(NmConsts.DbTablePrefix + "CupSizes", NmConsts.DbSchema);
                b.ConfigureByConvention();
            });



            builder.Entity<Tea>(b =>
            {
                b.ToTable(NmConsts.DbTablePrefix + "Teas", NmConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<Flavour>(b =>
            {
                b.ToTable(NmConsts.DbTablePrefix + "Flavours", NmConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<Topping>(b =>
            {
                b.ToTable(NmConsts.DbTablePrefix + "Toppings", NmConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<Booking>(b =>
            {
                b.ToTable(NmConsts.DbTablePrefix + "Bookings", NmConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }
    }
}
