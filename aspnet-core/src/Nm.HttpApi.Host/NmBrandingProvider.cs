using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Nm
{
    [Dependency(ReplaceServices = true)]
    public class NmBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Nm";
    }
}
