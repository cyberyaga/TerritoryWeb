namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Language
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    
        public virtual ICollection<Door> Doors { get; set; } = default!;
        public int? CongregationID { get; set; }
        [ForeignKey("CongregationID")]
        public virtual Congregation Congregation { get; set; } = default!;
    }
}
