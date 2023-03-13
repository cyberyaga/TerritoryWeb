namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class URLMinimizeStore
    {
        public int id { get; set; }
        public string shortURL { get; set; } = string.Empty;
        public string longURL { get; set; } = string.Empty;
        public System.DateTime dateCreated { get; set; }
        public Nullable<System.DateTime> used { get; set; }
    }
}
