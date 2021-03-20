﻿using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace UIL.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }

        public UserModel()
        {
            Role = UserRoles.Guest;
        }
    }
}
