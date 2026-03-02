using System;
using System.Collections.Generic;
using System.Text;

namespace Kaptu.DLL.Models
{
    public class Plans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string StripePriceId { get; set; }
        public List<User> User{ get; set; }
        public List<PremiumUsers> PremiumUsers { get; set; }
    }
}
