using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Enums
{
    public enum OrderStatus
    {
        New,
        CanceledByAdministrator,
        PaymentReceived,
        Sent,
        Received,
        Confirm,
        CanceledByUser
    }
}
