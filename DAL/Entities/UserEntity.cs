
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserEntity:BaseEntity
    {
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
    }
}
