namespace BSTU.FileCabinet.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int GroupId { get; set; }
        public string FacultyCode { get; set; }
        public string SpecialtyCode { get; set; }
        public Nullable<short> GroupNumber { get; set; }
        public Nullable<short> Course { get; set; }

        [JsonIgnore]
        public virtual Faculty Faculty { get; set; }
        [JsonIgnore]
        public virtual Specialty Specialty { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
