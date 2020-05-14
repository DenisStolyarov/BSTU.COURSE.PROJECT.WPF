namespace BSTU.FileCabinet.Domain.Models
{
    using System.Collections.Generic;
    
    public partial class Specialty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialty()
        {
            this.Groups = new HashSet<Group>();
        }
    
        public string SpecialtyCode { get; set; }
        public string SpecialtyName { get; set; }
        public string PulpitCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Groups { get; set; }
        public virtual Pulpit Pulpit { get; set; }
    }
}
