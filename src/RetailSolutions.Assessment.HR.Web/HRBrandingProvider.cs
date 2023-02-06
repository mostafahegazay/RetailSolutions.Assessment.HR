using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace RetailSolutions.Assessment.HR.Web;

[Dependency(ReplaceServices = true)]
public class HRBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HR";
}
