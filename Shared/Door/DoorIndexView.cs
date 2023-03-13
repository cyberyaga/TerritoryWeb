using System;

namespace TerritoryWeb.Shared.Door
{
    public class DoorIndexView
    {
        public int Id { get; set; }                
        public int TerritoryId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;

        public string Url
        {
            get
            {
                return "Door/" + this.Id;
            }
        }
    }
}