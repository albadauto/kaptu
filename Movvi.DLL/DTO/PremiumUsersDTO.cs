using Movvi.DLL.Enums;
using Movvi.DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Movvi.DLL.DTO
{
    public class PremiumUsersDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userid")]
        public int UserId { get; set; }
        [JsonPropertyName("plan")]
        public int Plan { get; set; }
        [JsonPropertyName("nextpayment")]
        public DateTime NextPayment { get; set; }
        [JsonPropertyName("lastpayment")]
        public DateTime LastPayment { get; set; }
        [JsonPropertyName("isactive")]
        public bool IsActive { get; set; }
    }
}
