using System.Text.Json.Serialization;

namespace CMSAPI.JWT.Models
{
    public class JwtAuthResult
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("userToken")]
        public UserToken UserToken { get; set; }
    }
}
