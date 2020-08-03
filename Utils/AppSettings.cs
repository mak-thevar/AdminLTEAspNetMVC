using System.Configuration;

namespace AspMVCAdminLTE.Utils
{
    public static class AppSettings
    {
        public static string EncrKey { get; set; } = ConfigurationManager.AppSettings["EncryptionKey"];
        public static string BrandTitle { get; } = "AdminLTEAspNetMVC";
        public static string FooterText { get; } = "2014-2019 <a href='https://github.com/mak-thevar/AdminLTEAspNetMVC'>AdminLTEAspNetMVC</a>.</strong>";
        public static string BrandImg { get; set; } = "/WebCore/dist/img/AdminLTELogo.png";
    }
}