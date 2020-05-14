namespace BSTU.FileCabinet.Domain.Models
{
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            this.TeacherSubjects = new HashSet<TeacherSubject>();
        }
    
        public string TeacherCode { get; set; }
        public string TeacherName { get; set; }
        public string PulpitCode { get; set; }
        public byte[] Foto { get; set; }
    
        public virtual Pulpit Pulpit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
