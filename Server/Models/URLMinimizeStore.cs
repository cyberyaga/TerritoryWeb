namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class URLMinimizeStore
    {
        public int id { get; set; }
        public string shortURL { get; set; }
        public string longURL { get; set; }
        public System.DateTime dateCreated { get; set; }
        public Nullable<System.DateTime> used { get; set; }
    }
}
