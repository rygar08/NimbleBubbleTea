using Nm.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Nm.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(NmEntityFrameworkCoreDbMigrationsModule),
        typeof(NmApplicationContractsModule)
        )]
    public class NmDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
