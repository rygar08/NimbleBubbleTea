using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Nm.EntityFrameworkCore
{
    [DependsOn(
        typeof(NmEntityFrameworkCoreModule)
        )]
    public class NmEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<NmMigrationsDbContext>();
        }
    }
}
