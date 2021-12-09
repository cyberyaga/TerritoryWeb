namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TerritoryType
    {
        public TerritoryType()
        {
            this.Territories = new HashSet<Territory>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
