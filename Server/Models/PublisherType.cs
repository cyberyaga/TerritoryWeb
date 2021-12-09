namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PublisherType
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
    
        //public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
