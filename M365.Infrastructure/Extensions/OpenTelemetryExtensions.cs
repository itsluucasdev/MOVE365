using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace M365.Infrastructure.Extensions;

public static class OpenTelemetryExtensions
{
    public static void AddCustomOpenTelemetry(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddOpenTelemetry()
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter(o => { o.Endpoint = new Uri(cfg["OpenTelemetry:Otlp:Endpoint"]!); });
            })
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter(o => { o.Endpoint = new Uri(cfg["OpenTelemetry:Otlp:Endpoint"]!); });
            });
    }
}