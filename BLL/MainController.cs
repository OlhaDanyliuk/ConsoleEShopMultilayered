using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MainController
    {
        private readonly dbContext db=new dbContext();

        private readonly UserService userService;
        private readonly ProductService productService;
        private readonly OrderService orderService;

        private UserDto sessionUser;
       
        public MainController(UserDto currentUser)
        {
            sessionUser = currentUser;
            userService = new UserService(db.usersRepository);
            productService = new ProductService(db.productRepository);
            orderService = new OrderService(db.orderRepository);
        }

        public List<ProductDto> GetProducts()
        {
            return productService.GetProducts();
        }
        public List<ProductDto> GetProductByName(string name)
        {
            return productService.GetProductByName(name);
        }
        public ProductDto GetProductById(int id)
        {
            return productService.GetProductById(id);
        }

        public UserDto Signup(string name, string password)
        {
            UserDto user = new UserDto
            {
                Id = userService.Count(),
                Name = name,
                Password = password,
                Role = Enums.UserRoles.RegisteredUser
            };
            userService.Add(user);
            return user;
        }
        public UserDto Login(string name, string password)
        {
            UserDto currentUser=userService.GetUsers().Find(x => x.Name == name && x.Password == password);
            return currentUser;

        }

        public void ChangeStatus(int user_id, int order_id, int status)
        {
            if(GetUserOrders(user_id).FindAll(x=>x.Id==order_id)!=null)
                orderService.ChangeStatus(order_id, status);
        }
        public void ChangeStatus(int order_id, int status)
        {
            orderService.ChangeStatus(order_id, status);
        }
        public UserDto GetUser(int id)
        {
            return userService.GetUserById(id);
        }
        public List<OrderDto> GetUserOrders(int user_id)
        {
            return orderService.GetOrderByUserId(user_id);
        }

        public void CreateOrder(int user_id, int product_id)
        {
            if (productService.GetProductById(product_id) == null) throw new ArgumentNullException("Product not found");
            orderService.Add(new OrderDto
            {
                Id = orderService.Count(),
                UserId = user_id,
                ProductsId = new List<int>() { product_id },
                Status = Enums.OrderStatus.New
            });
        }
        public void EditUserInfo(int user_id, int fiels, string new_value)
        {
            if (userService.GetUserById(user_id) == null) throw new ArgumentNullException("User not found");
            UserDto new_user = userService.GetUserById(user_id);
            if(fiels==1)
                new_user.Name = new_value;
            if (fiels == 2)
                new_user.Password = new_value;
            userService.Update(new_user);
        }
        public List<UserDto> GetUsers()
        {
            return userService.GetUsers();
        }
        public void Logout()
        {
            db.SaveChanges();
        }
        public void AddProduct(ProductDto product)
        {
            productService.Add(product);

        }
        public void EditProduct(int product_id, string field, string new_value)
        {
            productService.EditProduct(product_id, field, new_value);
        }
    }
}
