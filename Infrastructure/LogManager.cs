using log4net;
using log4net.Config;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;

namespace AspMVCAdminLTE.Infrastructure
{
    public class LogManager : ILogManager
    {
        private readonly ILogger defaultLogger;

        public LogManager()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(HttpContext.Current.Server.MapPath("~/Configs/log4net.config")));
            defaultLogger = LoggerManager.GetLogger(Assembly.GetCallingAssembly(), "MyDefaultLoggger");
        }

        public void LogDebug(object message)
        {
            this.Log(Level.Debug, message);
        }

        public void LogError(object message, Exception exception=null)
        {
            this.Log(Level.Error, message, exception);
        }

        public void LogInfo(object message)
        {
            this.Log(Level.Info, message);
        }

        private void Log(Level logLevel, object message, Exception exception=null)
        {
            if (defaultLogger.IsEnabledFor(logLevel))
            {
                defaultLogger.Log(typeof(LogManager), logLevel, message, exception);
            }
        }
    }
}