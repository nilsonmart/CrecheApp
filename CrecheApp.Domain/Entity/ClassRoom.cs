using System;
using System.Collections.Generic;

namespace CrecheApp.Domain.Entity
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string ClassRoomName { get; set; }
        public string ClassRoomCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartSummerVacation { get; set; }
        public DateTime? EndSummerVacation { get; set; }
        public DateTime? StartWinterVacation { get; set; }
        public DateTime? EndWinterVacation { get; set; }
        public string ClassEvaluation { get; set; }
        public string ClassAverageEvaluation { get; set; }
        public virtual IList<Pupil> Pupils { get; set; }
        public virtual IList<Staff> Staffs { get; set; }
        public virtual IList<FileData> Files { get; set; }
    }
}
