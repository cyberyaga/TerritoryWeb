using System;

namespace TerritoryWeb.Shared.Territory
{
    public class TerritoryIndexView
    {
        public int TerritoryId { get; set; }
        public string? TerritoryName { get; set; }
        public int DoorCount { get; set; }
        public string? City { get; set; }
        public string? TerritoryType { get; set; }
        public string? AssignedPublisherName { get; set; }
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