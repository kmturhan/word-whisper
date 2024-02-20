using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WordWhisper.Web.Models;

namespace WordWhisper.Web.Controllers
{
    
    public class AuthController : Controller
    {
        private readonly string signinKey = "SignInKeytesttestsetsetset";
        public AuthController()
        {

        }
        public string Get(string username, string password)
        {
            username = "test";
            password = "test2";
            
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Email, username),
                new Claim(ClaimTypes.Role, "admin")
            };

            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSetting.JwtSigninKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: AppSetting.JwtIssuer,
                audience: AppSetting.JwtAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                notBefore: DateTime.Now,
                signingCredentials: credentials

                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }

        public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims = jwtToken.Claims.ToList();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
        [Authorize(Roles = "Admin")]
        public string GetAuth()
        {
            return "OK!";
        }
        [Authorize(Roles = "User")]
        public string Register()
        {
            return "OK!!!!!!!!!!!!!!!!";
        }
    }
}
