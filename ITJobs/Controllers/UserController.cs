using AutoMapper;
using ITJobs.Data;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserControlle(
    IUserRepository _userRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("Register")]
    public IActionResult Register(User_Register users)
    {
        bool IsSuccess = _userRepository.Register(users);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetList")]
    public IActionResult GetList()
    {
        List<UserDTO> users = _mapper.Map<List<UserDTO>>(_userRepository.GetAll());
        return Ok(users);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long userid)
    {
        UserDTO user = _mapper.Map<UserDTO>(_userRepository.GetById(userid));
        return Ok(user);
    }

    [HttpPost("Login")]
    public IActionResult Login(User_login user) 
    { 
        long users = _userRepository.Login(user);
        return ( users > 0) ? Ok(users) : BadRequest();

    }

    [HttpPut("Update")]
    public IActionResult Update( [FromBody] UserDTO _DTO)
    {
        User user = _mapper.Map<User>(_DTO);
        bool IsSuccess = _userRepository.Update(user);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long userid)
    {
        bool IsSuccess = _userRepository.Delete(userid);
        return IsSuccess ? Ok() : BadRequest();
    }

}
