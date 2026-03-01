using System;
using System.Collections.Generic;
using System.Text;

namespace Kaptu.DLL.Models
{
    public class PremiumUsers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Plan { get; set; }
        public User User { get; set; }
        public DateTime NextPayment { get; set; }
        public DateTime LastPayment { get; set;  }
        public bool IsActive { get; set; }
    }
}
