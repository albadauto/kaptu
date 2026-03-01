using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Kaptu.DLL.DTO
{
    public class LoginDTO
    {
        [JsonPropertyName("userid")]
        public int? UserId { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("token")]
        public string? Token { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
