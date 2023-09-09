﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationWithTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
