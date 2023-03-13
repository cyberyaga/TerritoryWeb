namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    
    public partial class TerritoryAccess
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
        public bool TempAccess { get; set; }
    
        //public virtual AspNetUser AspNetUser { get; set; }
        public int TerritoryID { get; set; }
        [ForeignKey("TerritoryID")]
        public virtual Territory Territory { get; set; } = default!;
    }
}
