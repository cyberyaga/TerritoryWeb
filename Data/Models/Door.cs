namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Door
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(9, 6)")]
        public decimal GeoLat { get; set; }
        
        [Column(TypeName = "decimal(9, 6)")]
        public decimal GeoLong { get; set; }
        public string AddedBy { get; set; } = string.Empty;
        public DateTime Added { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime Modified { get; set; }
        public int? DoorCodeID { get; set; }    
        [ForeignKey("DoorCodeID")]
        public virtual DoorCode DoorCode { get; set; } = default!;
        public int TerritoryID { get; set; }
        [ForeignKey("TerritoryID")]
        public virtual Territory Territory { get; set; } = default!;
        public int? LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public virtual Language Language { get; set; } = default!;
    }
}
