using System;
using System.ComponentModel.DataAnnotations;

namespace TerritoryWeb.Shared.Territory
{
    public class NewTerritoryBase
    {
        [Required]
        [StringLength(50, ErrorMessage = "Territory Name is too long.")]
        public string TerritoryName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "City Name is too long.")]
        public string City { get; set; } = string.Empty;
        public int TerritoryTypeId { get; set; }
        public string Notes { get; set; } = string.Empty;
        
    }
}