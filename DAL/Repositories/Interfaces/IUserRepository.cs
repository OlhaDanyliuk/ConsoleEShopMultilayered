using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserRepository
    {
        void Add(UserEntity user);
        void Update(UserEntity newUser);
        void Delete(int user_id);
        UserEntity GetUserById(int user_id);
        int Count();
        List<UserEntity> GetUsers();

    }
}
