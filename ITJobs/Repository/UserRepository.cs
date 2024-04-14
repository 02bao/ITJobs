using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository;

public class UserRepository(DataContext _context) : IUserRepository
{
    public bool Delete(long userid)
    {
        User user = _context.Users.FirstOrDefault(s => s.Id ==  userid);
        if(user == null)
        {
            return false;
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }

    public ICollection<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetById(long userid)
    {
        return _context.Users.FirstOrDefault(s => s.Id == userid);
    }

    public long Login(User_login users)
    {
        User user = _context.Users.Where( s => s.UserName == users.UserName 
                                    && s.Password == users.Password).FirstOrDefault();
        if (user != null)
        {
            return user.Id;
        }
        return -1;
    }

    public bool Register(User_Register user)
    {
        User useremail = _context.Users.FirstOrDefault(s => s.Email == user.Email);
        if(useremail != null)
        {
            return false;
        }
        User users = new User
        {
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role,
        };
        _context.Users.Add(users);
        _context.SaveChanges();
        return true;
    }

    public bool Update(User user)
    {
       _context.Users.Update(user);
        _context.SaveChanges();
        return true;
    }
}
