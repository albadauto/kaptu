using System;
using System.Collections.Generic;
using System.Text;

namespace Kaptu.DLL.Models
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlanId { get; set; } 
        public User User { get; set; }
        public Plans Plan { get; set; }
        public int Status { get; set; }

    }
}
