using CMSAPI.JWT.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CMSAPI.JWT.Interfaces
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string account, Claim[] claims, DateTime now);
        JwtAuthResult Refresh(string accessToken, DateTime now);
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }
}
