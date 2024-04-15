using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ConversationController(
    IConverSationRepository _converSationRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateNewConverByUser")]
    public IActionResult CreateNewConverByUser(long UserId , string CompanyName, string Contents)
    {
        bool IsSuccess = _converSationRepository.CreateNewConverByUser(UserId, CompanyName, Contents);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpPost("CreateNewConverByCompany")]
    public IActionResult CreateNewConverByCompany(long Companied, string UserName, string Contents)
    {
        bool IsSuccess = _converSationRepository.CreateNewConverByCompany(Companied, UserName, Contents);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetByUserId")]
    public IActionResult GetByUserId([FromQuery] long UserId)
    {
        var conver = _mapper.Map<List<Conversation_GetDTO>>(_converSationRepository.GetByUserId(UserId));
        return Ok(conver);
    }
}
