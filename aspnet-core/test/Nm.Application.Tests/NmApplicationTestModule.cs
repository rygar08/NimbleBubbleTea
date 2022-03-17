using Volo.Abp.Modularity;

namespace Nm;

[DependsOn(
    typeof(NmApplicationModule),
    typeof(NmDomainTestModule)
    )]
public class NmApplicationTestModule : AbpModule
{

}
