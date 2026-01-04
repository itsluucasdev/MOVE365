using System.Text;
using M365.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace M365.Infrastructure.Extensions;

public static class AuthenticationExtensions
{
    public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = cfg["Jwt:Issuer"],
                    ValidAudience = cfg["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(cfg["Jwt:Key"]!)
                    )
                };
            });
        
        services.AddAuthentication("Dev")
            .AddScheme<AuthenticationSchemeOptions, DevAuthHandler>("Dev", _ => { });
    }
}