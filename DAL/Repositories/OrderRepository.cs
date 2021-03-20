using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OrderRepository : IOrderRepository
    {
        private List<OrderEntity> orders = new List<OrderEntity>();
        public void Add(OrderEntity order)
        {
            order.Id = orders.Count;
            orders.Add(order);
        }
        public void Delete(int order_id)
        {
            orders.RemoveAll(x => x.Id == order_id);
        }

        public OrderEntity GetOrderById(int order_id)
        {
            OrderEntity item = (from p in orders
                                where p.Id ==order_id
                               select p).First();
            return item;
        }
        public List<OrderEntity> GetOrderByUserId(int user_id)
        {
            List<OrderEntity> item = (from p in orders
                                where p.UserId == user_id
                                select p).ToList();
            return item;
        }

        public void ChangeStatus(int order_id, int status)
        {
            orders.FirstOrDefault(x => x.Id == order_id).Status = (OrderStatus)status;
        }


        public List<OrderEntity> GetOrders()
        {
            return orders;
        }

        public int Count()
        {
            return orders.Count();
        }
    }
}
