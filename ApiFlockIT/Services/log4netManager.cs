using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace ApiFlockIT.Services
{
    public interface Ilog4netManager
    {
        void LogInfo(string msg);
        void LogDebug(string msg);
        void LogWarn(string msg);
        void LogError(string msg, Exception ex = null);
    }
    public class log4netManager: Ilog4netManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(log4netManager));

        public log4netManager()
        {
            try
            {
                var repository = LogManager.GetRepository(Assembly.GetCallingAssembly());

                var fileInfo = new FileInfo(@"log4net.config");

                XmlConfigurator.Configure(repository, fileInfo);

                _logger.Debug("Logger initialized");
            }
            catch (Exception ex)
            {
                _logger.Error("Error at init logger", ex);
            }
        }

        public void LogDebug(string msg) => _logger.Debug(msg);

        public void LogInfo(string msg) => _logger.Info(msg);

        public void LogWarn(string msg) => _logger.Warn(msg);

        public void LogError(string msg, Exception ex = null)
        {
            if (ex != null)
                _logger.Error(msg, ex);

            _logger.Error(msg);
        }
    }
}
