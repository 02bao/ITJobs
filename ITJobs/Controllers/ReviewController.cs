using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReviewController(
    IReviewRepository _reviewRepository ,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateNewReview")]
    public IActionResult CreateNewReview(long UserId, string CompanyName , [FromBody] ReviewDTO_Create _DTO)
    {
        Review_Create Review = _mapper.Map<Review_Create>(_DTO);
        bool IsSuccess = _reviewRepository.CreateNewReview(UserId, CompanyName, Review);
        return IsSuccess ? Ok(): BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GettAll()
    {
        var Review = _mapper.Map<List<ReviewDTO>>(_reviewRepository.GetAll());
        return Ok(Review);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long Id)
    {
        var Review = _mapper.Map<ReviewDTO>(_reviewRepository.GetById(Id));
        return Ok(Review);
    }

    [HttpGet("GetByUserId")]
    public IActionResult GetByUserId([FromQuery] long UserId)
    {
        List<ReviewDTO> Review = _mapper.Map<List<ReviewDTO>>(_reviewRepository.GetByUserId(UserId));
        return Ok(Review);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] ReviewDTO _DTO)
    {
        var Review = _mapper.Map<Review>(_DTO);
        bool IsSuccess = _reviewRepository.Update(Review);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long Id)
    {
        bool IsSuccess = _reviewRepository.Delete(Id);
        return IsSuccess ? Ok() : BadRequest();
    }
}
