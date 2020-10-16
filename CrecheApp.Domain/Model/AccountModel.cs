using System;

namespace CrecheApp.Domain.Dto
{
    public class AccountModel
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public string Name { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastChangeUser { get; set; }
        public DateTime? LastChangeDate { get; set; }
    }
}
