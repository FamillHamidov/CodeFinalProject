using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.Services.Catalog.Dtos;
using Travel.Services.Catalog.Services;
using Travel.Shared.ControllerBases;

namespace Travel.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : CustomBaseController
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var tours = await _tourService.GetAllAsync();
            return CreateActionResultInstance(tours);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var tour = await _tourService.GetByIdAsync(id);
            return CreateActionResultInstance(tour);
        }
        [HttpGet]
        [Route("GetAllByUserId/{userid}")]
        public async Task<IActionResult> GetAllByUserId(string userid)
        {
            var tour = await _tourService.GetByIdAsync(userid);
            return CreateActionResultInstance(tour);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TourCreateDto tourCreateDto)
        {
            var tour = await _tourService.CreateAsync(tourCreateDto);
            return CreateActionResultInstance(tour);
        }
        [HttpPut]
        public async Task<IActionResult> Update(TourUpdateDto tourUpdateDto)
        {
            var tour = await _tourService.UpdateAsync(tourUpdateDto);
            return CreateActionResultInstance(tour);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tour = await _tourService.DeleteAsync(id);
            return CreateActionResultInstance(tour);
        }
    }
}
