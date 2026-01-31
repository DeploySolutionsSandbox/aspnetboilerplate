using Abp.Modules;

namespace Abp.Logging.Serilogger
{
    /// <summary>
    /// ABP Castle Serilog module.
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpSerilogModule : AbpModule
    {

    }
}