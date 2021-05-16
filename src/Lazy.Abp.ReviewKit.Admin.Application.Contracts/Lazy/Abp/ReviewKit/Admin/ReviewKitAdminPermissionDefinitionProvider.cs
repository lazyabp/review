using Lazy.Abp.ReviewKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.ReviewKit.Admin
{
    public class ReviewKitAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ReviewKitAdminPermissions.GroupName, L("Permission:ReviewKitAdmin"));

            var reviewPermission = myGroup.AddPermission(ReviewKitAdminPermissions.Review.Default, L("Permission:Review"));
            reviewPermission.AddChild(ReviewKitAdminPermissions.Review.Create, L("Permission:Create"));
            reviewPermission.AddChild(ReviewKitAdminPermissions.Review.Update, L("Permission:Update"));
            reviewPermission.AddChild(ReviewKitAdminPermissions.Review.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ReviewKitResource>(name);
        }
    }
}
