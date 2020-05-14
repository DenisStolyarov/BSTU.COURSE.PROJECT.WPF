namespace BSTU.FileCabinet.Domain.Models
{
    using System;
    
    public partial class StudentsOfGroup
    {
        public int StudentId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Nullable<DateTime> Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Foto { get; set; }
    }
}
