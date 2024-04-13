using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationController(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateNewNoti")]
        public IActionResult CreateNewNoti(long userid, long companyid, long applied,  Status_Noti status)
        {
            bool tmp = _notificationRepository.CreateNewNoti(userid, companyid, applied, status);
            if(tmp)
            {
                return Ok("Create Successfully");
            }
            return BadRequest("Create Failed, Please try again!");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var noti = _mapper.Map<List<NotificationDTO>>(_notificationRepository.GetAll());
            return Ok(noti);
        }

    }
}
