using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Movvi.DLL.DTO.Output
{
    public class AuthOut
    {
        [JsonPropertyName("userid")]
        public int UserId { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
