using BLL.DTO;
using BLL.Enums;
using DAL.Entities;
using System;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(UserDto user)
        {
            return new UserEntity
            {
                Id=user.Id,
                Name= user.Name,
                Password=user.Password,
                Role=(UserRole)user.Role
            };
        }
        public static UserDto ToDto(UserEntity user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Role = (UserRoles)user.Role
            };
        }



    }
}
