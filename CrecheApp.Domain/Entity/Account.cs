using CrecheApp.Domain.Interface.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Entity
{
    public class Account : ISignature
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public string Name { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastChangeUser { get; set; }
        public DateTime LastChangeDate { get; set; }
        public string DeviceId { get; set; }
        public string IPAddress { get; set; }
        public string Location { get; set; }
    }
}
