using RetailSolutions.Assessment.HR.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RetailSolutions.Assessment.HR.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HRController : AbpControllerBase
{
    protected HRController()
    {
        LocalizationResource = typeof(HRResource);
    }
}
