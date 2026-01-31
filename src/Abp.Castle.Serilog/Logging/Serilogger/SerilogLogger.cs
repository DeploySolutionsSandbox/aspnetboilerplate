using System;
using System.Globalization;
using Castle.Core.Logging;
using Serilog;
using Serilog.Events;

namespace Abp.Logging.Serilogger
{
    public class SerilogLogger : MarshalByRefObject, Castle.Core.Logging.ILogger
    {
        private readonly Serilog.ILogger _logger;

        public SerilogLogger(Serilog.ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool IsDebugEnabled => _logger.IsEnabled(LogEventLevel.Debug);
        public bool IsErrorEnabled => _logger.IsEnabled(LogEventLevel.Error);
        public bool IsFatalEnabled => _logger.IsEnabled(LogEventLevel.Fatal);
        public bool IsInfoEnabled => _logger.IsEnabled(LogEventLevel.Information);
        public bool IsWarnEnabled => _logger.IsEnabled(LogEventLevel.Warning);
        public bool IsTraceEnabled => _logger.IsEnabled(LogEventLevel.Verbose);

        public Castle.Core.Logging.ILogger CreateChildLogger(string name)
        {
            return new SerilogLogger(_logger.ForContext("SourceContext", name));
        }

        public void Debug(string message) => _logger.Debug(message);
        public void Debug(Func<string> messageFactory) => _logger.Debug(messageFactory());
        public void Debug(string message, Exception exception) => _logger.Debug(exception, message);
        public void DebugFormat(string format, params object[] args) => _logger.Debug(string.Format(CultureInfo.InvariantCulture, format, args));
        public void DebugFormat(Exception exception, string format, params object[] args) => _logger.Debug(exception, string.Format(CultureInfo.InvariantCulture, format, args));
        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args) => _logger.Debug(string.Format(formatProvider, format, args));
        public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args) => _logger.Debug(exception, string.Format(formatProvider, format, args));

        public void Error(string message) => _logger.Error(message);
        public void Error(Func<string> messageFactory) => _logger.Error(messageFactory());
        public void Error(string message, Exception exception) => _logger.Error(exception, message);
        public void ErrorFormat(string format, params object[] args) => _logger.Error(string.Format(CultureInfo.InvariantCulture, format, args));
        public void ErrorFormat(Exception exception, string format, params object[] args) => _logger.Error(exception, string.Format(CultureInfo.InvariantCulture, format, args));
        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args) => _logger.Error(string.Format(formatProvider, format, args));
        public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args) => _logger.Error(exception, string.Format(formatProvider, format, args));

        public void Fatal(string message) => _logger.Fatal(message);
        public void Fatal(Func<string> messageFactory) => _logger.Fatal(messageFactory());
        public void Fatal(string message, Exception exception) => _logger.Fatal(exception, message);
        public void FatalFormat(string format, params object[] args) => _logger.Fatal(string.Format(CultureInfo.InvariantCulture, format, args));
        public void FatalFormat(Exception exception, string format, params object[] args) => _logger.Fatal(exception, string.Format(CultureInfo.InvariantCulture, format, args));
        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args) => _logger.Fatal(string.Format(formatProvider, format, args));
        public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args) => _logger.Fatal(exception, string.Format(formatProvider, format, args));

        public void Info(string message) => _logger.Information(message);
        public void Info(Func<string> messageFactory) => _logger.Information(messageFactory());
        public void Info(string message, Exception exception) => _logger.Information(exception, message);
        public void InfoFormat(string format, params object[] args) => _logger.Information(string.Format(CultureInfo.InvariantCulture, format, args));
        public void InfoFormat(Exception exception, string format, params object[] args) => _logger.Information(exception, string.Format(CultureInfo.InvariantCulture, format, args));
        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args) => _logger.Information(string.Format(formatProvider, format, args));
        public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args) => _logger.Information(exception, string.Format(formatProvider, format, args));

        public void Trace(string message) => _logger.Verbose(message);
        public void Trace(Func<string> messageFactory) => _logger.Verbose(messageFactory());
        public void Trace(string message, Exception exception) => _logger.Verbose(exception, message);
        public void TraceFormat(string format, params object[] args) => _logger.Verbose(string.Format(CultureInfo.InvariantCulture, format, args));
        public void TraceFormat(Exception exception, string format, params object[] args) => _logger.Verbose(exception, string.Format(CultureInfo.InvariantCulture, format, args));
        public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args) => _logger.Verbose(string.Format(formatProvider, format, args));
        public void TraceFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args) => _logger.Verbose(exception, string.Format(formatProvider, format, args));

        public void Warn(string message) => _logger.Warning(message);
        public void Warn(Func<string> messageFactory) => _logger.Warning(messageFactory());
        public void Warn(string message, Exception exception) => _logger.Warning(exception, message);
        public void WarnFormat(string format, params object[] args) => _logger.Warning(string.Format(CultureInfo.InvariantCulture, format, args));
        public void WarnFormat(Exception exception, string format, params object[] args) => _logger.Warning(exception, string.Format(CultureInfo.InvariantCulture, format, args));
        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args) => _logger.Warning(string.Format(formatProvider, format, args));
        public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args) => _logger.Warning(exception, string.Format(formatProvider, format, args));
    }
}