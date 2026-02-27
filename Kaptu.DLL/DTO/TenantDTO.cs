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

        public static implicit operator TenantDTO(Tenant tenant)
        {
            return new TenantDTO
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Plan = tenant.Plan,
                TrialsEnd = tenant.TrialsEnd,
                IsActive = tenant.IsActive,
            };
        }
    }
}
