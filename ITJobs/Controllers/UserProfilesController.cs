using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfilesRepository _userProfilesRepository;
        private readonly IMapper _mapper;

        public UserProfilesController(IUserProfilesRepository userProfilesRepository, IMapper mapper)
        {
            _userProfilesRepository = userProfilesRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateUserProfiles")]
        public IActionResult CreateUserProfiles(long userid, [FromBody] UserProfilesDTO _DTO)
        {
            var user = _mapper.Map<UserProfiles>(_DTO);
            bool tmp = _userProfilesRepository.CreateUserProfiles(userid, user);
            if(tmp)
            {
                return Ok("Create NewProfiles Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _mapper.Map<List<UserProfilesDTO>>(_userProfilesRepository.GetAll());
            return Ok(users);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long userprofileId)
        {
            var users = _mapper.Map<UserProfilesDTO>(_userProfilesRepository.GetById(userprofileId));
            return Ok(users);
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(long userid)
        {
            var users = _mapper.Map<List<UserProfilesDTO>>(_userProfilesRepository.GetByUserId(userid));
            return Ok(users);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserProfilesDTO _DTO,[FromForm] IFormFile avatarfile) 
        {
            var user = _mapper.Map<UserProfiles>(_DTO);
            bool tmp = _userProfilesRepository.Update(user, avatarfile);
            if(tmp)
            {
                return Ok("Update Succesfully");
            }
            return BadRequest("Update Failed, Please try again!");
        }
    }
}
