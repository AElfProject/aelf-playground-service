using AElf.Playground.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AElf.Playground.Permissions;

public class PlaygroundPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PlaygroundPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(PlaygroundPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PlaygroundResource>(name);
    }
}
