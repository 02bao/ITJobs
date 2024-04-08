using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPostController : ControllerBase
    {
        private readonly IUserPostRepository _userPostRepository;
        private readonly IMapper _mapper;

        public UserPostController(IUserPostRepository userPostRepository, IMapper mapper)
        {
            _userPostRepository = userPostRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewPost")]
        public IActionResult CreateNewPost(long userid , [FromBody] UserPostDTO _DTO)
        {
            var post = _mapper.Map<UserPost>(_DTO);
            bool tmp = _userPostRepository.CreateNewPost(userid, post);
            if(tmp)
            {
                return Ok("Create New Post Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var post = _mapper.Map<List<UserPostDTO>>(_userPostRepository.GetPosts());
            return Ok(post);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long postid)
        {
            var post = _mapper.Map<UserPostDTO>(_userPostRepository.GetPostById(postid));
            return Ok(post);
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId( [FromQuery] long userId)
        {
            var post = _mapper.Map<List<UserPostDTO>>(_userPostRepository.GetPsotsByUserId(userId));
            return Ok(post);
        }
    }
}
