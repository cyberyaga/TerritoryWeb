namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PublisherType
    {
        public PublisherType()
        {
            //this.AspNetUsers = new HashSet<AspNetUser>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
    
        //public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
