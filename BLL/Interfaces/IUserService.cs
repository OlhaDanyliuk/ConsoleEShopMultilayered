using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserService
    {
      
        void Add(UserDto user); 

        void Delete(int user_id);

        UserDto GetUserById(int user_id);

        void Update(UserDto newUser);
        bool Login(UserDto user);
        bool Signup(UserDto user);
        List<UserDto> GetUsers();
    }
}
