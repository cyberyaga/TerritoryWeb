namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Territory
    {
        public Territory()
        {
            //this.TerritoryBounds = new HashSet<TerritoryBound>();
            //this.Doors = new HashSet<Door>();
            //this.TerritoryAccesses = new HashSet<TerritoryAccess>();
        }
    
        public int Id { get; set; }
        public string TerritoryName { get; set; }
        public string City { get; set; }
        public int Type { get; set; }
        public string Notes { get; set; }
        public int CongregationID { get; set; }
        public string AssignedPublisherID { get; set; }
        public string AddedBy { get; set; }
        public System.DateTime Added { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public Nullable<System.DateTime> CheckedOut { get; set; }
        public Nullable<System.DateTime> CheckedIn { get; set; }
        public string LastCheckedInBy { get; set; }
    
        public virtual Congregation Congregation { get; set; }
        public virtual TerritoryType TerritoryType { get; set; }
        public virtual ICollection<TerritoryBound> TerritoryBounds { get; set; }
        // public virtual AspNetUser AssignedUser { get; set; }
        // public virtual AspNetUser LastCheckedInUser { get; set; }
        public virtual ICollection<Door> Doors { get; set; }
        // public virtual ICollection<TerritoryAccess> TerritoryAccesses { get; set; }
    }
}
