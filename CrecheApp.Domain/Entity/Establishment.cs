using CrecheApp.Domain.Interface.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Entity
{
    public class Establishment : ISignature
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PhoneBranchLine { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public IList<Staff> Staffs { get; set; }
        public IList<ClassRoom> ClassRooms { get; set; }
        public IList<Note> Notes { get; set; }
        public string CreationUser { get ; set ; }
        public DateTime CreationDate { get ; set ; }
        public string LastChangeUser { get ; set ; }
        public DateTime? LastChangeDate { get ; set ; }
    }
}
