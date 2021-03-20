using BLL;
using BLL.DTO;
using DAL.Entities;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Mappers
{
    public static class OrderMapper
    {
        public static OrderEntity ToEntity(OrderDto order)
        {
            return new OrderEntity
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductsId = order.ProductsId,
                Status = (DAL.Entities.OrderStatus)order.Status
            };
        }
        public static OrderDto ToDto(OrderEntity order)
        {
            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                ProductsId = order.ProductsId,
                Status = (BLL.Enums.OrderStatus)order.Status
            };
        }
    }
}
