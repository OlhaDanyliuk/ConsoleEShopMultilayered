using BLL.DTO;
using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using UIL.Model;

namespace UIL
{
    public class UserMapper
    {
        public static UserDto ToDto(UserModel user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = (UserRoles)user.Role
            };
        }
        public static UserModel ToModel(UserDto user)
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = (UserRoles)user.Role
            };
        }
    }
}
