using System;
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
        public ICollection<Product> Products { get; set; } // One-to-many relationship with Product class

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
