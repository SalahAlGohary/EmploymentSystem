using EmploymentSystem.Application.DTOs.Common;
using System.Text.Json.Serialization;

namespace EmploymentSystem.Application.DTOs.IdentityDTOs
{
    public class LoginResponseDto : ResponseDto
    {
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

    }
}
