namespace BSTU.FileCabinet.Domain.Models
{
    using System;
    
    public partial class Authorization
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
