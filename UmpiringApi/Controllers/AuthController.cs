using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UmpiringApi.Dtos;
using UmpiringApi.Models;
using UmpiringApi.Repositories;

namespace UmpiringApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(dynamic data)
        {
            var registerDto = new RegisterDto();
            try
            {
                if (data != null)
                {
                    foreach (Newtonsoft.Json.Linq.JProperty item in data)
                    {
                        switch (item.Name)
                        {
                            case "Email":
                                registerDto.Email = item.Value.ToString();
                                break;
                            case "FullName":
                                registerDto.FullName = item.Value.ToString();
                                break;
                            case "Password":
                                registerDto.Password = item.Value.ToString();
                                break;
                            case "RoleId":
                                registerDto.RoleId = item.Value.ToString();
                                break;
                            default:
                                break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
            registerDto.Email = registerDto.Email.ToLower();
            if (await _repo.UserExists(registerDto.Email))
                return BadRequest("Email already exists");

            var userToCreate = _mapper.Map<TblUser>(registerDto);
            var createdUser = await _repo.Register(userToCreate, registerDto.Password);
            return StatusCode(201, new { email = createdUser.Email, fullname = createdUser.FullName });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userFromRepo = await _repo.Login(loginDto.Email.ToLower(), loginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {token = tokenHandler.WriteToken(token), email = userFromRepo.Email, fullname = userFromRepo.FullName});
        }
    }
}