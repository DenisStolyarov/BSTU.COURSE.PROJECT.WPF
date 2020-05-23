using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace BSTU.FileCabinet.Domain.Models
{
    [Serializable]
    public partial class TeacherSubject
    {
        public string TeacherCode { get; set; }
        public string SubjectCode { get; set; }
        public int Course { get; set; }

        [JsonIgnore]
        public virtual Subject Subject { get; set; }
        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }
    }
}
