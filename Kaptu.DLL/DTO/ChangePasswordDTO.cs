using System;
using System.Collections.Generic;
using System.Text;

namespace Kaptu.DLL.DTO
{
    public class ChangePasswordDTO
    {
        public string? Email { get; set; }
        public string? NewPassword { get; set; }
        public long? Code{ get; set; }
    }
}
