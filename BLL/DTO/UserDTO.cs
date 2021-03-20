using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get;set;}

        public UserDto()
        {
            Role = UserRoles.Guest;
        }
        public UserDto(int id, string name, string password, int role)
        {
            Id = id;
            Name = name;
            Password = password;
            Role = (UserRoles)role;
        }
    }
}
