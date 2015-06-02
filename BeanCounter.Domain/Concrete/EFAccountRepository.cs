using System.Linq;

using BeanCounter.Domain.Abstract;
using BeanCounter.Domain.Entities;
using BeanCounter.Domain.Helpers;

namespace BeanCounter.Domain.Concrete
{
    public class EFAccountRepository : IAccoutRepository
    {
        public User GetUser(User user)
        {
            user.Password = Security.EncryptPassword(user.Password);
            var existingUser=DbConnector.context.User.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            return existingUser;
        }
        public Profile GetProfile(int userId)
        {
            return DbConnector.context.Profile.FirstOrDefault(x => x.UserId == userId);
        }

        public int CreateUser(User user)
        {
            try
            {
                user.Password = Security.EncryptPassword(user.Password);
                DbConnector.context.User.Add(user);
                DbConnector.context.SaveChanges();
                return user.UserId;
            }
            catch
            {
                return 0;
            }

        }
        public bool CreateUserProfile(Profile profile)
        {
            try
            {
                DbConnector.context.Profile.Add(profile);
                DbConnector.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                var existingUser = DbConnector.context.User.FirstOrDefault(x => x.UserId == user.UserId);
                if (existingUser != null)
                {
                    existingUser.Password = user.Password;
                    DbConnector.context.SaveChanges();
                }
                return false;

            }
            catch
            {
                return false;
            }
        }
        public bool UpdateUserProfile(Profile profile)
        {
            try
            {
                var existingProfile = DbConnector.context.Profile.FirstOrDefault(x => x.UserId == profile.UserId);
                if(existingProfile!=null)
                {
                    existingProfile.FirstName = profile.FirstName;
                    existingProfile.LastName = profile.LastName;
                    existingProfile.Email = profile.Email;
                    DbConnector.context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
