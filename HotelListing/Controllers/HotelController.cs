using AutoMapper;
using HotelListing.Data;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            throw new Exception();

            var hotels = await _unitOfWork.Hotels.GetAll();
            var results = _mapper.Map<IList<HotelDTO>>(hotels);
            return Ok(results);

        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            throw new Exception();

            var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id, new List<string> { "Country" });
            var result = _mapper.Map<HotelDTO>(hotel);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHotels([FromBody] CreateHotelDTO hotelDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateHotels)}");
                return BadRequest(ModelState);
            }

            throw new Exception();

            var hotel = _mapper.Map<Hotel>(hotelDTO);
            await _unitOfWork.Hotels.Insert(hotel);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);

        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO hotelDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateHotel)}");
                return BadRequest(ModelState);
            }

            throw new Exception();

            var hotel = await _unitOfWork.Hotels.Get(h => h.Id == id);
            if (hotel == null)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateHotel)}");
                return BadRequest("Submiteted data is invalid");
            }
            _mapper.Map(hotelDTO, hotel);
            _unitOfWork.Hotels.Update(hotel);
            await _unitOfWork.Save();

            return NoContent();

        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attempt in {nameof(DeleteHotel)}");
                return BadRequest();
            }

            throw new Exception();
            var country = _unitOfWork.Hotels.Get(c => c.Id == id);
            if (country == null)
            {
                _logger.LogError($"Invalid Delete attempt in {nameof(DeleteHotel)}");
                return BadRequest("Submitted data is invalid");
            }
            await _unitOfWork.Hotels.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }
    }
}
