namespace BSTU.FileCabinet.Domain.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
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

        [JsonIgnore]
        public virtual Pulpit Pulpit { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
