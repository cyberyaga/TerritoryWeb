using System;

namespace TerritoryWeb.Shared.Territory
{
    public class NewTerritoryBase
    {
        public string TerritoryName { get; set; } = default!;
        public string City { get; set; } = default!;
        public int TerritoryTypeId { get; set; }
        public string Notes { get; set; } = default!;
        
    }
}