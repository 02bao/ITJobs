using AutoMapper;
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
        Conversation_Create NewConver = _converSationRepository.CreateNewConverByUserId(UserId, CompanyName, Contents);
        return Ok(NewConver);
    }
}
