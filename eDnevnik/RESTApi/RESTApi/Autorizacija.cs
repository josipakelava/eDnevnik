using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RESTApi
{
    public class Autorizacija : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.Headers["Authorization"] != null && httpContext.Request.Headers["Authorization"].Split(' ').Length ==2)
            {
                var jwtToken = new JwtSecurityToken(httpContext.Request.Headers["Authorization"].Split(' ')[1]);
                Claim[] claims = new Claim[5];
                int i = 0;
                foreach (Claim claim in jwtToken.Claims)
                {
                    switch (claim.Type)
                    {
                        case ClaimTypes.Sid:
                        case ClaimTypes.Name:
                        case ClaimTypes.Surname:
                        case ClaimTypes.Email:
                        case ClaimTypes.Role:
                            claims[i++] = claim;
                            break;
                    }
                }
                Thread.CurrentPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
                return true;
            }
            return false;
        }
    }
}