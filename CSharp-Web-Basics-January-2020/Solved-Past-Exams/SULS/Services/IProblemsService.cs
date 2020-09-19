using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void Create(string name, int points);

        ICollection<IndexProblemViewModel> GetAll();

        ProblemDetailsViewModel GetDetails(string id);
    }
}
