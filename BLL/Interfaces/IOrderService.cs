using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IOrderService
    {
        void Add(OrderDto order);
        void ChangeStatus(int order_id, int status);
        bool IsUserOrder(int user_id, int product_id);
        List<OrderDto> GetOrderByUserId(int user_id);
        List<OrderDto> GetOrders();
        void Delete(int order_id);
        OrderDto GetOrderById(int order_id);
        int Count();
    }

}
