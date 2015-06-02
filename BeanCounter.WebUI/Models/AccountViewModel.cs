
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BeanCounter.Domain.Entities;
using BeanCounter.Domain.Abstract;
using BeanCounter.WebUI.Infrastructure;


namespace BeanCounter.WebUI.Models
{
    public class AccountViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }



        public bool CreateUser()
        {
            var account = IoCResolver.Resolve<IAccoutRepository>();
            var user = new User
            {
                UserName = this.UserName,
                Password = this.Password
            };
            var profile = new Profile
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                UserId = account.CreateUser(user)
            };

            var result= account.CreateUserProfile(profile);
            IoCResolver.Release(account);
            return result;
        }

        public bool AuthenticateUser()
        {
            var account = IoCResolver.Resolve<IAccoutRepository>();
            var isAuthenticated = false;
            var user = new User
            {
                UserName = this.UserName,
                Password = this.Password
            };
            var existinguser = account.GetUser(user);
            if (existinguser.UserId != 0)
            {
                var profile = account.GetProfile(existinguser.UserId);
                var accoutDetails = new AccountViewModel
                {
                    UserId = existinguser.UserId,
                    UserName = existinguser.UserName,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Email = profile.Email
                };
                IoCResolver.Release(account);
                isAuthenticated= true;
                HttpContext.Current.Session["User"] = accoutDetails;
            }
            IoCResolver.Release(account);
            return isAuthenticated;
        }



    }
}