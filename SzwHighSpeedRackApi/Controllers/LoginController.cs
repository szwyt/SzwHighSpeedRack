using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SzwHighSpeedRack;
using SzwHighSpeedRack.Service;

namespace SzwHighSpeedRackApi.Controllers
{
    public class LoginController : RackBaseApiController
    {
        private JwtSettings _jwtSettings;
        private MngAdminService _mngAdminService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="jwtSettingsAccesser"></param>
        public LoginController(IOptions<JwtSettings> jwtSettingsAccesser, MngAdminService mngAdminService)
        {
            _jwtSettings = jwtSettingsAccesser.Value;
            _mngAdminService = mngAdminService;
        }

        [HttpPost("GetToken")]
        [AllowAnonymous]
        /// <summary>
        /// 获取Token令牌
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public object Token()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);
            var authTime = DateTime.UtcNow;//授权时间
            var expiresAt = authTime.AddHours(_jwtSettings.ExpireSeconds);//过期时间
            var tokenDescripor = new SecurityTokenDescriptor
            {
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Role, "Admin"),
                        //new Claim(ClaimTypes.Role,"System")
                    }),
                Expires = expiresAt,
                //对称秘钥SymmetricSecurityKey
                //签名证书(秘钥，加密算法)SecurityAlgorithms
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescripor);
            var tokenString = tokenHandler.WriteToken(token);
            var result = new
            {
                Authorization = tokenString,
                token_type = "Bearer"
            };
            return result;
        }


        /// <summary>
        /// 集成jwt验证及在Swagger中实现添加Token(需要验证)
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "SystemOrAdmin")]
        [HttpGet("Test1/{contentTitle}")]
        [AllowAnonymous]
        public string Test1(string contentTitle)
        {
            int a = 0;
            var test = 10 / a;
            return _mngAdminService.GetSiteCategoryInfo(f => f.ContentTitle == contentTitle).ToJson();
        }


    }
}
