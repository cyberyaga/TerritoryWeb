using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerritoryWeb.Models
{
    public class TerritoryAccessModel
    {
        public int TerritoryId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsWrite { get; set; }
        public bool IsTempAccess { get; set; }
    }
}