
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private List<UserEntity> users = new List<UserEntity>();
        public void Add(UserEntity user)
        {
            if (users.Find(x => x.Name == user.Name && x.Password == user.Password) == null)
            {
                user.Id = users.Count;
                users.Add(user);
            }
        }

        public void Delete(int user_id)
        {
            try
            {
                users.RemoveAll(x => x.Id == user_id);
            }
            catch
            {
                throw new ArgumentNullException("user_id");
            }
        }

        public UserEntity GetUserById(int user_id)
        {
            UserEntity item;
            try
            {
                item = (from u in users
                        where u.Id == user_id
                        select u).First();
            }
            catch
            {
                throw new ArgumentNullException("user_id");
            }
            return item;
        }

        public void Update(UserEntity user)
        {
            try
            {
                var edited = users.FirstOrDefault(x => x.Id == user.Id);
                edited.Name = user.Name;
                edited.Password = user.Password;
            }
            catch
            {
                throw new ArgumentNullException("user.Id");
            }
            
        }

        public List<UserEntity> GetUsers()
        {
            return users;
        }

        public int Count()
        {
            return users.Count;
        }
    }
}
