namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Congregation
    {
        public Congregation()
        {
            this.Territories = new HashSet<Territory>();
            //this.AspNetUsers = new HashSet<AspNetUser>();
            this.Languages = new HashSet<Language>();
            this.DoorCodes = new HashSet<DoorCode>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Territory> Territories { get; set; }
        //public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<DoorCode> DoorCodes { get; set; }
    }
}
