using System;
using System.ComponentModel.DataAnnotations;

namespace TerritoryWeb.Shared.Territory
{
    public class NewTerritoryBase
    {
        [Required]
        [StringLength(50, ErrorMessage = "Territory Name is too long.")]
        public string? TerritoryName { get; set; }

        [StringLength(50, ErrorMessage = "City Name is too long.")]
        public string? City { get; set; }
        public int TerritoryTypeId { get; set; }
        public string? Notes { get; set; }
        
    }
}