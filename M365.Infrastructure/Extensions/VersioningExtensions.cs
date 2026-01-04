using Asp.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace M365.Infrastructure.Extensions;

public static class VersioningExtensions
{
    public static void AddCustomApiVersioning(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.ReportApiVersions = true;
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ApiVersionReader = new UrlSegmentApiVersionReader();
        });
    }
}