using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public ResumeController(IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewCv")]
        public IActionResult CreateNewCv(long userid, [FromBody] ResumeDTO _DTO)
        {
            var users = _mapper.Map<Resume>(_DTO);
            bool tmp = _resumeRepository.CreateNewCV(userid, users);
            if(tmp)
            {
                return Ok("Create New CV Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long CvId)
        {
            var cv = _mapper.Map<ResumeDTO>(_resumeRepository.GetById(CvId));
            return Ok(cv);
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(long UserId)
        {
            var user = _mapper.Map<List<ResumeDTO>>(_resumeRepository.GetByUserId(UserId));
            return Ok(user);
        }

        [HttpGet("GetAll")]
        public IActionResult GetList()
        {
            var users = _mapper.Map<List<ResumeDTO>>(_resumeRepository.GetAll());
            return Ok(users);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] ResumeDTO _DTO) 
        {
            var cvs = _mapper.Map<Resume>(_DTO);
            bool tmp = _resumeRepository.Update(cvs);
            if( tmp) 
            {
                return Ok("Update Successfully");
            }
            return BadRequest("Update Failed, Please try again!");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long cvId)
        {
            bool tmp = _resumeRepository.Delete(cvId);
            if(tmp)
            {
                return Ok("Delete Successfully");
            }
            return BadRequest("Delete Failed, Please try again!");
        }

    }
}
