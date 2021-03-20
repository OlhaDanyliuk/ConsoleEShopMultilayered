using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.Mappers;
using System.Linq;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository user)
        {
            userRepository = user;
        }
        public void Add(UserDto user)
        {
            userRepository.Add(UserMapper.ToEntity(user));
        }

        public void Delete(int user_id)
        {
            userRepository.Delete(user_id);
        }

        public UserDto GetUserById(int user_id)
        {
            return UserMapper.ToDto(userRepository.GetUserById(user_id));
        }

        public void Update(UserDto newUser)
        {
            userRepository.Update(UserMapper.ToEntity(newUser));
        }

        public List<UserDto> GetUsers()
        {
            List<UserDto> new_list = (from u in userRepository.GetUsers()
                                      select UserMapper.ToDto(u)).ToList();
            return new_list;
        }

        public bool Login(UserDto user)
        {
            return userRepository.GetUsers().Find(x => x.Name == user.Name && x.Password == user.Password) != null;
        }
        public bool Signup(UserDto user)
        {
            if(userRepository.GetUsers().Find(x => x.Name == user.Name && x.Password == user.Password) != null)
            {
                return false;
            }
            else
            {
                userRepository.Add(UserMapper.ToEntity(user));
                return true;
            }
        }

        public int Count()
        {
            return userRepository.Count();
        }
    }
}
