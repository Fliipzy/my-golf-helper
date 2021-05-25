using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGolfHelper.Models;
using MyGolfHelper.Models.Dtos;
using MyGolfHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGolfHelper.WebApi.Controllers
{
    [ApiController]
    [Route("api/golfcourses")]
    public class GolfCourseController : ControllerBase
    {
        private readonly IGolfCourseService<GolfCourse, long> _golfCourseService;
        private readonly IMapper _mapper;

        public GolfCourseController(IGolfCourseService<GolfCourse, long> golfCourseService, IMapper mapper)
        {
            _golfCourseService = golfCourseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GolfCourseDto>>> GetGolfCourses()
        {
            var golfCourses = await _golfCourseService.GetAllGolfCourses();

            if (!golfCourses.Any())
            {
                return NoContent();
            }

            var golfCourseDtos = _mapper.Map<IEnumerable<GolfCourseDto>>(golfCourses);
            return Ok(golfCourseDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GolfCourseDto>> GetGolfCourse(long id)
        {
            var golfCourse = await _golfCourseService.FindGolfCourse(id);

            if (golfCourse == null)
            {
                return NotFound();
            }

            var golfCourseDto = _mapper.Map<GolfCourseDto>(golfCourse);
            return Ok(golfCourseDto);
        }

        [HttpPost]
        public async Task<ActionResult<GolfCourseDto>> PostGolfCourse(NewGolfCourseRequestDto newGolfCourseRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var golfCourse = _mapper.Map<GolfCourse>(newGolfCourseRequestDto);
            var wasCreated = await _golfCourseService.CreateGolfCourse(golfCourse);

            if (!wasCreated)
            {
                return UnprocessableEntity();
            }

            return Ok(golfCourse);
        }
    }
}
