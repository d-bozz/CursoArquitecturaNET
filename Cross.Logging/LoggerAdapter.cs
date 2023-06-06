using Cross.Common;
using Microsoft.Extensions.Logging;

namespace Cross.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        #region Properties and Fields

        private readonly ILogger<T> _logger;

        public LoggerAdapter (ILoggerFactory loggerFactory)
        {
           _logger = loggerFactory.CreateLogger<T>();
        }

        #endregion

        #region Methods

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        #endregion
    }
}