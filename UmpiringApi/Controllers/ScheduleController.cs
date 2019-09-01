using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UmpiringApi.Dtos;
using UmpiringApi.Models;

namespace UmpiringApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly SQL2008_739130_dallascrickContext _context;
        private readonly IMapper _mapper;
        public ScheduleController(SQL2008_739130_dallascrickContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedule()
        {
            var data = await _context.TblBook.ToListAsync();
           // var scheduleData = _mapper.Map<ScheduleListDto>(data);
            return Ok(data);
        }
    }
}