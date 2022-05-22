using CoffeeShops.API.Attributes;
using CoffeeShops.API.Models;
using CoffeeShops.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.API.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
            Claim claim = null;
            if (principal.HasClaim(x => x.Type == "username"))
            {
                claim = new Claim("username", identity.Name);
                identity.AddClaim(claim);
            }
            if (principal.HasClaim(x => x.Type == "logintime"))
            {
                claim = new Claim("logintime", DateTime.Now.ToString());
                identity.AddClaim(claim);
            }

            return principal;
        }
        public async Task Invoke(HttpContext httpContext,UserContext userContext, IOptions<AppSettings> options)
        {

            var endpoint = httpContext.GetEndpoint();
            var data = endpoint != null ? endpoint?.Metadata.OfType<IAuthorizeData>() : new List<IAuthorizeData>();

            if (data.Any())
            {
                var token = httpContext.Request.Headers.FirstOrDefault(r => r.Key == "token");
                if (string.IsNullOrEmpty(token.Value)) 
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(options.Value.TokenKey);
                try
                {
                    tokenHandler.ValidateToken(token.Value, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    userContext.UserId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);
                    userContext.CompanyId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "CompanyId").Value);
                             
                }
                catch
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }


            }

            await _next.Invoke(httpContext);
        }
    }
}
