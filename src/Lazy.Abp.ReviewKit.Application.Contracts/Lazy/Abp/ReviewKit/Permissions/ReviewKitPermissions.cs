using Volo.Abp.Reflection;

namespace Lazy.Abp.ReviewKit.Permissions
{
    public class ReviewKitPermissions
    {
        public const string GroupName = "ReviewKit";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ReviewKitPermissions));
        }
    }
}
