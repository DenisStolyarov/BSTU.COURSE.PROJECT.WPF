namespace BSTU.FileCabinet.Domain.Models
{
    using System.Collections.Generic;
    
    public partial class Pulpit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pulpit()
        {
            this.Specialties = new HashSet<Specialty>();
            this.Subjects = new HashSet<Subject>();
            this.Teachers = new HashSet<Teacher>();
        }
    
        public string PulpitCode { get; set; }
        public string PulpitName { get; set; }
        public string FacultyCode { get; set; }
    
        public virtual Faculty Faculty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specialty> Specialties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject> Subjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
