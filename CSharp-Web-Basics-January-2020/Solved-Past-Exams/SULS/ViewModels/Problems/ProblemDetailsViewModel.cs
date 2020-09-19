using System.Collections.Generic;

namespace SULS.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ProblemDetailsSubmissionViewModel> Submissions { get; set; }
    }
}
