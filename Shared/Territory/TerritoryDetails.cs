using System;
using System.Collections.Generic;

namespace TerritoryWeb.Shared.Territory
{
    public class TerritoryDetails
    {
        public int Id { get; set; }
        public string? TerritoryName { get; set; }
        public string? TerritoryTypeStr { get; set; }
        public string? City { get; set; }
        public string? Notes { get; set; }
        public string? AssignedPublisher { get; set; }
        public DateTime? CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
        public string? LastCheckedInBy { get; set; }
        public int DoorCount { get; set; }
        public List<TerritoryBound>? TerritoryBounds { get; set; }

        public class TerritoryBound
        {
            public double GeoLat { get; set; }
            public double GeoLong { get; set; }
        }

        public string DoorsUrl
        {
            get
            {
                return "Door/" + this.Id;
            }
        }
    }
}