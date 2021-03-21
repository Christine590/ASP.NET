using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WebLibrary.Helpers
{
    public partial class CommonHelper : ICommonHelper
    {
        #region 參數設定
        /// <summary>
        /// JWT 發行者
        /// </summary>
        private static readonly string issuer = ConfigHelper.AllConfig.JwtSettings.Issuer;
        /// <summary>
        /// JWT 受眾
        /// </summary>
        private static readonly string audience = ConfigHelper.AllConfig.JwtSettings.Audience;
        /// <summary>
        /// JWT 金鑰
        /// </summary>
        private static readonly string signKey = ConfigHelper.AllConfig.JwtSettings.SignKey;
        /// <summary>
        /// JWT 驗證參數
        /// </summary>
        private static readonly TokenValidationParameters validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,

            ValidateAudience = true,
            ValidAudience = audience,

            // 驗 SecurityKey，預設即為 true
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey)),
           
            // 驗 Token 有限期間，預設即為 true
            ValidateLifetime = true,

            // 驗證是否過期時，允許的時間偏移量
            ClockSkew = TimeSpan.Zero,
        };
        #endregion

        /// <summary>
        /// 產生 JSON Web Token
        /// </summary>
        /// <param name="data">欲植入Token 的資料內容</param>
        /// <param name="expireMinutes">Token逾時設定(預設30分鐘)</param>
        /// <returns></returns>
        public string GenerateToken(string data, int expireMinutes = 30) // 預設30分鐘逾時
        {
            try
            {
                // 建立 JWT TokenHandler
                var tokenHandler = new JwtSecurityTokenHandler();

                // 取得序列化的 JWT Token 字串
                var serializeToken = tokenHandler.WriteToken(tokenHandler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = issuer,
                    Audience = audience,

                    // 建立 JWT Token 中的聲明資訊 ( JWT Payload 的一部分 )
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, data), // Token 主體內容
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Token 的唯一識別碼
                    }),

                    // 設定 Token 逾時條件
                    Expires = DateTime.Now.AddMinutes(expireMinutes),

                    // 建立一組對稱式加密的金鑰，主要用於 JWT 簽章
                    // HmacSha256 有要求必須要大於 128 bits，所以 key 不能太短，至少要 16 字元以上
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey)), SecurityAlgorithms.HmacSha256Signature)
                }));

                return serializeToken;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 驗證 JSON Web Token
        /// </summary>
        /// <param name="token">欲驗證的Token</param>
        /// <returns></returns>
        public string ValidataToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return string.Empty;
            }

            try
            {
                // 若驗證成功會產生 ClaimsPrincipal
                ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out _);
                return principal.Claims.SingleOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
