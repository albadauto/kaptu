using System;
using System.Collections.Generic;
using System.Text;

namespace Movvi.DLL.DTO.Output
{
    public class CreatePaymentOut
    {
        public string Url { get; set; } = string.Empty;
        public string CheckoutId { get; set; } = string.Empty;
    }
}
