using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private IConfiguration configuration;

        public TokenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet]
        public IActionResult GenerateToken(string username, string password)
        {
            // if (username != "admin")
            //     return Unauthorized();


            var authClaims = new List<Claim>(){
                new Claim(ClaimTypes.Role, username)
            };

            var token = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("JwtOptions:Issuer"),
                audience: configuration.GetValue<string>("JwtOptions:Audience"),
                expires: DateTime.UtcNow.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtOptions:SecureKey"))), SecurityAlgorithms.HmacSha256Signature)
                );
            
            return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiresIn = 5
            });
        }
    }
}