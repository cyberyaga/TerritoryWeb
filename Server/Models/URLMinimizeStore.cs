namespace TerritoryWeb.Server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class URLMinimizeStore
    {
        public int id { get; set; }
        public string shortURL { get; set; } = default!;
        public string longURL { get; set; } = default!;
        public System.DateTime dateCreated { get; set; }
        public DateTime? used { get; set; }
    }
}
