using RetailSolutions.Assessment.HR.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace RetailSolutions.Assessment.HR.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HREntityFrameworkCoreModule),
    typeof(HRApplicationContractsModule)
    )]
public class HRDbMigratorModule : AbpModule
{

}
