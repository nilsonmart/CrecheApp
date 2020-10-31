using CrecheApp.Domain.Enum;
using CrecheApp.Domain.Interface.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Entity
{
    public class Note : ISignature
    {
        public int Id { get; set; }
        public Guid GloblalId { get; set; }
        public int AccountId { get; set; }
        public string NoteName { get; set; }
        public NoteTypeEnum NoteType { get; set; }
        public string NoteValue { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastChangeUser { get; set; }
        public DateTime? LastChangeDate { get; set; }
    }
}
