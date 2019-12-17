namespace TerritoryWeb.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TerritoryBound
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal GeoLat { get; set; }
        
        [Column(TypeName = "decimal(9,6)")]
        public decimal GeoLong { get; set; }
    
        public int TerritoryId { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
