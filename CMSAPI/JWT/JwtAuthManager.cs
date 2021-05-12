using CMSAPI.JWT.Interfaces;
using CMSAPI.JWT.Models;
using CMSAPI.Models.Config;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Utility;

namespace CMSAPI.JWT
{
    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly JwtTokenConfig jwtTokenConfig;
        private readonly byte[] secret;

        public JwtAuthManager(JwtTokenConfig pJwtTokenConfig)
        {
            jwtTokenConfig = pJwtTokenConfig;
            secret = Encoding.UTF8.GetBytes(jwtTokenConfig.Secret);
        }


        public JwtAuthResult GenerateTokens(string account, Claim[] claims, DateTime now)
        {
            var shouldAddAudienceClaim = !string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
            var jwtToken = new JwtSecurityToken(
                jwtTokenConfig.Issuer,
                shouldAddAudienceClaim ? jwtTokenConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(jwtTokenConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refreshToken = new UserToken
            {
                Account = account,
                TokenString = RandomMethod.GenerateRandomString(32),
                ExpireAt = now.AddMinutes(jwtTokenConfig.RefreshTokenExpiration)
            };


            return new JwtAuthResult
            {
                AccessToken = accessToken,
                UserToken = refreshToken
            };

        }

        /// <summary>
        /// 因為 JWT 的逾時是綁在 Token 裡的，所以要延長只能更新 Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="accessToken"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public JwtAuthResult Refresh(string accessToken, DateTime now)
        {
            var (principal, jwtToken) = DecodeJwtToken(accessToken);

            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                throw new SecurityTokenExpiredException("Invalid token");
            }

            var account = principal.Identity.Name;

            return GenerateTokens(account, principal.Claims.ToArray(), now);

        }

        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
        {
            if(string.IsNullOrWhiteSpace(token))
            {
                throw new SecurityTokenException("Invalid token");
            }

            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateAudience = !string.IsNullOrWhiteSpace(jwtTokenConfig.Audience),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                }, out var validatedToken);

            return (principal, validatedToken as JwtSecurityToken);
        }

    }
}
