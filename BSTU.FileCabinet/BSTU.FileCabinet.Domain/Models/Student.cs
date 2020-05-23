namespace BSTU.FileCabinet.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Authorizations = new HashSet<Authorization>();
        }
    
        public int StudentId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Nullable<DateTime> Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Foto { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authorization> Authorizations { get; set; }
        [JsonIgnore]
        public virtual Group Group { get; set; }
    }
}
