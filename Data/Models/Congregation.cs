namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Congregation
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    
        [NotMapped]
        public virtual ICollection<Territory> Territories { get; set; } = default!;
        [NotMapped]
        public virtual ICollection<Language> Languages { get; set; } = default!;
        [NotMapped]
        public virtual ICollection<DoorCode> DoorCodes { get; set; } = default!;
    }
}
