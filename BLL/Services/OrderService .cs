
using BLL.DTO;
using BLL.Mappers;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository _repository)
        {
            orderRepository = _repository;
        }
        public void Add(OrderDto order)
        {
            order.Status = Enums.OrderStatus.New;
            order.Id = orderRepository.Count();
            orderRepository.Add(OrderMapper.ToEntity(order));
        }

        public void ChangeStatus(int order_id, int status)
        {
            orderRepository.ChangeStatus(order_id, status);
        }

        public int Count()
        {
            return orderRepository.Count();
        }

        public void Delete(int order_id)
        {
            orderRepository.Delete(order_id);
        }

        public OrderDto GetOrderById(int order_id)
        {
            return OrderMapper.ToDto(orderRepository.GetOrderById(order_id)); 
        }

        public List<OrderDto> GetOrderByUserId(int user_id)
        {
            List<OrderDto> list = (from o in orderRepository.GetOrderByUserId(user_id)
                                   select OrderMapper.ToDto(o)).ToList();
            return list;
        }

        public List<OrderDto> GetOrders()
        {
            List<OrderDto> list = (from o in orderRepository.GetOrders()
                                   select OrderMapper.ToDto(o)).ToList();
            return list;
        }
        public bool IsUserOrder(int user_id, int product_id)
        {
            return orderRepository.GetOrderByUserId(user_id).Find(x=>x.ProductsId.Contains(product_id)) != null;
        }
    }
}
