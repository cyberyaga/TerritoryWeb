namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoorCode
    {    
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public int CongregationID { get; set; }
    
        public virtual ICollection<Door> Doors { get; set; } = default!;
        public virtual Congregation Congregation { get; set; } = default!;
    }
}
