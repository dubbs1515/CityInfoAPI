﻿namespace CityInfo.API.Models
{
    // DTO: Data Transfer Object
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
