namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TerritoryType
    {    
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    
        [NotMapped]
        public virtual ICollection<Territory> Territories { get; set; } = default!;
    }
}
