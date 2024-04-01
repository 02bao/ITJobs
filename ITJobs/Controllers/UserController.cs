using AutoMapper;
using ITJobs.Data;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserDto users)
        {
            var user = _mapper.Map<User>(users);
            bool tmp = _userRepository.Register(user);
            if(tmp)
            {
                return Ok("Register Successfully");
            }
            else
            {
                return BadRequest("Error.Please try again!");
            }
           
        }
    }
}
