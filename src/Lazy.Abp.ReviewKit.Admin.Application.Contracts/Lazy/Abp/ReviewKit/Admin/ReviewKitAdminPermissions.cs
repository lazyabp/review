using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace Lazy.Abp.ReviewKit.Admin
{
    public class ReviewKitAdminPermissions
    {
        public const string GroupName = "ReviewKit.Admin";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ReviewKitAdminPermissions));
        }

        public class Review
        {
            public const string Default = GroupName + ".Review";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Audit = Default + ".Audit";
        }
    }
}
