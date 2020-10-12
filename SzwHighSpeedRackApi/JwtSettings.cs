namespace SzwHighSpeedRackApi
{
    public class JwtSettings
    {
        /// <summary>
        /// 密钥（字符串长度大于16）
        /// </summary>
        public string SecurityKey { get; set; }

        /// <summary>
        /// 颁发者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 接收者
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 过期时间（s）
        /// </summary>
        public int ExpireSeconds { get; set; }
    }
}