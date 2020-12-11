
using System;
using System.Threading.Tasks;
using Nm.CupSizes;
using Nm.Flavours;
using Nm.Teas;
using Nm.Toppings;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Km {
    public class NmDataSeederContributor
         : IDataSeedContributor, ITransientDependency {
        private readonly IRepository<Tea, Guid> teaR;
        private readonly IRepository<Topping, Guid> toppingR;
        private readonly IRepository<Flavour, Guid> flavourR;
        private readonly IRepository<CupSize, string> cupSizeR;

        public NmDataSeederContributor(
                IRepository<Tea, Guid> teaR,
                IRepository<Topping, Guid> toppingR,
                IRepository<Flavour, Guid> flavourR,
                IRepository<CupSize, string> cupSizeR) {
            this.teaR = teaR;
            this.toppingR = toppingR;
            this.flavourR = flavourR;
            this.cupSizeR = cupSizeR;
        }

        public async Task SeedAsync(DataSeedContext context) {
            if (await teaR.GetCountAsync() > 0) {
                return;
            }

            /* Seed additional test data... */
            // Happy List Kids 

            await cupSizeR.InsertAsync(new CupSize("S") { Name = "Small" }, true);
            await cupSizeR.InsertAsync(new CupSize("M") { Name = "Medium" }, true);
            await cupSizeR.InsertAsync(new CupSize("L") { Name = "Large" }, true);

            await teaR.InsertAsync(new Tea { Name = "Black Tea" }, true);
            await teaR.InsertAsync(new Tea { Name = "Milk Tea" }, true);  

            await flavourR.InsertAsync(new Flavour { Name = "Lemon" }, true);
            await flavourR.InsertAsync(new Flavour { Name = "Passionfruit" }, true);
            await flavourR.InsertAsync(new Flavour { Name = "Yogurt" }, true); 

            await toppingR.InsertAsync(new Topping { Name = "Boba" }, true);
            await toppingR.InsertAsync(new Topping { Name = "Red Bean" }, true);
            await toppingR.InsertAsync(new Topping { Name = "Ai-Yu Jelly" }, true);
            await toppingR.InsertAsync(new Topping { Name = "Basil Seeds" }, true);
             

        }
    }
}
