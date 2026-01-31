using Castle.Facilities.Logging;

namespace Abp.Logging.Serilogger
{
    public static class LoggingFacilityExtensions
    {
        public static LoggingFacility UseAbpSerilog(this LoggingFacility loggingFacility)
        {
            return loggingFacility.LogUsing<SerilogLoggerFactory>();
        }
    }
}