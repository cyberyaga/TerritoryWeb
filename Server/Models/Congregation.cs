namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Congregation
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
    
        public virtual ICollection<Territory> Territories { get; set; } = new HashSet<Territory>();
        //public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<Language> Languages { get; set; } = new HashSet<Language>();
        public virtual ICollection<DoorCode> DoorCodes { get; set; } = new HashSet<DoorCode>();
    }
}
