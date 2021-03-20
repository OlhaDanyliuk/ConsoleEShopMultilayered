using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public List<int> ProductsId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
