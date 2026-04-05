using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Movvi.DLL.Models
{
    public class TenantDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("trialsend")]
        public DateTime? TrialsEnd { get; set; }
        [JsonPropertyName("isactive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("userid")]
        public bool UserId { get; set; }

        public static implicit operator TenantDTO(Tenant tenant)
        {
            return new TenantDTO
            {
                Id = tenant.Id,
                Name = tenant.Name,
                TrialsEnd = tenant.TrialsEnd,
                IsActive = tenant.IsActive,
            };
        }
    }
}
