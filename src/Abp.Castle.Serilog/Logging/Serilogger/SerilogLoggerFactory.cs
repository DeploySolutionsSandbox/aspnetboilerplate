using System;
using Castle.Core.Logging;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace Abp.Logging.Serilogger
{
    public class SerilogLoggerFactory : AbstractLoggerFactory
    {
        private readonly Serilog.ILogger _logger;

        public SerilogLoggerFactory()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public SerilogLoggerFactory(LoggerConfiguration loggerConfiguration)
        {
            if (loggerConfiguration == null)
            {
                throw new ArgumentNullException(nameof(loggerConfiguration));
            }

            _logger = loggerConfiguration.CreateLogger();
        }

        public override Castle.Core.Logging.ILogger Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new SerilogLogger(_logger.ForContext("SourceContext", name));
        }

        public override Castle.Core.Logging.ILogger Create(string name, LoggerLevel level)
        {
            throw new NotSupportedException("Logger levels cannot be set at runtime. Please configure levels in your Serilog configuration.");
        }
    }
}