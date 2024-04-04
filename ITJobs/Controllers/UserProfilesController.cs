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
    }
}
