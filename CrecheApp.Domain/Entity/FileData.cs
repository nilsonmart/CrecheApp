using CrecheApp.Domain.Enum;
using System;

namespace CrecheApp.Domain.Entity
{
    public class FileData
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public byte[] Content { get; set; }
        public FileTypeEnum FileType { get; set; }


    }
}
