using LazyAbp.ReviewKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LazyAbp.ReviewKit.Permissions
{
    public class ReviewKitPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ReviewKitPermissions.GroupName, L("Permission:ReviewKit"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ReviewKitResource>(name);
        }
    }
}
