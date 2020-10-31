using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Entity
{
    public class Parent
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string IDNumber { get; set; }
        public string FiscalNumber { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public virtual IList<Pupil> Pupils { get; set; }
        public virtual IList<Note> Notes { get; set; }
    }
}
