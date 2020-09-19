using SULS.Models;
using SULS.ViewModels.Submissions;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        CreateFormViewModel CreateForm(string id);

        void Create(string code, string problemId, string userId);

        Submission FindSubmission(string id);

        void Delete(string id);
    }
}
