namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TerritoryType
    {    
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    
        public virtual ICollection<Territory> Territories { get; set; } = new HashSet<Territory>();
    }
}
