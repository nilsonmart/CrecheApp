using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Model
{
    public class EstablishmentModel
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PhoneBranchLine { get; set; }
        public string Email { get; set; }
        public AddressModel Address { get; set; }
        public virtual IList<StaffModel> Staffs { get; set; }
        public IList<ClassRoomModel> ClassRooms { get; set; }
        public IList<NoteModel> Notes { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastChangeUser { get; set; }
        public DateTime? LastChangeDate { get; set; }
    }
}
