using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIL.Models
{
    public class OrderModel
    {
        public string UserName { get; set; }
        public List<ProductModel> Products { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
