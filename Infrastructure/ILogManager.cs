using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMVCAdminLTE.Infrastructure
{
    public interface ILogManager
    {
        void LogInfo(object message);
        void LogError(object message, Exception exception = null);
        void LogDebug(object message);
    }
}