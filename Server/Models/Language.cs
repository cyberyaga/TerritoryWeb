namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Language
    {
        public Language()
        {
            this.Doors = new HashSet<Door>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> CongregationID { get; set; }
    
        public virtual ICollection<Door> Doors { get; set; }
        public virtual Congregation Congregation { get; set; }
    }
}
