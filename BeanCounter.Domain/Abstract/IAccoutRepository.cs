using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeanCounter.Domain.Entities;

namespace BeanCounter.Domain.Abstract
{
    public interface IAccoutRepository
    {
        User GetUser(User user);
        Profile GetProfile(int userId);
        int CreateUser(User user);
        bool CreateUserProfile(Profile profile);
        bool UpdateUser(User user);
        bool UpdateUserProfile(Profile profile);
    }
}
