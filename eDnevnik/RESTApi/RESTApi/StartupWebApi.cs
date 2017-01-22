using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using static RESTApi.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.Owin.Security.Jwt;

[assembly: OwinStartup("WebApiConfig", typeof(RESTApi.StartupWebApi))]

namespace RESTApi
{
    public partial class StartupWebApi
    {
        public void Configuration(IAppBuilder app)
        {
            var signKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("eDnevnikTokenSecret2017"));
            var options = new TokenProviderOptions
            {
                Audience = "All",
                Issuer = "localhost",
                SigningCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256),
            };

            app.Use<TokenProviderMiddleware>(Options.Create(options));
        }
    }
}
