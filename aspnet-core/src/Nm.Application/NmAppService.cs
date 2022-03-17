using System;
using System.Collections.Generic;
using System.Text;
using Nm.Localization;
using Volo.Abp.Application.Services;

namespace Nm;

/* Inherit your application services from this class.
 */
public abstract class NmAppService : ApplicationService
{
    protected NmAppService()
    {
        LocalizationResource = typeof(NmResource);
    }
}
