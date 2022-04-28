using Common.SharedKernel.Settings;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Common.SharedKernel.Serilog
{
    public static class SerilogConfig
    {
        private const string SourceName = "Microsoft";
        private const string Assembly = nameof(Assembly);
        public static void Initialize(HostBuilderContext ctx, LoggerConfiguration lc, SerilogSettings seriloggerSettings) =>
            lc.MinimumLevel.Override(SourceName, LogEventLevel.Information)
              .Enrich.WithMachineName()
              .Enrich.FromLogContext()
              .Enrich.WithProperty(Assembly, System.Reflection.Assembly.GetEntryAssembly().GetName())
              .WriteTo.Seq(serverUrl: seriloggerSettings.SeqServerUrl)
              .WriteTo.Console();
           
    }
}
