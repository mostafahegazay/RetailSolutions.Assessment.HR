using Microsoft.Extensions.DependencyInjection;
using RetailSolutions.Assessment.HR.Seed;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace RetailSolutions.Assessment.HR;

[DependsOn(
    typeof(HRDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(HRApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class HRApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<HRApplicationModule>();
        });

       context.Services.AddScoped<IHRDataSeederContributor, HRDataSeederContributor>();
    }
}
