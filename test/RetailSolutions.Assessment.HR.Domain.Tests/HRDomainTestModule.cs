using RetailSolutions.Assessment.HR.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace RetailSolutions.Assessment.HR;

[DependsOn(
    typeof(HREntityFrameworkCoreTestModule)
    )]
public class HRDomainTestModule : AbpModule
{

}
