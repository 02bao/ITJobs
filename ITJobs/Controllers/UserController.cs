using ITJobs.Data;
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

        public UserController(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpPost("Register")]
        public IActionResult Register( User_Register users) 
        {
            bool tmp = _userRepository.Register(users);
            if(tmp)
            {
                return Ok("Register Successfully");
            }
            return BadRequest("Failed, Please try again!");
        }
    }
}
