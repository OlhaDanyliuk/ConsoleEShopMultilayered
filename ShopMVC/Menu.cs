using BLL;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIL.Enums;
using UIL.Mapper;
using UIL.Model;
using UIL.Models;

namespace UIL
{
    public class Menu
    {
        private MainController mainController;

        public Menu(UserModel user)
        {
            mainController = new MainController(UserMapper.ToDto(user));
        }
        public int ShowMenu(UserModel user)
        {
            Console.WriteLine("\n\tMENU\n");
            int i = 0;
            string[] commands=new string[0];
            BLL.Enums.UserRoles role = user.Role;
            switch (role)
            {
                case BLL.Enums.UserRoles.Guest:
                    commands = Enum.GetNames(typeof(GuestCommand));
                    break;
                case BLL.Enums.UserRoles.RegisteredUser:
                    commands = Enum.GetNames(typeof(RegistredUserCommand));
                    break;
                case BLL.Enums.UserRoles.Admin:
                    commands = Enum.GetNames(typeof(AdminCommand));
                    break;
            }

            foreach (var item in commands)
            {
                Console.WriteLine($"{i}. {item}");
                i++;
            }
            int result = 0;
            int.TryParse(Console.ReadLine(), out result);
            return result;
        }
        public void PrintProducts(IEnumerable <ProductDto> product)
        {
            foreach( var item in product)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ShowProducts()
        {
            List<ProductDto> products = mainController.GetProducts();
            Console.WriteLine("\tPRODUCTS\n");
            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void SearchProductByName()
        {
            Console.WriteLine("\nSearch by name: ");
            string name = Console.ReadLine();
            PrintProducts(mainController.GetProductByName(name));
        }

        public UserModel Signup()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            UserModel user = UserMapper.ToModel(mainController.Signup(name, password));
            return user;

        }
        public UserModel Login()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            UserModel user=UserMapper.ToModel(mainController.Login(name, password));
            return user;

        }
        public string UserNameById(int id)
        {
            return mainController.GetUser(id).Name;
        }
        public void ShowOrders(int user_id)
        {
            List<OrderDto> orders= mainController.GetUserOrders(user_id);
            Console.WriteLine($"\t{UserNameById(user_id)}`s orders");
            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Id}");
                var products = (from id in item.ProductsId
                                               select mainController.GetProductById(id)).ToList();
                PrintProducts(products);
                Console.WriteLine($"{item.Status}");
            }
        }

        public void CreateOrder_RegUser(int user_id)
        {
            Console.WriteLine("\tEnter product number: ");
            ShowProducts();
            int item=0;
            while (item!=-1)
            {
                while(!int.TryParse(Console.ReadLine(), out item))
                {
                    Console.WriteLine("Enter valid product number: ");
                }
                try
                {
                    mainController.CreateOrder(user_id, item);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Enter -1 for exit: ");
            }
        }

        public void ChangeStatus(int user_id, int status)
        {
            Console.WriteLine("Enter order id: ");
            int item;
            bool valid = false;
            while (!int.TryParse(Console.ReadLine(), out item))
            {
                valid = int.TryParse(Console.ReadLine(), out item);
                Console.WriteLine("Enter valid order number: ");
            }
            try
            {
                mainController.ChangeStatus(user_id, item, status);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void EditPersonalInsormation(int user_id)
        {
            Console.Write("\n\tEDIT USER\nEnter field for edit:\n1.Name\n2.Password\n ");
            int item= 0; 
            bool valid = int.TryParse(Console.ReadLine(), out item); ;
            while (!valid && (item!=1 ||item !=2))
            {
                valid = int.TryParse(Console.ReadLine(), out item);
                Console.WriteLine("Enter valid order number: ");
            }
            try
            {
                if (item == 1) Console.WriteLine("New name: ");
                else if(item==2) Console.WriteLine("New password: ");
                string new_value = Console.ReadLine();
                mainController.EditUserInfo(user_id, item, new_value);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"{mainController.GetUser(user_id).Name},{mainController.GetUser(user_id).Password}");
        }
        public string RemoveUser()
        {
            Console.Write("\n\tREMOVE USER\nEnter user name for removing: ");
            return Console.ReadLine();
        }
        public string[] AddNewGoods()
        {
            Console.Write("\n\tNEW GOODS\n");
            string[] items = { "Name: ", "Category: ", "Description: ", "Price: " };
            string[] result = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(items[i]);
                result[i] = Console.ReadLine();
            }
            return result;
        }
        public void EditProduct()
        {
            try
            {
                Console.Write("\n\tEDIT PRODUCT\n Product_id: ");
                int product_id = int.Parse(Console.ReadLine());
                Console.Write(" Enter field (Name, Category, Description, Price): ");
                string field = Console.ReadLine();
                Console.Write("New value: ");
                string value = Console.ReadLine();
                mainController.EditProduct(product_id, field, value);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string RemoveGoods()
        {
            Console.Write("\n\tREMOVE GOODS\nEnter user name for removing: ");
            return Console.ReadLine();
        }

        public int ChangeStatus()
        {
            Console.WriteLine($"\nEnter status to change: \n1.CanceledByAdministrator\n2.PaymentReceived\n3.Sent\n4.Completed\n");
            int item =(int.Parse(Console.ReadLine()));
            return item;
        }

        public void ShowUsers()
        {
            foreach(var item in mainController.GetUsers())
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.Role}");
            }
        }
        public void ShowOrders()
        {
            foreach (var item in mainController.GetUsers())
            {
                ShowOrders(item.Id);
            }
        }
        public void CreateOrder()
        {
            Console.WriteLine("Enter user id");
            int user_id = int.Parse(Console.ReadLine());
            CreateOrder_RegUser(user_id);
        }
        public void ChangeStatus_Admin()
        {
            Console.WriteLine("Enter order id");
            int order_id = int.Parse(Console.ReadLine());
            Console.WriteLine("\tStatus:\n1.CanceledByAdministrator\n2PaymentReceived\n3.Sent\n4.Receive\n ");
            int i = int.Parse(Console.ReadLine());
            while(i<1 || i > 4)
            {
                Console.WriteLine("Please, enter valid status number: ");
                i = int.Parse(Console.ReadLine());
            }
            mainController.ChangeStatus(order_id, i);
        }
        public void Logout()
        {
            mainController.Logout();
        } 
        public void AddProduct()
        {
            Console.WriteLine("\tADD PRODUCT\nName: ");
            string name = Console.ReadLine();
            Console.WriteLine("Category: ");
            string category = Console.ReadLine();
            Console.WriteLine("Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Price: ");
            int price = int.Parse(Console.ReadLine());

            mainController.AddProduct(new ProductDto
            {
                Name = name,
                Category = category,
                Description = description,
                Price = price
            });
        }
    }
}

