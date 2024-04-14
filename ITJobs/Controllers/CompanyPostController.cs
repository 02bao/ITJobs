using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyPostController(
    ICompanyPostRepository _companyPostRepository, 
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateNewPost")]
    public IActionResult CreateNewPost(long companyid, CompanyPost_Create create, DateTime experiation )
    {
        bool IsSuccess = _companyPostRepository.CreateNewPost(companyid, create, experiation);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        List<CompanyPostDTO> posts = _mapper.Map<List<CompanyPostDTO>>(_companyPostRepository.GetAll()); 
        return Ok(posts);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long id)
    {
        CompanyPostDTO post = _mapper.Map<CompanyPostDTO>(_companyPostRepository.GetById(id));
        return Ok(post);
    }

    [HttpGet("GetByCompanyId")]
    public IActionResult GetByCompanyId([FromQuery] long companyid)
    {
        List<CompanyPostDTO> post = _mapper.Map<List<CompanyPostDTO>>(_companyPostRepository.GetByCompanyId(companyid));
        return Ok(post);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromForm] CompanyPostDTO _DTO,[FromForm] List<IFormFile> images)
    {
        CompanyPost posts = _mapper.Map<CompanyPost>(_DTO);
        bool IsSuccess = _companyPostRepository.Update(posts, images);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long postid)
    {
        bool IsSuccess = _companyPostRepository.Delete(postid);
        return IsSuccess ? Ok() : BadRequest();
    }
}
