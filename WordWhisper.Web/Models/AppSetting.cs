namespace WordWhisper.Web.Models
{
    public static class AppSetting
    {
        public static string ConnectionString { get; set; }
        public static string JwtIssuer { get; set; }
        public static string JwtAudience { get; set; }
        public static string JwtSigninKey { get; set; }
    }
}
