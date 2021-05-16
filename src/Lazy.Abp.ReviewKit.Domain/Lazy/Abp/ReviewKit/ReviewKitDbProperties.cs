namespace Lazy.Abp.ReviewKit
{
    public static class ReviewKitDbProperties
    {
        public static string DbTablePrefix { get; set; } = "ReviewKit";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "ReviewKit";
    }
}
