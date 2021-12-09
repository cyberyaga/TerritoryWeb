namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TerritoryAccess
    {
        public int Id { get; set; }
        public int TerritoryId { get; set; }
        public string UserId { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
        public bool TempAccess { get; set; }
    
        //public virtual AspNetUser AspNetUser { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
