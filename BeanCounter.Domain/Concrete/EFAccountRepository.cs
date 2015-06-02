using System.Linq;

using BeanCounter.Domain.Abstract;
using BeanCounter.Domain.Entities;
using BeanCounter.Domain.Helpers;

namespace BeanCounter.Domain.Concrete
{
    public class EFAccountRepository : IAccoutRepository
    {
        private EFDbBeanCounterContext context = new EFDbBeanCounterContext();
        public User GetUser(User user)
        {
            user.Password = Security.EncryptPassword(user.Password);
            var existingUser=context.User.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            return existingUser;
        }
        public Profile GetProfile(int userId)
        {
            return context.Profile.FirstOrDefault(x => x.UserId == userId);
        }

        public int CreateUser(User user)
        {
            try
            {
                user.Password = Security.EncryptPassword(user.Password);
                context.User.Add(user);
                context.SaveChanges();
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
                context.Profile.Add(profile);
                context.SaveChanges();
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
                var existingUser = context.User.FirstOrDefault(x => x.UserId == user.UserId);
                if (existingUser != null)
                {
                    existingUser.Password = user.Password;
                    context.SaveChanges();
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
                var existingProfile = context.Profile.FirstOrDefault(x => x.UserId == profile.UserId);
                if(existingProfile!=null)
                {
                    existingProfile.FirstName = profile.FirstName;
                    existingProfile.LastName = profile.LastName;
                    existingProfile.Email = profile.Email;
                    context.SaveChanges();
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
