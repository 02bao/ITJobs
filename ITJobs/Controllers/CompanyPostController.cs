using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyPostController : ControllerBase
    {
        private readonly ICompanyPostRepository _companyPostRepository;
        private readonly IMapper _mapper;

        public CompanyPostController(ICompanyPostRepository companyPostRepository, IMapper mapper)
        {
            _companyPostRepository = companyPostRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewPost")]
        public IActionResult CreateNewPost(long companyid, [FromBody] CompanyPostDTO _DTO, DateTime experiation )
        {
            var posts = _mapper.Map<CompanyPost>(_DTO);
            bool tmp = _companyPostRepository.CreateNewPost(companyid, posts, experiation);
            if(tmp)
            {
                return Ok("Create New Post Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }
    }
}
