using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using RaffleAPI.Infrastructure.Security.Security;

namespace RaffleAPI.Infrastructure.Security
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddAuthentication("ApiKeyAuthentication")
                .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKeyAuthentication", null);

            return services; 
        }
    }
}
