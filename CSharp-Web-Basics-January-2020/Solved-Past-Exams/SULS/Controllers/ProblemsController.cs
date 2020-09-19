using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels.Problems;

namespace SULS.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProblemInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            //Validate input

            if (input.Name.Length < 5 || input.Name.Length > 20)
            {
                return this.Error("Name must be between 5 and 20 characters.");
            }

            if (input.Points < 50 || input.Points > 300)
            {
                return this.Error("Points must be between 50 and 300.");
            }

            this.problemsService.Create(input.Name, input.Points);
            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.problemsService.GetDetails(id);

            return this.View(viewModel);
        }
    }
}
