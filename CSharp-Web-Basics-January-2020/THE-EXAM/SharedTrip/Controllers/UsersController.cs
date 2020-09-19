using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Net.Mail;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            //Validate Input

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                //return this.Error("Username length must be between 5 and 20 characters.");
                return this.Redirect("/Users/Register");
            }

            if (string.IsNullOrEmpty(input.Email) || string.IsNullOrWhiteSpace(input.Email))
            {
                //return this.Error("Email cannot be empty!");
                return this.Redirect("/Users/Register");
            }

            if (!IsValidEmail(input.Email))
            {
                //return this.Error("Email is not valid!");
                return this.Redirect("/Users/Register");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                //return this.Error("Password length must be between 6 and 20 characters.");
                return this.Redirect("/Users/Register");
            }

            //Validate Data

            if (input.Password != input.ConfirmPassword)
            {
                //return this.Error("Passwords should match.");
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.UsernameExists(input.Username) || this.usersService.EmailExists(input.Email))
            {
                return this.Error("Username/Email already in use.");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
