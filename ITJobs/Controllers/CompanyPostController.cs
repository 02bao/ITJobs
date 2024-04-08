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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var posts = _mapper.Map<List<CompanyPostDTO>>(_companyPostRepository.GetAll()); 
            return Ok(posts);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long id)
        {
            var post = _mapper.Map<CompanyPostDTO>(_companyPostRepository.GetById(id));
            return Ok(post);
        }

        [HttpGet("GetByCompanyId")]
        public IActionResult GetByCompanyId([FromQuery] long companyid)
        { 
            var post = _mapper.Map<List<CompanyPostDTO>>(_companyPostRepository.GetByCompanyId(companyid));
            return Ok(post);
        }
        
    }
}
