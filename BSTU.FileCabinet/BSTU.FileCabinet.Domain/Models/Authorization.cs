//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BSTU.FileCabinet.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Authorization
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
