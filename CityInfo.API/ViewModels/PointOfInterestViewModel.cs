using System;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.ViewModels
{
    public class PointOfInterestViewModel
    {
        [Required(ErrorMessage = "A value for name must be provided.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}

