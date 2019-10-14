using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UmpiringApi.Dtos;
using UmpiringApi.Models;
using UmpiringApi.Repositories;

namespace UmpiringApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly SQL2008_739130_dallascrickContext _context;
        private readonly IMapper _mapper;
        private readonly IRentalRepository _repo;
        public ScheduleController(IRentalRepository repo, SQL2008_739130_dallascrickContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetSchedule()
        //{
        //    var data = await _context.TblBook.ToListAsync();
        //   // var scheduleData = _mapper.Map<ScheduleListDto>(data);
        //    return Ok(data);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAssignments(LoginDto loginDto)
        {
            var assignments = await _repo.GetAssignments();
            if (assignments == null)
                return NotFound();
            return Ok(assignments);
        }
    }
}