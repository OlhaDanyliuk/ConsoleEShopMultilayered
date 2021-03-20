using BLL.DTO;
using BLL.Enums;
using Entities;
using System;

namespace Mapper
{
    public static class UserMapper
    {
        public static UserEntity ToEnity(UserDTO user)
        {
            return new UserEntity
            {
                Id=user.Id,
                Name= user.Name,
                Password=user.Password,
                Role=(UserRole)user.Role
            };
        }
        public static UserDTO ToDto(UserEntity user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = (UserRoles)user.Role
            };
        }
    }
}
