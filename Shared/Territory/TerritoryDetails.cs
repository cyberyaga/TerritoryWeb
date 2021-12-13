using System;
using System.Collections.Generic;

namespace TerritoryWeb.Shared.Territory
{
    public class TerritoryDetails
    {
        public int Id { get; set; }
        public string TerritoryName { get; set; } = default!;
        public string TerritoryTypeStr { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Notes { get; set; } = default!;
        public string AssignedPublisher { get; set; } = default!;
        public DateTime? CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
        public string LastCheckedInBy { get; set; } = default!;
        public int DoorCount { get; set; }
        public List<TerritoryBound> TerritoryBounds { get; set; } = default!;

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