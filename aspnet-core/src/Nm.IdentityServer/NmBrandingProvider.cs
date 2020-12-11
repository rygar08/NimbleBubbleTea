using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Nm
{
    [Dependency(ReplaceServices = true)]
    public class NmBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Nm";
    }
}
