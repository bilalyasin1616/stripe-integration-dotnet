using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Domain.Extensions
{
    public static class ClaimsParser
    {
        public static T ParseClaim<T>(this List<Claim> claims, string type)
        {
            var claim = claims.Find(c => c.Type == type);
            if (claim == null)
                return default;
            else
                return (T)Convert.ChangeType(claim.Value, typeof(T));
        }
    }
}
