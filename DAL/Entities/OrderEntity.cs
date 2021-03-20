using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class OrderEntity:BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public List<int> ProductsId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
