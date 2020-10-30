using System.Collections.Generic;

namespace CrecheApp.Domain.Entity
{
    public class Parent
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public virtual IList<Pupil> Pupils { get; set; }
        public virtual IList<FileData> Files { get; set; }
    }
}
