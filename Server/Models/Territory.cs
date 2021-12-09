namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Territory
    {
        public int Id { get; set; }
        public string TerritoryName { get; set; } = default!;
        public string City { get; set; } = default!;
        public int Type { get; set; }
        public string? Notes { get; set; }
        public int CongregationID { get; set; }
        public string? AssignedPublisherID { get; set; }
        public string? AddedBy { get; set; }
        public DateTime Added { get; set; }
        public string? ModifiedBy { get; set; } = default!;
        public DateTime Modified { get; set; }
        public DateTime? CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
        public string? LastCheckedInBy { get; set; }
    
        public virtual Congregation Congregation { get; set; } = default!;
        public virtual TerritoryType TerritoryType { get; set; } = default!;
        public virtual ICollection<TerritoryBound> TerritoryBounds { get; set; } = default!;
        // public virtual AspNetUser AssignedUser { get; set; }
        // public virtual AspNetUser LastCheckedInUser { get; set; }
        public virtual ICollection<Door> Doors { get; set; } = default!;
        // public virtual ICollection<TerritoryAccess> TerritoryAccesses { get; set; }
    }
}
