using System;

namespace TerritoryWeb.Shared.Door
{
    public class DoorIndexView
    {
        public int Id { get; set; }                
        public int TerritoryId { get; set; }
        public string? Address { get; set; }
        public string? Street { get; set; }
        public string? Apartment { get; set; }
        public string? Comments { get; set; }
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public string? Language { get; set; }

        public string Url
        {
            get
            {
                return "Door/" + this.Id;
            }
        }
    }
}