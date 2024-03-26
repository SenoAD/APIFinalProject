using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceBLL _place;
        public PlacesController(IPlaceBLL placeBLL)
        {
            _place = placeBLL;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPlace()
        {
            {
                var result = await _place.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost("GetByTags")]
        public async Task<IActionResult> GetByTags([FromBody] IEnumerable<int> tagIds)
        {
            if (tagIds == null || !tagIds.Any())
            {
                return BadRequest("Tags cannot be null or empty");
            }

            var result = await _place.GetPlacesByTags(tagIds);
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }



        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            {
                var result = await _place.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlaceDTO placeDTO)
        {
            {
                var result = await _place.Update(placeDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost("InsertNew")]
        public async Task<IActionResult> InsertNewPlace(PlaceCreateDTO placeCreateDTO)
        {
            {
                var result = await _place.Create(placeCreateDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            {
                var result = await _place.Delete(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost("InsertPlaceTag")]
        public async Task<IActionResult> InsertPlaceTag(int placeid, int tagid)
        {
            {
                var result = await _place.AddTagToPlace(placeid,tagid);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
