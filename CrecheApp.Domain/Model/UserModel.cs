using CrecheApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CrecheApp.Domain.Dto
{
    public class UserModel
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsActive { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastChangeUser { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public DateTime? FirstAuthentication { get; set; }
        public DateTime? LastAuthentication { get; set; }
        public string LastAuthenticationIPAddress { get; set; }
    }
}
