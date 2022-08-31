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
                    Description = "Home of the Mets.",
                    PointsOfInterest = new List<PointOfInterestModel>()
                    {
                        new PointOfInterestModel()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited urban park in the United States."
                        },
                        new PointOfInterestModel()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattan."
                        }
                    }
                },
                new CityModel
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "A pleasant place to visit.",
                    PointsOfInterest = new List<PointOfInterestModel>()
                    {
                        new PointOfInterestModel()
                        {
                            Id = 3,
                            Name = "Cathedral of Our Lady",
                            Description = "A gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                        },
                        new PointOfInterestModel()
                        {
                            Id = 4,
                            Name = "Antwerp Central Station",
                            Description = "The finest railway architecture in Belgium."
                        }
                    }
                },
                new CityModel
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "Home of the Eiffel Tower",
                    PointsOfInterest = new List<PointOfInterestModel>()
                    {
                        new PointOfInterestModel()
                        {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars."
                        },
                        new PointOfInterestModel()
                        {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "The world's largest museum."
                        }
                    }
                }
            };
        }
    }
}
