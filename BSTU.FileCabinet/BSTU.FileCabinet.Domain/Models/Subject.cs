namespace BSTU.FileCabinet.Domain.Models
{
    using System.Collections.Generic;
    
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            this.TeacherSubjects = new HashSet<TeacherSubject>();
        }
    
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string PulpitCode { get; set; }
    
        public virtual Pulpit Pulpit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
