namespace CityInfo.API.Models
{
    // DTO: Data Transfer Object
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumOfPointsOfInterest { get { return PointsOfInterest.Count; } }

        public ICollection<PointOfInterestModel> PointsOfInterest { get; set; } = new List<PointOfInterestModel>();
    }
}
