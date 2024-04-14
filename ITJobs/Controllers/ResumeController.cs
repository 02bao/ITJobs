using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumeController(
    IResumeRepository _resumeRepository, 
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateNewCv")]
    public IActionResult CreateNewCv(long userid, Resume_create create)
    {
        bool IsSuccess = _resumeRepository.CreateNewCV(userid, create);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long CvId)
    {
        ResumeDTO cv = _mapper.Map<ResumeDTO>(_resumeRepository.GetById(CvId));
        return Ok(cv);
    }

    [HttpGet("GetByUserId")]
    public IActionResult GetByUserId(long UserId)
    {
        List<ResumeDTO> user = _mapper.Map<List<ResumeDTO>>(_resumeRepository.GetByUserId(UserId));
        return Ok(user);
    }

    [HttpGet("GetAll")]
    public IActionResult GetList()
    {
        List<ResumeDTO> users = _mapper.Map<List<ResumeDTO>>(_resumeRepository.GetAll());
        return Ok(users);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromForm] ResumeDTO _DTO) 
    {
        var cvs = _mapper.Map<Resume>(_DTO);
        bool IsSuccess = _resumeRepository.Update(cvs);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long cvId)
    {
        bool IsSuccess = _resumeRepository.Delete(cvId);
        return IsSuccess ? Ok() : BadRequest();
    }

}
