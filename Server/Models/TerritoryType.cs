namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TerritoryType
    {    
        public int Id { get; set; }
        public string Description { get; set; } = default!;
    
        public virtual ICollection<Territory> Territories { get; set; } = default!;
    }
}
