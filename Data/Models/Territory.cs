namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Territory
    {
        public int Id { get; set; }
        public string TerritoryName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string AssignedPublisherID { get; set; } = string.Empty;
        public string AddedBy { get; set; } = string.Empty;
        public System.DateTime Added { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public System.DateTime Modified { get; set; }
        public Nullable<System.DateTime> CheckedOut { get; set; }
        public Nullable<System.DateTime> CheckedIn { get; set; }
        public string LastCheckedInBy { get; set; } = string.Empty;
    
        public int CongregationID { get; set; }
        [ForeignKey("CongregationID")]
        public virtual Congregation Congregation { get; set; } = new Congregation();
        public int TerritoryTypeID { get; set; }
        [ForeignKey("TerritoryTypeID")]
        public virtual TerritoryType TerritoryType { get; set; } = new TerritoryType();
        public virtual ICollection<TerritoryBound> TerritoryBounds { get; set; } = default!;
        // public virtual AspNetUser AssignedUser { get; set; }
        // public virtual AspNetUser LastCheckedInUser { get; set; }
        public virtual ICollection<Door> Doors { get; set; } = default!;
        // public virtual ICollection<TerritoryAccess> TerritoryAccesses { get; set; }
    }
}
