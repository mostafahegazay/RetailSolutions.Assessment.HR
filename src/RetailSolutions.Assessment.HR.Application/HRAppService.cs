using System;
using System.Collections.Generic;
using System.Text;
using RetailSolutions.Assessment.HR.Localization;
using Volo.Abp.Application.Services;

namespace RetailSolutions.Assessment.HR;

/* Inherit your application services from this class.
 */
public abstract class HRAppService : ApplicationService
{
    protected HRAppService()
    {
        LocalizationResource = typeof(HRResource);
    }
}
