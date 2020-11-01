using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Model
{
    public class AuthenticateResponseModel
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastChangeUser { get; set; }
        public DateTime? LastChangeDate { get; set; }

        public AuthenticateResponseModel(User user, string token)
        {
            Id = user.Id;
            GlobalId = user.GlobalId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;           
            Token = token;
            IsActive = user.IsActive;
            CreationDate = user.CreationDate;
            CreationUser = user.CreationUser;
            LastChangeDate = user.LastChangeDate;
            LastChangeUser = user.LastChangeUser;           
        }
    }
}
