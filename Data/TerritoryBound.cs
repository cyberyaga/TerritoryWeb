namespace TerritoryWeb.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TerritoryBound
    {
        [Key]
        public int BoundaryID { get; set; }
        public int TerritoryID { get; set; }
        public decimal GeoLat { get; set; }
        public decimal GeoLong { get; set; }
    
        public virtual Territory Territory { get; set; }
    }
}
