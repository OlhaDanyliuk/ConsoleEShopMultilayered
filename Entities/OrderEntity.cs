using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class OrderEntity:BaseEntity
    {
        public ProductEntity Product { get; set; }
        public OrderStatus Status { get; set; }
    }
}
