using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using SzwHighSpeedRack;
using SzwHighSpeedRack.Repository;

namespace SzwHighSpeedRackApi.Controllers
{
    public class LoginController : RackBaseApiController
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IPdProductRepository _pdProductRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        ///
        /// </summary>
        /// <param name="jwtSettingsAccesser"></param>
        /// <param name="pdProductRepository"></param>
        /// <param name="httpContextAccessor"></param>
        public LoginController(IOptions<JwtSettings> jwtSettingsAccesser, IPdProductRepository pdProductRepository, IHttpContextAccessor httpContextAccessor)
        {
            _jwtSettings = jwtSettingsAccesser.Value;
            _pdProductRepository = pdProductRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取Token令牌
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetToken")]
        [AllowAnonymous]
        public object Token()
        {
            var now = DateTime.Now;
            var authTime = DateTime.UtcNow;//授权时间
            var expiresAt = authTime.AddHours(_jwtSettings.ExpireSeconds);//过期时间
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);
            SigningCredentials sign = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            // 实例化JwtSecurityToken
            var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "AdminName"),
                        new Claim(ClaimTypes.Role, "Admin"),
                        //new Claim(ClaimTypes.Role,"System")
                    };
            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: now,
                expires: expiresAt,
                signingCredentials: sign
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwt);
            var result = new
            {
                Authorization = tokenString,
                token_type = "Bearer"
            };
            this.HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(claims)));
            return result;
        }

        [HttpGet]
        public object Get([FromQuery] int[] ids)
        {
            return _pdProductRepository.FindList(w => ids.Contains(w.Id)).ToJson();
        }

        [HttpGet("TestPublish")]
        public object TestPublish()
        {
            Claim UserName = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Name);
            Claim role = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Role);
            return new
            {
                name = UserName.Value,
                role = role.Value,
                IsAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
            };
        }

        [HttpGet("Logout")]
        public void Logout()
        {
            this.HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
        }
    }
}