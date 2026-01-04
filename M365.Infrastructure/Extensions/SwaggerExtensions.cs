using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace M365.Infrastructure.Extensions;

public static class SwaggerExtensions
{
    public static void AddCustomSwaggerGen(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MOVE365 API",
                Version = "v1",
                Description = "API for MOVE365 Project"
            });

            c.EnableAnnotations();

            c.CustomSchemaIds(x => x.FullName);

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "JWT Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(document =>
                new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecuritySchemeReference("Bearer", document)
                    ] = []
                });
        });
    }
}