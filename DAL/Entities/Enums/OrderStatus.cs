using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public enum OrderStatus
    {
        New,
        CanceledByAdministrator,
        PaymentReceived,
        Sent,
        Received,
        Comfirm,
        CanceledByUser
    }
}
