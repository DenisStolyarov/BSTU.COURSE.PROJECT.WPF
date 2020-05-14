namespace BSTU.FileCabinet.Domain.Models
{
    public partial class TeacherSubject
    {
        public string TeacherCode { get; set; }
        public string SubjectCode { get; set; }
        public int Course { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
