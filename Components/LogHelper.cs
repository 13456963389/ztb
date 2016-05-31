using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZtbSoft.Components
{
    public class LogHelper<T>
    {
        public LogHelper()
        {

        }

        private static readonly log4net.ILog loginfo = LogManager.GetLogger(typeof(T).Name);

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }


        public static void WriteLog(string info)
        {
            loginfo.Info(info);
        }

        public static void WriteLog(string info, Exception ex)
        {
            loginfo.Error(info, ex);
        }

    }

    public enum enum_LogLevel
    {
        /// <summary>
        /// 日志等级为INFO
        /// </summary>
        info = 1,
        /// <summary>
        /// 日志等级为ERROR
        /// </summary>
        error = 2
    }
}
