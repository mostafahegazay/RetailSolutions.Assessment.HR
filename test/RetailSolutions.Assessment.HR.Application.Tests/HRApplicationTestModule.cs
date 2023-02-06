using Volo.Abp.Modularity;

namespace RetailSolutions.Assessment.HR;

[DependsOn(
    typeof(HRApplicationModule),
    typeof(HRDomainTestModule)
    )]
public class HRApplicationTestModule : AbpModule
{

}
