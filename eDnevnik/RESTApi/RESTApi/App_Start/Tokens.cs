using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Repository;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.Owin;

namespace RESTApi
{
    public class Tokens
    {
        public class TokenProviderOptions
        {
            public string Path { get; set; } = "/api/Login";

            public string Issuer { get; set; }

            public string Audience { get; set; }

            public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(356);

            public SigningCredentials SigningCredentials { get; set; }
        }

        public class TokenProviderMiddleware : OwinMiddleware
        {
            private readonly OwinMiddleware _next;
            private readonly TokenProviderOptions _options;

            public TokenProviderMiddleware(OwinMiddleware next, IOptions<TokenProviderOptions> options) : base(next)
            {
                _next = next;
                _options = options.Value;
            }

            public override Task Invoke(IOwinContext context)
            {
                // If the request path doesn't match, skip
                var v = context.Request.Path;

                if (!context.Request.Path.ToString().Equals(_options.Path))
                {
                    return _next.Invoke(context);
                }

                // Request must be POST with Content-Type: application/x-www-form-urlencoded
                if (!context.Request.Method.Equals("POST"))
                {
                    context.Response.StatusCode = 400;
                    return context.Response.WriteAsync("Bad request.");
                }

                return GenerateToken(context);
            }

            private IAutorizacijaRepository _repo = new AutorizacijaRepository();

            private async Task GenerateToken(IOwinContext context)
            {
                var data = context.Request.ReadFormAsync().Result as IEnumerable<KeyValuePair<string, string[]>>;

                var email = data.FirstOrDefault(k => k.Key == "Email").Value[0];
                var password = data.FirstOrDefault(k => k.Key == "Password").Value[0];
                var uloga = data.FirstOrDefault(k => k.Key == "Uloga").Value[0];

                var o = _repo.GetByLoginInfo(email, password, uloga);
                if (o == null)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid username or password.");
                    return;
                }

                var now = DateTime.UtcNow;

                // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
                // You can add other claims here, if you want:
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Sid, o.idOsoba.ToString()),
                    new Claim(ClaimTypes.Role, uloga)
                };

                // Create the JWT and write it to a string
                var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(_options.Expiration),
                    signingCredentials: _options.SigningCredentials);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = "Bearer " + encodedJwt,
                };

                // Serialize and return the response
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }
        }
    }
}