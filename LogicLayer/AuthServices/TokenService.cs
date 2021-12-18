using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.AuthServices
{
    public class TokenService
    {
        private class AuthConfigModel
        {
            public string JwtKey { get; set; }
            public string JwtIssuer { get; set; }
            public int Timeout { get; set; }
        }

        private AuthConfigModel authConfig;
        public TokenService(int timeout)
        {
            authConfig = new AuthConfigModel { JwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"), JwtKey = Environment.GetEnvironmentVariable("JWT_KEY"), Timeout = timeout };
        }
        public TokenService()
        {
            authConfig = new AuthConfigModel { JwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"), JwtKey = Environment.GetEnvironmentVariable("JWT_KEY"), Timeout = 5 };
        }
        //GENERATE JSON WEB TOKEN WITH THE SPECIFIED CLAIMS
        public string GenerateJsonWebToken(IDictionary<string, string> myClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new Claim[myClaims.Count];
            int iterator = 0;
            //ADD ALL CLAIMS FROM DICTIONARY
            foreach (var kvp in myClaims)
            {
                claims[iterator] = new Claim(kvp.Key, kvp.Value);
                iterator++;
            }
            var token = new JwtSecurityToken(authConfig.JwtIssuer,
              authConfig.JwtIssuer,
              claims,
              //ADD TOKEN TIMEOUT
              expires: DateTime.Now.AddMinutes(authConfig.Timeout),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //VALIDATE JSON WEB TOKEN AND EXTRACT THE CLAIMS
        public IDictionary<string, string> ValidateToken(string jwtToken, List<string> keys)
        {
            SecurityToken validatedToken;
            IDictionary<string, string> myClaims = null;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = authConfig.JwtIssuer;
            validationParameters.ValidIssuer = authConfig.JwtIssuer;
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.JwtKey));
            try
            {
                myClaims = new Dictionary<string, string>();
                ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
                foreach (var k in keys)
                {
                    myClaims.Add(k, principal.FindFirst(k).Value);
                }
                return myClaims;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
