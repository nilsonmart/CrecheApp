using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Entity
{
    public class Pupil
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool HasDesabilities { get; set; }
        public string Desabilities { get; set; }
        public bool NeedMedicalTreatments { get; set; }
        public string MedicalsTreatments { get; set; }
        public virtual IList<Parent> Parents { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public virtual IList<FileData> Files { get; set; }
    }
}
