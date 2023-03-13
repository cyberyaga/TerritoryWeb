namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Congregation
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    
        public virtual ICollection<Territory> Territories { get; set; } = default!;
        public virtual ICollection<Language> Languages { get; set; } = default!;
        public virtual ICollection<DoorCode> DoorCodes { get; set; } = default!;
    }
}
