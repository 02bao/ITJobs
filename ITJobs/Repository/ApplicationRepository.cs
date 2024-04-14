using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace ITJobs.Repository;

// tương tự ở đây tôi có thể rút gọn dependency injection của file này như sau
public class ApplicationRepository(DataContext _context) : IApplicationRepository
{
    public bool AddNewApply(long userid, long jobid, long resumeid)
    {
        var user = _context.Users.SingleOrDefault(s => s.Id == userid);
        if (user == null)
        {
            return false;
        }
        var job = _context.Jobs.Include(s => s.Companies).ThenInclude(s => s.User)
                                                         .Include(s => s.Companies).ThenInclude(s => s.Categories)
                                                         .Where(s => s.Id == jobid &&
                                                          s.Categories.Companies.Id == jobid &&
                                                          s.Companies.User.Id != userid &&
                                                          s.Deadline > DateTime.UtcNow).FirstOrDefault();

        if (job == null)
        {
            return false;
        }
        // ResumeId của anh là 1 số long, nó là 1 số thì chắc chắn nó không null được 
        // nên ở đây anh không cần phải check null cho nó
        //if (resumeid != null)
        //{


        // ở đây anh viết câu lệnh chưa đẹp lắm, tôi viết lại cho nó đẹp nhé

        Resume? resumes = _context.Resume
            .Include(s => s.User).ThenInclude(s => s.UserProfiles) // then include ở đây bị dư nè anh :v anh không cần nó thi ko cần include, bởi vì nó tốn thêm thời gian để load data từ db lên
            .Where(s => s.Id == resumeid &&
                        s.User.Id == userid)
            //&& s.UserProfiles.User.Id == userid) // dòng này bị dư nè anh
            .FirstOrDefault();


        //if (resumes != null)
        //{
        //    Application NewApply = new()
        //    {
        //        Users = user,
        //        Jobs = job,
        //        Resumes = resumes,
        //        Letter = "",
        //        TimeStamp = DateTime.UtcNow,
        //        Status = Status_Apply.Pending,
        //    };
        //    _context.Applications.Add(NewApply);
        //}
        //else
        //{
        //    return false;
        //}


        // ở câu lệnh if này anh viết chưa đẹp lắm, tôi comment rồi tôi copy cái mới rồi sửa cho anh nhé
        if (resumes == null)
        {
            return false;

        }
        // anh thấy thay vì viết lồng if else thì tôi viết chỉ 1 cái if thôi, nó sẽ đẹp hơn
        // nếu như thực sự resumes không null thì nó đi tiếp, không cần bỏ cái `đi tiếp ` vào một cái else
        // bởi vì nếu sai thì mình đã `return` rồi, mà return thì nghĩa là nó không đi tiếp phải không nào
        Application NewApply = new()
        {
            Users = user,
            Jobs = job,
            Resumes = resumes,
            Letter = "",
            TimeStamp = DateTime.UtcNow,
            Status = Status_Apply.Pending,
        };
        // rồi ở trên đây thằng enum Status_Apply của anh không nên viết có dấu underscore như vậy nhé
        // Nên đặt tên là: ApplyState

        _context.Applications.Add(NewApply);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(long id)
    {
        var apply = _context.Applications.SingleOrDefault(s => s.Id == id);
        if (apply == null)
        {
            return false;
        } // ở đây tôi thấy anh làm đúng rồi nè, sao ở trên thêm else vô chi z
        _context.Applications.Remove(apply);
        _context.SaveChanges();
        return true;
    }

    public ICollection<Application> GetAll()
    {
        return _context.Applications.ToList();
    }

    public Application GetById(long id)
    {
        Application? applications = _context.Applications.SingleOrDefault(s => s.Id == id);
        return applications; // bài tập nhỏ: làm sao để bỏ cái warning null ở đây nhỉ
    }

    public List<Application> GetByUserId(long userid)
    {
        List<Application> response = new List<Application>();
        var users = _context.Applications.Where(s => s.Users.Id == userid).ToList();
        if (users == null)
        {
            return response;
        }
        foreach (var user in users)
        {
            response.Add(new Application()
            {
                Id = user.Id,
                TimeStamp = user.TimeStamp,
                Letter = user.Letter,
                Status = user.Status,
            });
        }
        return response;
    }

    public bool Update(Application apply)
    {
        _context.Update(apply);
        _context.SaveChanges();
        return true;
    }
}
