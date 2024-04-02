using AutoMapper;
using ITJobs.Data;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IActionResult Register( [FromBody] UserDTO _DTO) 
        {
            var user = _mapper.Map<User>(_DTO);
            bool tmp = _userRepository.Register(user);
            if(tmp)
            {
                return Ok("Register Successfully");
            }
            return BadRequest("Failed, Please try again!");
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var user = _mapper.Map<List<UserDTO>>(_userRepository.GetUsers());
            return Ok(user);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long userid)
        {
            var user = _mapper.Map<UserDTO>(_userRepository.GetById(userid));
            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserDTO _DTO)
        {
            var users = _mapper.Map<User_login>(_DTO);
            var userlogin = _userRepository.Login(users);
            if(userlogin > 0)
            {
                return Ok(userlogin);
            }
            return BadRequest("Login Failed, Please Try again!");
        }
    }
}
