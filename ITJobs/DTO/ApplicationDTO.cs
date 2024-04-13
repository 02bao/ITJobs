using ITJobs.Models;

namespace ITJobs.DTO
{
    public class ApplicationDTO
    {
        public long Id { get; set; }
        // ở đây biến letter đang bị warning null, anh thêm `required` vào trước `string` nhé
        //public required string Letter { get; set; } 
        public string Letter { get; set; } = string.Empty; // hoặc có thể như này để tránh warning null
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Status_Apply Status_ { get; set; } = Status_Apply.Pending;
    }
    // nên bỏ mấy dòng trống như này
}
// và như này nhé anh