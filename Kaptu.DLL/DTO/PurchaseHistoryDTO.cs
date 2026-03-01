using Kaptu.DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Kaptu.DLL.DTO
{
    public class PurchaseHistoryDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userid")]
        public int UserId { get; set; }
        [JsonPropertyName("planid")]
        public int PlanId { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
