using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Interface.Model
{
    public interface ISignature
    {
        string CreationUser { get; set; }
        DateTime CreationDate { get; set; }
        string LastChangeUser { get; set; }
        DateTime LastChangeDate { get; set; }
        string DeviceId { get; set; }
        string IPAddress { get; set; }
        string Location { get; set; }
    }
}
