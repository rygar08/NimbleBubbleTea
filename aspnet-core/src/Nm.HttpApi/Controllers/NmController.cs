using Nm.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Nm.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class NmController : AbpController
    {
        protected NmController()
        {
            LocalizationResource = typeof(NmResource);
        }
    }
}