using System;

namespace TerritoryWeb.Shared.Territory
{
    public class TerritoryIndexView
    {
        public int TerritoryId { get; set; }
        public string TerritoryName { get; set; } = default!;
        public int DoorCount { get; set; }
        public string City { get; set; } = default!;
        public string TerritoryType { get; set; } = default!;
        public string AssignedPublisherName { get; set; } = default!;
        public DateTime LastCheckedOut { get; set; }
        public DateTime LastCheckedIn { get; set; }

        public string TerritoryUrl
        {
            get
            {
                return "Territory/Details/" + this.TerritoryId;
            }
        }

        public string DoorsUrl
        {
            get
            {
                return "Door/" + this.TerritoryId;
            }
        }

    }
}