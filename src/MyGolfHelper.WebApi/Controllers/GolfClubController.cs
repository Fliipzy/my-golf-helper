using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGolfHelper.Data;
using MyGolfHelper.Models;
using MyGolfHelper.Models.Dtos;
using MyGolfHelper.Services;

namespace MyGolfHelper.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/golfclubs")]
    public class GolfClubController : ControllerBase
    {
        private readonly IGolfClubService<GolfClub, long> _golfClubService;
        private readonly IMapper _mapper;

        public GolfClubController(IGolfClubService<GolfClub, long> golfClubService, IMapper mapper)
        {
            _golfClubService = golfClubService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GolfClub>>> GetGolfClubs()
        {
            var golfClubs = await _golfClubService.GetAllGolfClubsAsync();

            if (!golfClubs.Any())
            {
                return NoContent();
            }

            var golfClubDtos = _mapper.Map<IEnumerable<GolfClubDto>>(golfClubs);
            return Ok(golfClubDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GolfClub>> GetGolfClub(long id)
        {
            var golfClub = await _golfClubService.FindGolfClubAsync(id);

            if (golfClub == null)
            {
                return NotFound();
            }

            return Ok(golfClub);
        }

        [HttpPost]
        public async Task<ActionResult<GolfClub>> PostGolfClub(NewGolfClubRequestDto newGolfClubRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var golfClub = _mapper.Map<GolfClub>(newGolfClubRequestDto);
            var wasCreated = await _golfClubService.CreateGolfClubAsync(golfClub);

            if (!wasCreated)
            {
                return UnprocessableEntity();
            }

            return Ok(golfClub);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGolfClub(long id)
        {
            var golfClub = await _golfClubService.FindGolfClubAsync(id);
            if (golfClub == null)
            {
                return NotFound();
            }

            await _golfClubService.DeleteGolfClubAsync(id);
            return NoContent();
        }
    }
}
