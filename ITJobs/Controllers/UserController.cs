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

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserDTO _DTO)
        {
            var users = _mapper.Map<User>(_DTO);
            bool tmp = _userRepository.Register(users);
            if(tmp)
            {
                return Ok("Register Succesfully");
            }
            return BadRequest("Register Failed, Please try again!");
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var users = _mapper.Map<List<UserDTO>>(_userRepository.GetAll());

            return Ok(users);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long userid)
        {
            var user = _mapper.Map<User>(_userRepository.GetById(userid));
            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login(User_login user) 
        { 
            var users = _userRepository.Login(user);
            if(users > 0)
            {
                return Ok(users);
            }
            return BadRequest("Login Failed, Please try again!");

        }

        [HttpPut("Update")]
        public IActionResult Update( [FromBody] UserDTO _DTO)
        {
            var user = _mapper.Map<User>(_DTO);
            bool tmp = _userRepository.Update(user);
            if (tmp)
            {
                 return Ok("Update Successfully");
            }
            return BadRequest("Update Failed, Please try again!");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long userid)
        {
            bool tmp = _userRepository.Delete(userid);
            if (tmp)
            {
                return Ok("Delete Successfully");
            }
            return BadRequest("Delete Failed, Please try again!");
        }

    }
}
