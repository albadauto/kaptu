using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kaptu.DLL.Enums
{
    public enum Plan
    {
        [Description("price_1T6BcAC6gzfmqJLeGHAU3BXp")]
        Starter = 0,
        [Description("price_1T6BcoC6gzfmqJLe2zXvEtiS")]
        Pro = 1,
        [Description("price_1T6BefC6gzfmqJLeLrmK8cTM")]
        Imobiliaria= 2
    }

    public enum PurchaseStatus
    {
        [Description("pending")]
        Pending = 0,
        [Description("completed")]
        Completed = 1,
        [Description("failed")]
        Failed = 2

    }
}
