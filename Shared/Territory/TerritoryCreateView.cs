using System;
using System.Collections.Generic;

namespace TerritoryWeb.Shared.Territory
{
    public class TerritoryCreateView
    {
        public List<TerritoryType>? TerritoryTypes { get; set; }
    }

    public class TerritoryType
    {
        public int TerritoryTypeId { get; set; }
        public string TerritoryTypeDescription { get; set; } = string.Empty;
    }
}