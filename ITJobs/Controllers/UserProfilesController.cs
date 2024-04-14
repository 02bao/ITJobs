using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfilesController(
    IUserProfilesRepository _userProfilesRepository, 
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateUserProfiles")]
    public IActionResult CreateUserProfiles(long userid, UserProfiles_Create create)
    {
        bool IsSuccess = _userProfilesRepository.CreateUserProfiles(userid, create);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        List<UserProfilesDTO> users = _mapper.Map<List<UserProfilesDTO>>(_userProfilesRepository.GetAll());
        return Ok(users);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long userprofileId)
    {
        UserProfilesDTO users = _mapper.Map<UserProfilesDTO>(_userProfilesRepository.GetById(userprofileId));
        return Ok(users);
    }

    [HttpGet("GetByUserId")]
    public IActionResult GetByUserId([FromQuery] long userid)
    {
        List<UserProfilesDTO> users = _mapper.Map<List<UserProfilesDTO>>(_userProfilesRepository.GetByUserId(userid));
        return Ok(users);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromForm] UserProfilesDTO _DTO,[FromForm] List<IFormFile> avatarfile) 
    {
        UserProfiles user = _mapper.Map<UserProfiles>(_DTO);
        bool IsSuccess = _userProfilesRepository.Update(user, avatarfile);
        return IsSuccess? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long userprofileid)
    {
        bool IsSuccess = _userProfilesRepository.Delete(userprofileid);
        return IsSuccess ? Ok() : BadRequest();
    }
}
