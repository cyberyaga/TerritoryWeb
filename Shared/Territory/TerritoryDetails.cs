using System;
using System.Collections.Generic;

namespace TerritoryWeb.Shared.Territory
{
    public class TerritoryDetails
    {
        public int Id { get; set; }
        public string TerritoryName { get; set; } = string.Empty;
        public string TerritoryTypeStr { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string AssignedPublisher { get; set; } = string.Empty;
        public DateTime? CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
        public string LastCheckedInBy { get; set; } = string.Empty;
        public int DoorCount { get; set; }
        public List<TerritoryBound> TerritoryBounds { get; set; } = new List<TerritoryBound>();

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