using System.Text.Json.Serialization;

namespace CMSAPI.Models.Request
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
