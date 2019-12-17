namespace TerritoryWeb.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PublisherType
    {
        public PublisherType()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
