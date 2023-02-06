using RetailSolutions.Assessment.HR.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RetailSolutions.Assessment.HR.Permissions;

public class HRPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HRPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HRPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HRResource>(name);
    }
}
