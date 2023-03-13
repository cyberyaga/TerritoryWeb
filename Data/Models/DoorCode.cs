namespace TerritoryWeb.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DoorCode
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    
        [NotMapped]
        public virtual ICollection<Door> Doors { get; set; } = new HashSet<Door>();
        public int CongregationID { get; set; }
        [ForeignKey("CongregationID")]
        public virtual Congregation Congregation { get; set; } = default!;
    }
}
