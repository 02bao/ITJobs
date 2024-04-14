using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(
    IJobRepository _jobRepository, 
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateNewJob")]
    public IActionResult CreateNewJob(long companyid, Job_Create jobs, long categoryid, DateTime NewDate)
    {
        bool IsSuccess = _jobRepository.CreateNewJob(companyid, jobs, categoryid, NewDate);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        List<JobDTO> jobs = _mapper.Map<List<JobDTO>>(_jobRepository.GetAll());
        return Ok(jobs);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long id)
    {
        JobDTO jobs = _mapper.Map<JobDTO>(_jobRepository.GetById(id));
        return Ok(jobs);
    }

    [HttpGet("GetByCompanyId")]
    public IActionResult GetByCompanyId(long companyid)
    {
        List<JobDTO> jobs = _mapper.Map<List<JobDTO>>(_jobRepository.GetByCompanyId(companyid));
        return Ok(jobs);
    }

    [HttpGet("GetByCategoryid")]
    public IActionResult GetByCategoryid(long categoryid)
    {
        List<JobDTO> jobs = _mapper.Map<List<JobDTO>>(_jobRepository.GetByCategoryid(categoryid));
        return Ok(jobs);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] JobDTO _DTO)
    {
        var job = _mapper.Map<Job>(_DTO);
        bool IsSuccess = _jobRepository.Update(job);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long id)
    {
        bool IsSuccess = _jobRepository.Delete(id);
        return IsSuccess ? Ok() : BadRequest();
    }
}
