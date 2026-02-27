using Kaptu.DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Kaptu.DLL.DTO
{
    public class UserDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("tenantname")]
        public string TenantName { get; set; }
        [JsonPropertyName("tenantid")]
        public int TenantId { get; set; }

        public static implicit operator UserDTO(Models.User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Email = user.Email,
                TenantName = user.Tenant.Name,
                TenantId = user.TenantId,
            };
        }
    }
}
