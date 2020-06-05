using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AspMVCAdminLTE.Utils
{
    public static class AppSettings
    {
        public static string EncrKey { get; set; } = ConfigurationManager.AppSettings["EncryptionKey"];
    }
}