using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers
{
    public static class OrderMapper
    {
        public static OrderEntity ToEnity(OrderDto order)
        {
            return new OrderEntity
            {
                Id = order.Id,
                Product = ProductMapper.ToEnity(order.Product),
                Status = (Entities.OrderStatus)order.Status
            };
        }
        public static OrderDto ToDto(OrderEntity order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Product = ProductMapper.ToDto(order.Product),
                Status = (BLL.OrderStatus)order.Status
            };
        }
    }
}
