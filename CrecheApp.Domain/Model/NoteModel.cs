using CrecheApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Model
{
    public class NoteModel
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
