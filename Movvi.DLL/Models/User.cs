using Movvi.DLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Movvi.DLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int PlanId { get; set; } 
        public string EnterpriseName { get; set; }
        public Tenant Tenant { get; set; }
        public PremiumUsers PremiumUsers { get; set; }
        public Plans Plans { get; set; }
        public List<PurchaseHistory> PurchaseHistory { get; set; }

        public static implicit operator User(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Password = userDTO.Password,
                Email = userDTO.Email,
            };
        }
    }
}
