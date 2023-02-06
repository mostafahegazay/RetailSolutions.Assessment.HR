using RetailSolutions.Assessment.HR.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace RetailSolutions.Assessment.HR.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class HRPageModel : AbpPageModel
{
    protected HRPageModel()
    {
        LocalizationResourceType = typeof(HRResource);
    }
}
