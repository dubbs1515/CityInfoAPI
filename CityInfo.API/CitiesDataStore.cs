using CityInfo.API.Models;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace CityInfo.API
{
    // Temp Dummy Data
    public class CitiesDataStore
    {
        public List<CityModel> Cities { get; set; }

        // Return an instance of this
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityModel>()
            {
                new CityModel()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "Home of the Mets."
                },
                new CityModel
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "A pleasant place to visit."
                },
                new CityModel
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "Home of the Eiffel Tower"
                }
            };
        }
    }
}
