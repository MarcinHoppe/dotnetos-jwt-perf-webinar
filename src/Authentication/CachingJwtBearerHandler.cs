using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace Dotnetos.Authentication
{
    class CachingJwtBearerHandler : JwtBearerHandler
    {
        private IMemoryCache memoryCache;

        public CachingJwtBearerHandler(
            IMemoryCache memoryCache,
            IOptionsMonitor<JwtBearerOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
            this.memoryCache = memoryCache;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authorization = Request.Headers[HeaderNames.Authorization];

            if (memoryCache.TryGetValue(authorization, out var cachedAuthResult))
            {
                return cachedAuthResult as AuthenticateResult;
            }
            
            var authResult = await base.HandleAuthenticateAsync();
            
            if (authResult.Succeeded)
            {
                memoryCache.Set(Request.Headers[HeaderNames.Authorization], authResult);
            }

            return authResult;
        }
    }
}