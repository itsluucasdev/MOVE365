using Microsoft.AspNetCore.Builder;
using Serilog;

namespace M365.Infrastructure.Extensions;

public static class LoggingExtensions
{
    public static void AddCustomUseSerilog(this ConfigureHostBuilder host)
    {
        host.UseSerilog((ctx, cfg) =>
        {
            cfg
                .Enrich.FromLogContext()
                .WriteTo.Console();
        });
    }
}
