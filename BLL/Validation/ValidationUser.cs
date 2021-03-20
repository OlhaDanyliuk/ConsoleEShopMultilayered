using BLL.DTO;
using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ValidationUser 
    {
        public static UserDto Add(string userData)
        {
            UserDto new_user;
            try
            {
                string[] items = userData.Split(' ');
                new_user = new UserDto
                {
                    Id = int.Parse(items[0]),
                    Name = items[1],
                    Password = items[2],
                    Role = (UserRoles)int.Parse(items[3])
                };
            }
            catch
            {
                throw new ArgumentException("Not valid user data");
            }
            return new_user; 
        }
        
    }
}
