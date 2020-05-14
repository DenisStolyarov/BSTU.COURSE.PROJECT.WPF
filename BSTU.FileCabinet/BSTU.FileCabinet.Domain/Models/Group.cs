namespace BSTU.FileCabinet.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
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
    
        public virtual Faculty Faculty { get; set; }
        public virtual Specialty Specialty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
