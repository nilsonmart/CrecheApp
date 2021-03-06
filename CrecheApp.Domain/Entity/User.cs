﻿using CrecheApp.Domain.Enum;
using CrecheApp.Domain.Interface.Model;
using System;

namespace CrecheApp.Domain.Entity
{
    public class User : ISignature
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
