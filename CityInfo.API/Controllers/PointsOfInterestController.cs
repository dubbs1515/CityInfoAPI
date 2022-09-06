using CityInfo.API.Models;
using CityInfo.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestModel>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null) { return NotFound(); }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestModel> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null) { return NotFound(); }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(city => city.Id == pointOfInterestId);
            if (pointOfInterest == null) { return NotFound(); }

            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestModel> CreatePointOfInterest(int cityId, [FromBody] PointOfInterestViewModel pointOfInterestViewModel)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null) { return NotFound(); }

            // Temp Id Generation
            int maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                city => city.PointsOfInterest).Max(point => point.Id);

            var newPointOfInterest = new PointOfInterestModel()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterestViewModel.Name,
                Description = pointOfInterestViewModel.Description
            };

            city.PointsOfInterest.Add(newPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = newPointOfInterest.Id
                },
                newPointOfInterest);
        }

        [HttpPut("{pointOfInterestId}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId,
            PointOfInterestViewModel pointOfInterestViewModel)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null) { return NotFound(); }

            var pointOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);
            if (pointOfInterestToUpdate == null) { return NotFound(); }

            pointOfInterestToUpdate.Name = pointOfInterestViewModel.Name;
            pointOfInterestToUpdate.Description = pointOfInterestViewModel.Description;

            return NoContent();
        }

        [HttpPatch("{pointOfInterestId}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
            JsonPatchDocument<PointOfInterestViewModel> patchDocument)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null) { return NotFound(); }

            var pointOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);
            if (pointOfInterestToUpdate == null) { return NotFound(); }

            var pointOfInterestViewModel = new PointOfInterestViewModel()
            {
                Name = pointOfInterestToUpdate.Name,
                Description = pointOfInterestToUpdate.Description
            };

            patchDocument.ApplyTo(pointOfInterestViewModel, ModelState);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (!TryValidateModel(pointOfInterestViewModel)) { return BadRequest(ModelState); }

            pointOfInterestToUpdate.Name = pointOfInterestViewModel.Name;
            pointOfInterestToUpdate.Description = pointOfInterestViewModel.Description;

            return NoContent();
        }
    }
}