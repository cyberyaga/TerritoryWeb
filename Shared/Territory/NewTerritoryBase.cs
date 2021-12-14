using System;

namespace TerritoryWeb.Shared.Territory
{
    public class NewTerritoryBase
    {
        public string? TerritoryName { get; set; }
        public string? City { get; set; }
        public int TerritoryTypeId { get; set; }
        public string? Notes { get; set; }
        
    }
}