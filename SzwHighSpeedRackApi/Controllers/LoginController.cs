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
using SzwHighSpeedRack.Repository;
using SzwHighSpeedRack.Service;

namespace SzwHighSpeedRackApi.Controllers
{
    public class LoginController : RackBaseApiController
    {
        private JwtSettings _jwtSettings;
        private IPdProductRepository _pdProductRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jwtSettingsAccesser"></param>
        /// <param name="pdProductRepository"></param>
        public LoginController(IOptions<JwtSettings> jwtSettingsAccesser, IPdProductRepository pdProductRepository)
        {
            _jwtSettings = jwtSettingsAccesser.Value;
            _pdProductRepository = pdProductRepository;
        }


        /// <summary>
        /// 获取Token令牌
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetToken")]
        [AllowAnonymous]
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

        [HttpGet]
        [AllowAnonymous]
        public object Get()
        {
            return _pdProductRepository.FindSingle().ToJson();
        }

    }
}
