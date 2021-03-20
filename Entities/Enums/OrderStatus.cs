using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public enum OrderStatus
    {
        New,
        CanceledByAdministrator,
        PaymentReceived,
        Sent,
        Received,
        Completed,
        CanceledByUser
    }
}
