using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController(
    ICompanyRepository _companyRepository,
    IMapper _mapper) : ControllerBase
{

    [HttpPost("CreateNewCompany")]
    public IActionResult CreateNewCompany(Company_Create create, long userid)
    {
        bool IsSuccess = _companyRepository.CreateNewCompany(create, userid);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GetList()
    {
        List<CompanyDTO> companies = _mapper.Map<List<CompanyDTO>>(_companyRepository.GetAll());
        return Ok(companies);
    }

    [HttpGet("GetByUSerId")]
    public IActionResult GetByUSerId(long userid)
    {
        List<CompanyDTO> companies = _mapper.Map<List<CompanyDTO>>(_companyRepository.GetByUserId(userid));
        return Ok(companies);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long companyid)
    {
        CompanyDTO company = _mapper.Map<CompanyDTO>(_companyRepository.GetById(companyid));
        return Ok(company);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] CompanyDTO _DTO)
    {
        var company = _mapper.Map<Company>(_DTO);
        bool IsSuccess = _companyRepository.Update(company);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long companyid)
    {
        bool IsSuccess = _companyRepository.Delete(companyid);
        return IsSuccess ? Ok() : BadRequest();
    }
}
