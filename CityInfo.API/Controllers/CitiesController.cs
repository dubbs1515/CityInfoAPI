using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    //[Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        //[HttpGet()]
        //public JsonResult GetCities()
        //{
        //    return new JsonResult(CitiesDataStore.Current.Cities);
        //}
        
        [HttpGet()]
        public ActionResult<IEnumerable<CityModel>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        //[HttpGet("{id}")]
        //public JsonResult GetCity(int id)
        //{
        //    JsonResult jsonResult = new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id) ?? new CityModel() { Id = -1, Name = "Not Found", Description = "" });
        //    jsonResult.StatusCode = 200;

        //    return jsonResult;
        //}
        
        [HttpGet("{id}")]
        public ActionResult<CityModel> GetCity(int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id);

            if (city == null) { return NotFound(); }

            return Ok(city);
        }
    }
}
