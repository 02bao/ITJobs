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

        [HttpGet("GetById")]
        public IActionResult GetById(long id)
        {
            var noti = _mapper.Map<NotificationDTO>(_notificationRepository.GetById(id));
            return Ok(noti);
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId([FromQuery] long userId)
        {
            var noti = _mapper.Map<List<NotificationDTO>>(_notificationRepository.GetByUserid(userId));
            return Ok(noti);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] NotificationDTO noti) 
        {
            var notid = _mapper.Map<Notification>(noti);
            bool tmp = _notificationRepository.Update(notid);
            if(tmp)
            {
                return Ok("Update Successfully");
            }
            return BadRequest("Update Failed, Please try again!");
        }
    }
    
}
