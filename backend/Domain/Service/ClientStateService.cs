using Domain.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Domain.Service
{
    public class ClientStateService : IClientStateService
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public ClientStateService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null || httpContextAccessor.HttpContext == null)
                throw new ArgumentNullException("Http context could not be null");
            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = httpContextAccessor.HttpContext.User.Claims.ToList();
                UserId = claims.ParseClaim<int>("UserId");
                UserName = claims.ParseClaim<string>("UserName");
            }
            else
                UserName = "Annonymous";
        }

        public ClientStateService() { }
    }
}
