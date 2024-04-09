using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository , IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewCompany")]
        public IActionResult CreateNewCompany(Company_Create create, long userid)
        {
            bool tmp = _companyRepository.CreateNewCompany(create, userid);
            if(tmp)
            {
                return Ok("Create New Company Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }

        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            var companies = _mapper.Map<List<CompanyDTO>>(_companyRepository.GetAll());
            return Ok(companies);
        }

        [HttpGet("GetByUSerId")]
        public IActionResult GetByUSerId(long userid)
        {
            var companies = _mapper.Map<List<CompanyDTO>>(_companyRepository.GetByUserId(userid));
            return Ok(companies);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long companyid)
        {
            var company = _mapper.Map<CompanyDTO>(_companyRepository.GetById(companyid));
            return Ok(company);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CompanyDTO _DTO)
        {
            var company = _mapper.Map<Company>(_DTO);
            bool tmp = _companyRepository.Update(company);
            if(tmp) 
            { 
                return Ok("Change Information Successfully");
            }
            return BadRequest("Change Failed , Please try agian!");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long companyid)
        {
            bool tmp = _companyRepository.Delete(companyid);
            if( tmp)
            {
                return Ok("Delete Successfully");
            }
            return BadRequest("Delete Failed, Please try again!");
        }
    }
}
