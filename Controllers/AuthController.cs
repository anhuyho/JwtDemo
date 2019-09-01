using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Security.Claims;

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public ActionResult GetTokens()
        {
            var securityKey = "hang_nam_cu_vao_cuoi_thu";
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));


            var token = new JwtSecurityToken(
                issuer: "huyho",
                audience: "meditator",
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(15),
                signingCredentials: signingCredentials,
                claims: claims
            );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}