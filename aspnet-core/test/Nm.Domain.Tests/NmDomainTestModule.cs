using Nm.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Nm
{
    [DependsOn(
        typeof(NmEntityFrameworkCoreTestModule)
        )]
    public class NmDomainTestModule : AbpModule
    {

    }
}