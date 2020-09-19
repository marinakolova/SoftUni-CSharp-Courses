using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using SULS.ViewModels.Submissions;

namespace SULS.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ISubmissionsService submissionsService)
        {
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.submissionsService.CreateForm(id);

            if (problem == null)
            {
                return this.Error("Problem not found!");
            }

            return this.View(problem);
        }

        [HttpPost]
        public HttpResponse Create(CreateSubmissionInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            //Validate input

            if (input.Code.Length < 30 || input.Code.Length > 800)
            {
                return this.Error("Code length must be between 30 and 800 characters.");
            }

            this.submissionsService.Create(input.Code, input.ProblemId, this.User);
            
            return this.Redirect("/");
        }
        
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var submission = this.submissionsService.FindSubmission(id);

            if (submission == null)
            {
                return this.Error("Submission not found!");
            }

            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
