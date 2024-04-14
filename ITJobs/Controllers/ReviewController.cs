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
}
