
using BLL;
using System;
using UIL;
using UIL.Model;

namespace ShopMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UserModel currentUser = new UserModel();
            Menu menu = new Menu(currentUser);
            int item=menu.ShowMenu(currentUser); 
            while (true)
            {
                switch (item)
                {
                    case 0:
                        currentUser = new UserModel();
                        menu.Logout();
                        break;
                    case 1:
                        menu.ShowProducts();
                        break;
                    case 2:
                        menu.SearchProductByName();
                        break;
                    case 3:
                        switch (currentUser.Role)
                        {
                            case BLL.Enums.UserRoles.Guest:
                                currentUser = menu.Login();
                                break;
                            case BLL.Enums.UserRoles.RegisteredUser:
                                menu.CreateOrder_RegUser(currentUser.Id);
                                break;
                            case BLL.Enums.UserRoles.Admin:
                                menu.CreateOrder();
                                break;

                        }
                        break;
                    case 4:
                        switch (currentUser.Role)
                        {
                            case BLL.Enums.UserRoles.Guest:
                                currentUser = menu.Signup();
                                break;
                            case BLL.Enums.UserRoles.RegisteredUser:
                                menu.ShowOrders(currentUser.Id);
                                break;
                            case BLL.Enums.UserRoles.Admin:
                                menu.ShowOrders();
                                break;

                        }
                        break;
                    case 5:
                        switch (currentUser.Role)
                        {
                            case BLL.Enums.UserRoles.RegisteredUser:
                                menu.ChangeStatus(currentUser.Id, 5);
                                break;
                            case BLL.Enums.UserRoles.Admin:
                                menu.ChangeStatus_Admin();
                                break;

                        }
                        break;
                    case 6:
                        switch (currentUser.Role)
                        {
                            case BLL.Enums.UserRoles.RegisteredUser:
                                menu.ChangeStatus(currentUser.Id, 6);
                                break;
                            case BLL.Enums.UserRoles.Admin:
                                menu.EditPersonalInsormation(currentUser.Id);
                                break;

                        }
                        break;
                    case 7:
                        switch (currentUser.Role)
                        {
                            case BLL.Enums.UserRoles.RegisteredUser:
                                menu.EditPersonalInsormation(currentUser.Id);
                                break;
                            case BLL.Enums.UserRoles.Admin:
                                menu.ShowUsers();
                                break;

                        }
                        break;
                    case 8:
                        menu.AddProduct();
                        break;
                    case 9:
                        menu.EditProduct();
                        break;

                }
                item = menu.ShowMenu(currentUser);
            }
        }
    }
}
