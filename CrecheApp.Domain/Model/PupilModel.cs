using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Model
{
    public class PupilModel
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
        public virtual IList<ParentModel> Parents { get; set; }
        public ClassRoomModel ClassRoom { get; set; }
        public virtual IList<IFormFile> Files { get; set; }
    }
}
