using Nm.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Nm.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NmEntityFrameworkCoreModule),
    typeof(NmApplicationContractsModule)
    )]
public class NmDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
