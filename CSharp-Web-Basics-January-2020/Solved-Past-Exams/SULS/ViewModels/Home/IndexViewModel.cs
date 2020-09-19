using System.Collections.Generic;
using SULS.ViewModels.Problems;

namespace SULS.ViewModels.Home
{
    public class IndexViewModel
    {
        public ICollection<IndexProblemViewModel> Problems { get; set; } = new List<IndexProblemViewModel>();
    }
}
