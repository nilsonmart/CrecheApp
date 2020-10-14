using CrecheApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Entity
{
    public class User 
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}
