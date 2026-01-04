using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace M365.Infrastructure.Authentication;

public sealed class DevAuthHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    IConfiguration cfg)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!cfg.GetValue<bool>("DevAuth:Enabled"))
            return Task.FromResult(AuthenticateResult.NoResult());

        var claims = new[]
        {
            new Claim("userId", cfg["DevAuth:UserId"]!)
        };

        var identity = new ClaimsIdentity(claims, "Dev");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "Dev");

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}