using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Movvi.DLL.DTO
{
    public class ParameterDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("parameter")]
        public string Parameter { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
