using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Kaptu.DLL.Models
{
    public class TenantDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("plan")]
        public string Plan { get; set; }
        [JsonPropertyName("trialsend")]
        public DateTime? TrialsEnd { get; set; }
        [JsonPropertyName("isactive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
