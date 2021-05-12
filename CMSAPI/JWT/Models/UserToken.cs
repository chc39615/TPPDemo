using System;
using System.Text.Json.Serialization;

namespace CMSAPI.JWT.Models
{
    // TODO: 將 UserToken 存到 redis 中
    /// <summary>
    /// 可以依照 tokenString 將使用者的資料存在 redis 中
    /// </summary>
    public class UserToken
    {
        /// <summary>
        /// Account_Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("account")]
        public string Account { get; set; } // can be used for usage tracking
        // can optionally include other metadata, such as user agent, ip address, device name...

        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }

}
