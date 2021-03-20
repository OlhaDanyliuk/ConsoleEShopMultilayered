using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace DAL
{
    public class dbContext
    {
        public UserRepository usersRepository { get; }
        public ProductRepository productRepository { get; }
        public OrderRepository orderRepository { get; }

        private string users_file_path= @"D:\study\Epam\Projects\Task16_Shop_MultilayredArchitecture\ShopMVC\DAL\Users.txt";
        private string products_file_path= @"D:\study\Epam\Projects\Task16_Shop_MultilayredArchitecture\ShopMVC\DAL\Products.txt";
        private string orders_file_path=@"D:\study\Epam\Projects\Task16_Shop_MultilayredArchitecture\ShopMVC\DAL\Orders.txt";

        public dbContext()
        {
            usersRepository = new UserRepository();
            productRepository = new ProductRepository();
            orderRepository = new OrderRepository();
            UserFile(users_file_path);
            ProductFile(products_file_path);
            OrderFile(orders_file_path);
        }

        public void UserFile(string path)
        {
            string[] user_data = File.ReadAllLines(path);
            foreach (var line in user_data)
            {
                string[] items = line.Split(' ');
                UserEntity new_user = new UserEntity
                {
                    Id = int.Parse(items[0]),
                    Name = items[1],
                    Password = items[2],
                    Role = (UserRole)int.Parse(items[3])
                };
                usersRepository.Add(new_user);

            }
        }
        public void ProductFile(string path)
        {
            string[] products_data = File.ReadAllLines(path);
            foreach (var line in products_data)
            {
                string[] items = line.Split(',');
                ProductEntity new_product = new ProductEntity
                {
                    Id = int.Parse(items[0]),
                    Name = items[1],
                    Category = items[2],
                    Description=items[3],
                    Price = int.Parse(items[4])
                };
                productRepository.Add(new_product);

            }
        }
        public void OrderFile(string path)
        {
            string[] orders_data = File.ReadAllLines(path);
            foreach (var line in orders_data)
            {
                string[] items = line.Split(',');
                OrderEntity new_order = new OrderEntity
                {
                    Id = int.Parse(items[0]),
                    UserId  = int.Parse(items[1]),
                    ProductsId = (from i in items[2].Split(' ')
                                 select int.Parse(i)).ToList(),
                    Status =(OrderStatus)int.Parse(items[3])
                };
                orderRepository.Add(new_order);

            }
        }
        public void SaveChanges()
        {
            string[] users = new string[usersRepository.Count()];
            string[] products = new string[productRepository.Count()];
            string[] orders = new string[orderRepository.Count()];
            List<UserEntity> users_list = usersRepository.GetUsers();
            for (int i=0; i< users_list.Count; i++)
            {
                users[i] = $"{users_list[i].Id} {users_list[i].Name} {users_list[i].Password} {(int)users_list[i].Role}";
            }
            using (StreamWriter sw = new StreamWriter(users_file_path, false, System.Text.Encoding.Default))
            {
                foreach(var item in users)
                {
                    sw.WriteLine(item);
                }
            }

            List<ProductEntity> product_list = productRepository.GetProducts().ToList();

            for (int i = 0; i < product_list.Count; i++)
            {
                products[i] = $"{product_list[i].Id},{product_list[i].Name},{product_list[i].Category},{product_list[i].Description},{product_list[i].Price}";
            }
            using (StreamWriter sw = new StreamWriter(products_file_path, false, System.Text.Encoding.Default))
            {
                foreach (var item in products)
                {
                    sw.WriteLine(item);
                }
            }

            List<OrderEntity> order_list = orderRepository.GetOrders();

            for (int i = 0; i < order_list.Count; i++)
            {
                orders[i] = $"{order_list[i].Id},{order_list[i].UserId},";
                for(int j=0; j<order_list[i].ProductsId.Count; ++j)
                {
                    orders[i] += $"{order_list[i].ProductsId[j]} ";
                }
                orders[i] += $",{(int)order_list[i].Status}";
            }
            using (StreamWriter sw = new StreamWriter(orders_file_path, false, System.Text.Encoding.Default))
            {
                foreach (var item in orders)
                {
                    sw.WriteLine(item);
                }
            }

        }
    }
}
