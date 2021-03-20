using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrderRepository
    {
        void Add(OrderEntity order);
        int Count();
        void ChangeStatus(int order_id, int status);
        List<OrderEntity> GetOrderByUserId(int user_id);
        List<OrderEntity> GetOrders();
        void Delete(int order_id);
        OrderEntity GetOrderById(int order_id);
    }
}
