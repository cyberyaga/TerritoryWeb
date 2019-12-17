namespace TerritoryWeb.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Door
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string Comments { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string PostalCode { get; set; }
        
        [Column(TypeName = "decimal(9,6)")]
        public Nullable<decimal> GeoLat { get; set; }
        
        [Column(TypeName = "decimal(9,6)")]
        public Nullable<decimal> GeoLong { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime Added { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime Modified { get; set; }
    
        public Nullable<int> DoorCodeId { get; set; }
        public virtual DoorCode DoorCode { get; set; }
        public int TerritoryId { get; set; }
        public virtual Territory Territory { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
