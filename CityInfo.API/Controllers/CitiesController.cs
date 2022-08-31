using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    //[Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet()]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            CityModel city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id) ?? new CityModel() { Id = -1, Name = "Not Found", Description = ""};
            return new JsonResult(city);
        }
    }
}
