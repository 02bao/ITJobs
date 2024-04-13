using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;
// Bấm `alt + enter` để convert sang file-scope hết tất cả các file có trong project nhé anh
namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
// sửa cái controller thành dạng như này nha, nó rút gọn được vài dòng
public class ApplicationController(
    IApplicationRepository _applicationRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("AddNewApply")]
    public IActionResult AddNewApply(long userid, long jobid, long resumeid)
    // viết hoa chữ cái đầu của các tham số nha anh
    // ví dụ: UserId, JobId, ResumeId
    {
        bool tmp = _applicationRepository.AddNewApply(userid, jobid, resumeid);
        // hồi xưa tôi hay đặt tmp là temporary, nghĩa là tạm thời
        // nhưng mà nó không rõ ràng lắm, anh nên đặt tên biến rõ ràng hơn
        // ví dụ: IsSuccess, IsSuccessful, IsAdded, ...
        if (tmp) // ở đây nên đổi thành IsSuccess
        {
            return Ok("Apply Successfully, Please wait Company response");
        }
        return BadRequest("Apply Failed, Please try again!");

        // rồi thay vì anh viết 2 dòng return như này
        // anh có thể viết gọn lại thành 1 dòng như sau

        // return IsSuccess ? Ok("Apply Successfully, Please wait Company response") : BadRequest("Apply Failed, Please try again!");


        // nhưng mà ở đây anh trả về method Ok() và BadRequest() nó đã bao hàm ý nghĩa của cái
        // message của anh rồi, nên anh có thể viết gọn như sau

        // return IsSuccess ? Ok() : BadRequest();


        // rồi ngoài các method như Ok(), BadRequest() anh đi tìm hiểu thêm một vài các method khác để dùng trong trường hợp khác
        // ví dụ như Created(), NotFound(), NoContent() 
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {// cách khai báo nặc danh
        var applications = _mapper.Map<List<ApplicationDTO>>(_applicationRepository.GetAll());
        //List<ApplicationDTO> applications = _mapper.Map<List<ApplicationDTO>>(_applicationRepository.GetAll());
        // hồi xưa tôi hay dùng var vì thấy nó ngắn gọn, nhưng mà vừa rồi tôi thấy nó sẽ làm chậm 1 chút xíu quá trình chạy
        // nên là recommend anh viết cụ thể ra nhé
        // anh có thể viết var trước, sau đó anh đưa con trỏ chuột vào chữ var, nhấn `ctrl + .` để convert sang kiểu dữ liệu cụ thể
        return Ok(applications);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long id)
    {
        var applications = _mapper.Map<ApplicationDTO>(_applicationRepository.GetById(id));
        return Ok(applications);
    }

    [HttpGet("GetByUserid")] // tương tự ở đây Id nên viết hoa nhé anh
    public IActionResult GetByUserid([FromQuery] long userId)
    {
        var applications = _mapper.Map<List<ApplicationDTO>>(_applicationRepository.GetByUserId(userId));
        return Ok(applications);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] ApplicationDTO _DTO)
    {
        var applies = _mapper.Map<Application>(_DTO);
        bool tmp = _applicationRepository.Update(applies);
        if (tmp)
        {
            return Ok("Update successfully");
        }
        return BadRequest("Update Failed, Please try again!");
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long id)
    {
        bool tmp = _applicationRepository.Delete(id);
        if (tmp)
        {
            return Ok("Delete Successfully");
        }
        return BadRequest("Delete Failed, Please try again!");
    }

}
