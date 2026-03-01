using System;
using System.Collections.Generic;
using System.Text;

namespace Kaptu.DLL.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? TrialsEnd { get; set; }
        public bool IsActive { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }

        public static implicit operator Tenant(TenantDTO tenantDTO)
        {
            return new Tenant
            {
                Id = tenantDTO.Id,
                Name = tenantDTO.Name,
                TrialsEnd = tenantDTO.TrialsEnd,
                IsActive = tenantDTO.IsActive,
            };
        }
    }
}
