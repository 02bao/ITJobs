using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPostController(
        IUserPostRepository _userPostRepository, 
        IMapper _mapper) : ControllerBase
    {
        [HttpPost("CreateNewPost")]
        public IActionResult CreateNewPost(long userid , UserPost_Create create)
        {
            bool IsSuccess = _userPostRepository.CreateNewPost(userid, create);
            return IsSuccess ? Ok() : BadRequest();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<UserPostDTO> post = _mapper.Map<List<UserPostDTO>>(_userPostRepository.GetPosts());
            return Ok(post);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long postid)
        {
            UserPostDTO post = _mapper.Map<UserPostDTO>(_userPostRepository.GetPostById(postid));
            return Ok(post);
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId( [FromQuery] long userId)
        {
            List<UserPostDTO> post = _mapper.Map<List<UserPostDTO>>(_userPostRepository.GetPsotsByUserId(userId));
            return Ok(post);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] UserPostDTO _DTO, [FromForm] List<IFormFile> images ) 
        {
            UserPost post = _mapper.Map<UserPost>(_DTO);
            bool IsSuccess = _userPostRepository.Update(post, images);
            return IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long postid)
        {
            bool IsSuccess = _userPostRepository.Delete(postid);
            return IsSuccess ? Ok() : BadRequest();
        }
    }
}
