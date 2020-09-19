using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels.Home;

namespace SULS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProblemsService problemsService;

        public HomeController(IUsersService usersService, IProblemsService problemsService)
        {
            this.usersService = usersService;
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = new IndexViewModel
                {
                    Problems = this.problemsService.GetAll()
                };

                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }
    }
}
