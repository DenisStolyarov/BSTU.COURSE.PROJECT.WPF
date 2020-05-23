namespace BSTU.FileCabinet.Domain.Models
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    [Serializable]
    public partial class Authorization
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Nullable<int> UserId { get; set; }
    
        [JsonIgnore]
        public virtual Student Student { get; set; }
    }
}
